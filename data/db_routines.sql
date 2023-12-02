-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: hci_db
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping routines for database 'hci_db'
--
/*!50003 DROP FUNCTION IF EXISTS `napraviNarudzbenicu` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `napraviNarudzbenicu`(pKlijentId int, pZaposleniId int,pDatumDostave Date) RETURNS tinyint(1)
    READS SQL DATA
BEGIN

	
	declare vozacSlobodan int;
    declare voziloSlobodno int;
    declare vozacId int;
    declare voziloId int;
    declare zaduzenjeId int;
   
   set vozacSlobodan=(select count(*) from vozac 
						left outer join vozac_vozilo on vozac_vozilo.VOZAC_ID=vozac.ID
                        where vozac_vozilo.VOZAC_ID is null or vozac_vozilo.DatumDo<curdate());
    set voziloSlobodno=(select count(*) from vozilo
						left outer join vozac_vozilo on vozac_vozilo.VOZILO_ID=vozilo.ID
						where vozac_vozilo.VOZILO_ID is null or vozac_vozilo.DatumDo<curdate());
	if (vozacSlobodan > 0 and voziloSlobodno > 0) then
    
		set vozacId=(select vozac.ID from vozac
					left outer join vozac_vozilo on vozac_vozilo.VOZAC_ID=vozac.ID
					where vozac_vozilo.VOZAC_ID is null or vozac_vozilo.DatumDo<curdate() limit 1);
		set voziloId=(select vozilo.ID as ID from vozilo 
						left outer join vozac_vozilo on vozac_vozilo.VOZILO_ID=vozilo.ID
						where vozac_vozilo.VOZILO_ID is null or vozac_vozilo.DatumDo<curdate() limit 1);
		insert into vozac_vozilo(DatumOd,DatumDo,VOZILO_ID,VOZAC_ID,ZAPOSLENI_ID) values (curdate(),pDatumDostave,voziloId,vozacId,pZaposleniId);
        set zaduzenjeId=(select max(vozac_vozilo.IdZaduzenja) from vozac_vozilo);
		insert into narudzbenica(KLIJENT_IDKlijenta,Datum,UkupnaCijena,ZAPOSLENI_ID,VOZAC_VOZILO_IdZaduzenja) values (pKlijentId,curdate(),0,pZaposleniId,zaduzenjeId);
		RETURN TRUE;
	end if;
RETURN FALSE;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `brisanjeNarudzbenice` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `brisanjeNarudzbenice`(in pIdN int)
BEGIN
	declare IdZaduzenja int;
    set IdZaduzenja=(select VOZAC_VOZILO_IdZaduzenja from narudzbenica where narudzbenica.ID=pIdN);
	delete from usluga_narudzbenica where usluga_narudzbenica.NARUDZBENICA_ID=pIdN;
    delete from narudzbenica where narudzbenica.ID=pIdN;
	delete from vozac_vozilo where vozac_vozilo.IdZaduzenja=IdZaduzenja;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `dodavanjeUsluge` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `dodavanjeUsluge`(in pIdUsluge int)
BEGIN
		declare idN int;
		declare cijenaUsluge int;
        set cijenaUsluge=(select Cijena from usluga where usluga.ID=pIdUsluge);
        set idN=(select max(narudzbenica.ID) from narudzbenica);
        insert into usluga_narudzbenica values (pIdUsluge,idN,cijenaUsluge);
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-02 14:37:54
