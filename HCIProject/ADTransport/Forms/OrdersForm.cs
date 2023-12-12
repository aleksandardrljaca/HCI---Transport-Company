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
using System.IO;

namespace ADTransport.Forms
{
    public partial class OrdersForm : Form
    {
        private string _lang;
        private Employee _employee;
   
        public OrdersForm(Employee emp, string lang)
        {
            this._lang = lang;
            this._employee = emp;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.TopLevel = false;
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            ApplyTheme();
           
        }
        private void ApplyTheme()
        {
            int theme = _employee.Theme;
            //light
            if (theme == 0)
            {
                this.BackColor = Color.White;
            }
            //dark
            else if (theme == 1)
            {
                this.BackColor = Color.FromArgb(26, 35, 46);
                label2.ForeColor = Color.FromArgb(255, 140, 4);
                newOrderGBox.ForeColor = Color.FromArgb(255, 140, 4);
                label1.ForeColor = Color.FromArgb(255, 140, 4);
                addNewOrder.ForeColor = Color.FromArgb(255, 140, 4);
                newClientGBox.ForeColor = Color.FromArgb(255, 140, 4);
                button1.ForeColor= Color.FromArgb(255, 140, 4);
            }
            //supercool
            else
            {
                this.BackColor = Color.FromArgb(255, 140, 4);
               
            }
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {

            if (_lang == "en-US")
            {
                label1.Text = "Filter by";
                comboBox1.Items.Add("All");
                comboBox1.Items.Add("Invoices");
                comboBox1.Items.Add("Orders");
                comboBox1.Text = "All";
                
            }
            else
            {
                label1.Text = "Filtriraj prema";
                comboBox1.Items.Add("Sve");
                comboBox1.Items.Add("Fakture");
                comboBox1.Items.Add("Narudžbenice");
                comboBox1.Text = "Sve";
            }
            newClientGBox.Enabled = false;
            button1.Enabled= false;
            servicesDGV.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            servicesDGV.ForeColor = Color.Black;
            clientsDGV.ForeColor = Color.Black;
            clientsDGV.MultiSelect = false;
            servicesDGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            clientsDGV.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            clientsDGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ordersDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            servicesDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            addNewOrder.Enabled = false;
            List<Order> orders = OrderWrapper.GetOrdersInvoices();
            ordersDGV.DataSource = orders;
            ordersDGV.Columns["ID"].Visible = false;
            ordersDGV.Columns["Assistant"].Width = 118;
            ordersDGV.MultiSelect = false;
            List<Service> services = ServiceWrapper.GetServices();
            servicesDGV.DataSource = services;
            servicesDGV.Columns["ID"].Visible = false;
            servicesDGV.Columns["Type"].Width = 94;
            servicesDGV.Columns["Price"].Width = 94;
            List<Clients> clients = ClientWrapper.GetClients();
         
            clientsDGV.DataSource = clients;
            clientsDGV.Columns["ID"].Visible = false;
            clientsDGV.Columns["Name"].Width = 94;
            clientsDGV.Columns["Contact"].Width = 94;
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click += (sen, ee) =>
            {
                if (ordersDGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = ordersDGV.SelectedRows[0];

                    int id;

                    int.TryParse(selectedRow.Cells["Id"].Value.ToString(), out id);


                    if (selectedRow.Cells["InvoiceType"].Value.ToString().Equals("Nefakturisano"))
                        OrderWrapper.DeleteOrder(id);
                    else InvoiceWrapper.DeleteInvoice(id);
                    orders = OrderWrapper.GetOrdersInvoices();
                    ordersDGV.DataSource = orders;
                    ordersDGV.Columns["ID"].Visible = false;
                }
                else
                {
                    if (_lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }
                button1.Enabled = false;
                ordersDGV.ClearSelection();
            };
            ContextMenuStrip contextMenuStripOrdrs = new ContextMenuStrip();
            contextMenuStripOrdrs.Items.Add(deleteMenuItem);
            ordersDGV.ContextMenuStrip = contextMenuStripOrdrs;


            ToolStripMenuItem detailsMenuItem = new ToolStripMenuItem("Details");
            detailsMenuItem.Click += (sen, ee) =>
            {
                if (ordersDGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = ordersDGV.SelectedRows[0];
                    int id;
                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    List<Service> srvcs;
                    if (selectedRow.Cells[6].Value.ToString().Equals("Nefakturisano"))
                        srvcs = ServiceWrapper.GetServicesFromOrderInvoice(id, "order");
                    else srvcs = ServiceWrapper.GetServicesFromOrderInvoice(id, "invoice");
                    string description = "Type - Price \n";
                    for (int i = 0; i < srvcs.Count; i++)
                        description += srvcs.ElementAt(i).Type + " - " + srvcs.ElementAt(i).Price + "\n";
                    MessageBox.Show(description, "Details about services", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    if (_lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }
                button1.Enabled = false;
                ordersDGV.ClearSelection();
            };
            contextMenuStripOrdrs.Items.Add(detailsMenuItem);
            if (_lang == "en-US")
            {
                ordersDGV.Columns["ClientName"].HeaderText = "Client name";
                ordersDGV.Columns["TotalPrice"].HeaderText = "Total price";
                ordersDGV.Columns["DriversName"].HeaderText = "Driver name";
                ordersDGV.Columns["InvoiceType"].HeaderText = "Invoice type";
                ordersDGV.Columns["ClientContact"].HeaderText = "Client contact";

               


            }
            else
            {
                ordersDGV.Columns["ClientName"].HeaderText = "Ime klijenta";
                ordersDGV.Columns["TotalPrice"].HeaderText = "Ukupna cijena";
                ordersDGV.Columns["DriversName"].HeaderText = "Vozač";
                ordersDGV.Columns["InvoiceType"].HeaderText = "Tip fakture";
                ordersDGV.Columns["ClientContact"].HeaderText = "Kontakt klijenta";
                ordersDGV.Columns["Assistant"].HeaderText = "Administrativni radnik";

                servicesDGV.Columns["Type"].HeaderText = "Tip usluge";
                servicesDGV.Columns["Price"].HeaderText = "Cijena";

                clientsDGV.Columns["Name"].HeaderText = "Ime";
                clientsDGV.Columns["Contact"].HeaderText = "Kontakt";


            }
        }



        private void addNewOrder_Click(object sender, EventArgs e)
        {
            List<Service> services = new List<Service>();
            Clients client = null;
            if (servicesDGV.SelectedRows.Count == 1 || servicesDGV.SelectedRows.Count > 1)
            {

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
            }
            if (!newClientCBox.Checked)
            {
                if (clientsDGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow row = clientsDGV.SelectedRows[0];

                    int id;
                    string name, contact;
                    int.TryParse(row.Cells["ID"].Value.ToString(), out id);
                    name = row.Cells["Name"].Value.ToString();
                    contact = row.Cells["Contact"].Value.ToString();
                    client = new Clients(id, name, contact);
                }
            }
            else
            {
                ClientWrapper.AddClient(clientNameTBox.Text, clientContactTBox.Text);
                client = ClientWrapper.GetMostRecentClient();
            }
            if (services.Count > 0 && client != null)
            {
                string date;
                if (_lang == "en-US")
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
                    DateTime todaysDate = DateTime.Today;
                    int isWrongDate=DateTime.Compare(deliveryDate, todaysDate);
                    
                    if(isWrongDate<0)
                    {
                        if (_lang == "en-US")
                            MessageBox.Show("Date not correct!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Datum nije ispravan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    bool isOrderCreated = OrderWrapper.CreateAnOrder(client.ID, _employee.Id, deliveryDate);

                    if (isOrderCreated)
                    {


                        for (int i = 0; i < services.Count; i++)
                        {
                            OrderWrapper.AddServiceToOrder(services.ElementAt(i).ID);
                        }
                        List<Order> orders = OrderWrapper.GetOrdersInvoices();
                        ordersDGV.DataSource = orders;
                        servicesDGV.ClearSelection();
                        clientsDGV.ClearSelection();
                        ordersDGV.ClearSelection();
                        if(newClientCBox.Checked)
                        {
                            newClientGBox.Enabled = false;
                            newClientCBox.Checked = false;
                            clientNameTBox.Clear();
                            clientContactTBox.Clear();
                        }
                        if (_lang == "en-US")
                            MessageBox.Show("You have successfully created new Order!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Uspješno kreirana narudzbenica!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (_lang == "en-US")
                            MessageBox.Show("Drivers are bussy - order cannot be created at this time!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else MessageBox.Show("Nije moguće kreirati narudzbenicu jer nema slobodnih vozača!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (_lang == "en-US")
                        MessageBox.Show("No infomration about date!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Niste unijeli datume!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                if (_lang == "en-US")
                    MessageBox.Show("Data missing, please select rows again", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Podaci nisu selektovani ispravno", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }


        private void ordersDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in ordersDGV.Rows)
            {
                if (Convert.ToString(row.Cells[7].Value) == " ")
                {
                    row.Cells[6].Style.BackColor = Color.OrangeRed;
                    row.Cells[7].Style.BackColor = Color.OrangeRed;
                }
                else
                {
                    row.Cells[6].Style.BackColor = Color.LightGreen;
                    row.Cells[7].Style.BackColor = Color.LightGreen;
                }

            }
        }


        private void OrdersForm_MouseClick(object sender, MouseEventArgs e)
        {
            ordersDGV.ClearSelection();
            servicesDGV.ClearSelection();
            clientsDGV.ClearSelection();
            button1.Enabled = false;
        }

        private void servicesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*servicesDGV.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            servicesDGV.Rows[e.RowIndex].Selected = true;*/
            if (clientsDGV.SelectedRows.Count == 1 || ("".Equals(clientNameTBox.Text) && "".Equals(clientContactTBox.Text)))
                addNewOrder.Enabled = true;
        }

       private void clientsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*clientsDGV.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            clientsDGV.Rows[e.RowIndex].Selected = true;*/
            if (servicesDGV.SelectedRows.Count == 1)
                addNewOrder.Enabled = true;
        }

        private void ordersDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            DataGridViewRow selectedRow = ordersDGV.SelectedRows[0];
            if (selectedRow.Cells[6].Value.ToString().Equals("Nefakturisano"))
            {
                button1.Enabled= true;
            }
            else
            {
                button1.Enabled= false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ordersDGV.SelectedRows.Count == 1)
            {
                DataGridViewRow row = ordersDGV.SelectedRows[0];
                int orderId;
                int.TryParse(row.Cells["ID"].Value.ToString(), out orderId);
                string invoiceType;
                if (_lang == "en-US")
                {

                    invoiceType = Interaction.InputBox("Please enter invoice type",
                       "Invoice type",
                       "In/Out",
                       900,
                       450);

                }
                else
                {

                    invoiceType = Interaction.InputBox("Unesite tip fakture",
                    "Tip fakture",
                    "Ulazna/Izlazna",
                    900,
                    450);

                }
                if (!"".Equals(invoiceType) && !"In/Out".Equals(invoiceType) && !"Ulazna/Izlazna".Equals(invoiceType))
                {
                    InvoiceWrapper.InsertInvoice(invoiceType, orderId, _employee.Id);
                    List<Order> orders = OrderWrapper.GetOrdersInvoices();
                    ordersDGV.DataSource = orders;
                    button1.Enabled = false;
                    OrdersForm_MouseClick(null, null);
                }
                else
                {
                    if (_lang == "en-US")
                        MessageBox.Show("No infomration about invoice type!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Niste unijeli tip fakture!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                List<Order> orders = OrderWrapper.GetOrdersInvoices();
                ordersDGV.DataSource = orders;
                ordersDGV.ClearSelection();
                button1.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                List<Order> orders = OrderWrapper.GetInvoices();
                ordersDGV.DataSource = orders;
                ordersDGV.ClearSelection();
                button1.Enabled = false;

            }
            else if (comboBox1.SelectedIndex == 2)
            {
                List<Order> orders = OrderWrapper.GetOrders();
                ordersDGV.DataSource = orders;
                ordersDGV.ClearSelection();
                button1.Enabled = false;
            }
        }

        private void newClientCBox_Click(object sender, EventArgs e)
        {
            clientsDGV.ClearSelection();
            if (newClientCBox.Checked)
            {
                newClientGBox.Enabled = true;
                clientsDGV.Enabled = false;
            }
            else
            {
                newClientGBox.Enabled = false;
                clientsDGV.Enabled = true;
            }
        }

       
    }
}
