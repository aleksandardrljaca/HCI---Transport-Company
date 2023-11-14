CREATE DATABASE  IF NOT EXISTS `hci_db` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `hci_db`;
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
-- Table structure for table `faktura`
--

DROP TABLE IF EXISTS `faktura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `faktura` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Tip` varchar(45) NOT NULL,
  `NARUDZBENICA_ID` int NOT NULL,
  `ZAPOSLENI_ID` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_FAKTURA_NARUDZBENICA1_idx` (`NARUDZBENICA_ID`),
  KEY `fk_FAKTURA_ZAPOSLENI1_idx` (`ZAPOSLENI_ID`),
  CONSTRAINT `fk_FAKTURA_NARUDZBENICA1` FOREIGN KEY (`NARUDZBENICA_ID`) REFERENCES `narudzbenica` (`ID`),
  CONSTRAINT `fk_FAKTURA_ZAPOSLENI1` FOREIGN KEY (`ZAPOSLENI_ID`) REFERENCES `zaposleni` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `klijent`
--

DROP TABLE IF EXISTS `klijent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `klijent` (
  `IDKlijenta` int NOT NULL AUTO_INCREMENT,
  `Ime` varchar(45) NOT NULL,
  `Kontakt` varchar(45) NOT NULL,
  PRIMARY KEY (`IDKlijenta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `narudzbenica`
--

DROP TABLE IF EXISTS `narudzbenica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `narudzbenica` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `KLIJENT_IDKlijenta` int NOT NULL,
  `Datum` date NOT NULL,
  `UkupnaCijena` decimal(10,0) NOT NULL,
  `ZAPOSLENI_ID` int NOT NULL,
  `VOZAC_VOZILO_IdZaduzenja` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_NARUDZBENICA_KLIJENT1_idx` (`KLIJENT_IDKlijenta`),
  KEY `fk_NARUDZBENICA_ZAPOSLENI1_idx` (`ZAPOSLENI_ID`),
  KEY `fk_NARUDZBENICA_VOZAC_VOZILO1_idx` (`VOZAC_VOZILO_IdZaduzenja`),
  CONSTRAINT `fk_NARUDZBENICA_KLIJENT1` FOREIGN KEY (`KLIJENT_IDKlijenta`) REFERENCES `klijent` (`IDKlijenta`),
  CONSTRAINT `fk_NARUDZBENICA_VOZAC_VOZILO1` FOREIGN KEY (`VOZAC_VOZILO_IdZaduzenja`) REFERENCES `vozac_vozilo` (`IdZaduzenja`),
  CONSTRAINT `fk_NARUDZBENICA_ZAPOSLENI1` FOREIGN KEY (`ZAPOSLENI_ID`) REFERENCES `zaposleni` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usluga`
--

DROP TABLE IF EXISTS `usluga`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usluga` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Tip` varchar(45) NOT NULL,
  `Cijena` decimal(10,0) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usluga_narudzbenica`
--

DROP TABLE IF EXISTS `usluga_narudzbenica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usluga_narudzbenica` (
  `USLUGA_ID` int NOT NULL,
  `NARUDZBENICA_ID` int NOT NULL,
  `Cijena` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`NARUDZBENICA_ID`,`USLUGA_ID`),
  KEY `fk_USLUGA_has_NARUDZBENICA_NARUDZBENICA1_idx` (`NARUDZBENICA_ID`),
  KEY `fk_USLUGA_has_NARUDZBENICA_USLUGA1_idx` (`USLUGA_ID`),
  CONSTRAINT `fk_USLUGA_has_NARUDZBENICA_NARUDZBENICA1` FOREIGN KEY (`NARUDZBENICA_ID`) REFERENCES `narudzbenica` (`ID`),
  CONSTRAINT `fk_USLUGA_has_NARUDZBENICA_USLUGA1` FOREIGN KEY (`USLUGA_ID`) REFERENCES `usluga` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vozac`
--

DROP TABLE IF EXISTS `vozac`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vozac` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Ime` varchar(45) NOT NULL,
  `Prezime` varchar(45) NOT NULL,
  `GodineIskustva` int NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vozac_vozilo`
--

DROP TABLE IF EXISTS `vozac_vozilo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vozac_vozilo` (
  `IdZaduzenja` int NOT NULL AUTO_INCREMENT,
  `DatumOd` date NOT NULL,
  `DatumDo` date NOT NULL,
  `VOZILO_ID` int NOT NULL,
  `VOZAC_ID` int NOT NULL,
  `ZAPOSLENI_ID` int NOT NULL,
  PRIMARY KEY (`IdZaduzenja`),
  KEY `fk_VOZAC_VOZILO_VOZILO1_idx` (`VOZILO_ID`),
  KEY `fk_VOZAC_VOZILO_VOZAC1_idx` (`VOZAC_ID`),
  KEY `fk_VOZAC_VOZILO_ZAPOSLENI1_idx` (`ZAPOSLENI_ID`),
  CONSTRAINT `fk_VOZAC_VOZILO_VOZAC1` FOREIGN KEY (`VOZAC_ID`) REFERENCES `vozac` (`ID`),
  CONSTRAINT `fk_VOZAC_VOZILO_VOZILO1` FOREIGN KEY (`VOZILO_ID`) REFERENCES `vozilo` (`ID`),
  CONSTRAINT `fk_VOZAC_VOZILO_ZAPOSLENI1` FOREIGN KEY (`ZAPOSLENI_ID`) REFERENCES `zaposleni` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vozilo`
--

DROP TABLE IF EXISTS `vozilo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vozilo` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `RegistarskaOznaka` char(7) NOT NULL,
  `Model` varchar(45) NOT NULL,
  `GodinaProizvodnje` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `RegistarskaOznaka_UNIQUE` (`RegistarskaOznaka`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `zaposleni`
--

DROP TABLE IF EXISTS `zaposleni`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zaposleni` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `KorisnickoIme` varchar(45) NOT NULL,
  `Lozinka` char(128) NOT NULL,
  `Ime` varchar(45) NOT NULL,
  `Prezime` varchar(45) NOT NULL,
  `Plata` decimal(10,0) NOT NULL,
  `isAdmin` tinyint NOT NULL,
  `Tema` tinyint NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-14 11:57:27
