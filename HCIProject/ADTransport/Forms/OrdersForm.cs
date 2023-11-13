using ADTransport.Data.Model;
using ADTransport.Data.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;

namespace ADTransport.Forms
{
    public partial class OrdersForm : Form
    {
        public string lang;
        public Employee employee;
        public OrdersForm(Employee emp,string lang)
        {
            this.lang = lang;
            this.employee = emp;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.TopLevel = false;
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            ApplyTheme();
        }
        private void ApplyTheme()
        {
            int theme = employee.Theme;
            //light
            if (theme == 0)
            {
                this.BackColor = Color.White;
            }
            //dark
            else if (theme == 1)
            {
                this.BackColor = Color.FromArgb(26, 35, 46);
            }
            //supercool
            else
            {
                this.BackColor = Color.FromArgb(255, 140, 4);
            }
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            addNewOrder.Enabled = false;
            List<Order> orders = OrderWrapper.GetOrders();
            ordersDGV.DataSource = orders;
            List<Service> services = ServiceWrapper.GetServices();
            servicesDGV.DataSource = services;
            servicesDGV.Columns["ID"].Width = 30;
            servicesDGV.Columns["Type"].Width = 80;
            servicesDGV.Columns["Price"].Width = 80;
            List<Clients> clients = ClientWrapper.GetClients();
            clientsDGV.DataSource = clients;
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click += (sen, ee) =>
            {
                if (ordersDGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = ordersDGV.SelectedRows[0];

                    int id;
                    /*DateTime date;
                    string clientName, clientContact, driverName;
                    double price;*/
                    int.TryParse(selectedRow.Cells["Id"].Value.ToString(), out id);
                    /*clientName = (selectedRow.Cells["ClientName"].Value.ToString());
                    clientContact = (selectedRow.Cells["ClientContact"].Value.ToString());
                    DateTime.TryParse(selectedRow.Cells["Date"].Value.ToString(), out date);
                    double.TryParse(selectedRow.Cells["TotalPrice"].Value.ToString(), out price);
                    driverName = (selectedRow.Cells["DriversName"].Value.ToString());

                    Order order = new Order(id,clientName,clientContact,date,price,driverName);*/
                    OrderWrapper.DeleteOrder(id);
                    orders = OrderWrapper.GetOrders();
                    ordersDGV.DataSource = orders;
                    
                }
                else
                {
                    if (lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            ContextMenuStrip contextMenuStripOrdrs = new ContextMenuStrip();
            contextMenuStripOrdrs.Items.Add(deleteMenuItem);
            ordersDGV.ContextMenuStrip = contextMenuStripOrdrs;
        }

        private void servicesDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (clientsDGV.SelectedRows.Count == 1)
                addNewOrder.Enabled = true;
          
        }

        private void clientsDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (servicesDGV.SelectedRows.Count == 1)
                addNewOrder.Enabled = true;
        }

        private void addNewOrder_Click(object sender, EventArgs e)
        {
            List<Service> services = new List<Service>();
            Clients client = null;
            if (servicesDGV.SelectedRows.Count == 1 || servicesDGV.SelectedRows.Count > 1)
            {
               
                for(int i = 0; i < servicesDGV.SelectedRows.Count; i++)
                {
                    DataGridViewRow row = servicesDGV.SelectedRows[i];
                    int id;
                    string type;
                    double price;
                    int.TryParse(row.Cells["ID"].Value.ToString(), out id);
                    type = row.Cells["Type"].Value.ToString();
                    double.TryParse(row.Cells["Price"].Value.ToString(), out price);
                    services.Add(new Service(id, type, price));
                }
            }
            if(clientsDGV.SelectedRows.Count==1)
            {
                DataGridViewRow row = clientsDGV.SelectedRows[0];
                
                int id;
                string name, contact;
                int.TryParse(row.Cells["ID"].Value.ToString(), out id);
                name = row.Cells["Name"].Value.ToString();
                contact = row.Cells["Contact"].Value.ToString();
                client = new Clients(id, name, contact);
            }
            if(services.Count>0 && client != null)
            {
                string date;
                if (lang == "en-US")
                {

                    date = Interaction.InputBox("Please type in the delivery date",
                       "Date",
                       "Format: year-month-day",
                       900,
                       450);
                   
                }
                else
                {

                    date = Interaction.InputBox("Unesite datum dostave",
                    "Datum",
                    "Format: godina-mjesec-dan",
                    900,
                    450);
                   
                }
                if (!"".Equals(date)  && !"Format: year-month-day".Equals(date)  && !"Format: godina-mjesec-dan".Equals(date))
                {
                    DateTime deliveryDate;
                    DateTime.TryParse(date, out deliveryDate);

                    bool isOrderCreated= OrderWrapper.CreateAnOrder(client.ID, employee.Id, deliveryDate);

                    if (isOrderCreated)
                    {
                        List<Order> orders = OrderWrapper.GetOrders();
                        ordersDGV.DataSource = orders;

                        for (int i = 0; i < services.Count; i++)
                        {
                            OrderWrapper.AddServiceToOrder(services.ElementAt(i).ID);
                        }
                        if (lang == "en-US")
                            MessageBox.Show("You have successfully created new Order!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Uspješno kreirana narudzbenica!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }else
                    {
                        if (lang == "en-US")
                            MessageBox.Show("Drivers are bussy - order cannot be created at this time!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else MessageBox.Show("Nije moguće kreirati narudzbenicu jer nema slobodnih vozača!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (lang == "en-US")
                        MessageBox.Show("No infomration about date!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Niste unijeli datume!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                if (lang == "en-US")
                    MessageBox.Show("Data missing, please select rows again", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Podaci nisu selektovani ispravno", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void newClientLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (servicesDGV.SelectedRows.Count >= 1)
            {
                addNewOrder.Enabled = true;
                List<Service> services = new List<Service>();
                string name, contact, input;
                if (lang == "en-US")
                {

                    input = Interaction.InputBox("Please enter clients name and contact",
                       "Client",
                       "Format: name-contact",
                       900,
                       450);

                }
                else
                {
                    input = Interaction.InputBox("Unesite ime i kontakt klijenta",
                    "Klijent",
                    "Format: ime-kontakt",
                    900,
                    450);

                }
                if (!"".Equals(input) && !"Format: name-contact".Equals(input) && !"Format: ime-kontakt".Equals(input))
                {
                    string[] splitResult = input.Split('-');
                    name = splitResult[0];
                    contact = splitResult[1];
                    for (int i = 0; i < servicesDGV.SelectedRows.Count; i++)
                    {
                        DataGridViewRow row = servicesDGV.SelectedRows[i];
                        int id;
                        string type;
                        double price;
                        int.TryParse(row.Cells["ID"].Value.ToString(), out id);
                        type = row.Cells["Type"].Value.ToString();
                        double.TryParse(row.Cells["Price"].Value.ToString(), out price);
                        services.Add(new Service(id, type, price));
                    }
                    ClientWrapper.AddClient(name, contact);
                    Clients client = ClientWrapper.GetMostRecentClient();
                    string date;
                    if (lang == "en-US")
                    {

                        date = Interaction.InputBox("Please type in the delivery date",
                           "Date",
                           "Format: year-month-day",
                           900,
                           450);

                    }
                    else
                    {

                        date = Interaction.InputBox("Unesite datum dostave",
                        "Datum",
                        "Format: godina-mjesec-dan",
                        900,
                        450);

                    }
                    if (!"".Equals(date) && !"Format: year-month-day".Equals(date) && !"Format: godina-mjesec-dan".Equals(date))
                    {
                        DateTime deliveryDate;
                        DateTime.TryParse(date, out deliveryDate);

                        bool isOrderCreated = OrderWrapper.CreateAnOrder(client.ID, employee.Id, deliveryDate);

                        if (isOrderCreated)
                        {
                   

                            for (int i = 0; i < services.Count; i++)
                            {
                                OrderWrapper.AddServiceToOrder(services.ElementAt(i).ID);
                            }
                            List<Order> orders = OrderWrapper.GetOrders();
                            ordersDGV.DataSource = orders;
                            if (lang == "en-US")
                                MessageBox.Show("You have successfully created new Order!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else MessageBox.Show("Uspješno kreirana narudzbenica!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (lang == "en-US")
                                MessageBox.Show("Drivers are bussy - order cannot be created at this time!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else MessageBox.Show("Nije moguće kreirati narudzbenicu jer nema slobodnih vozača!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (lang == "en-US")
                            MessageBox.Show("No infomration about date!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else MessageBox.Show("Niste unijeli datume!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
