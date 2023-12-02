using ADTransport.Data.Model;
using ADTransport.Data.Wrapper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADTransport.Forms
{
    public partial class InvoicesForm : Form
    {
        private string _lang;
        private Employee _employee;
        public InvoicesForm(Employee emp, string lang)
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
            }
            //supercool
            else
            {
                this.BackColor = Color.FromArgb(255, 140, 4);
            }
        }

        private void InvoicesForm_Load(object sender, EventArgs e)
        {
            addInvoiceBtn.Enabled = false;

            List<Invoice> invoices = InvoiceWrapper.GetInvoices();
            invoicesDGV.DataSource = invoices;
            invoicesDGV.Columns["ID"].Width = 70;
            List<Order> orders = OrderWrapper.GetOrders();
            ordersDGV.DataSource = orders;
            ordersDGV.Columns["ID"].Width = 70;

            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click += (sen, ee) =>
            {
                if (invoicesDGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = invoicesDGV.SelectedRows[0];

                    int id;

                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    InvoiceWrapper.DeleteInvoice(id);
                    invoices = InvoiceWrapper.GetInvoices();
                    invoicesDGV.DataSource = invoices;

                }
                else
                {
                    if (_lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            ContextMenuStrip contextMenuStripInvoices = new ContextMenuStrip();
            contextMenuStripInvoices.Items.Add(deleteMenuItem);
            invoicesDGV.ContextMenuStrip = contextMenuStripInvoices;

            ToolStripMenuItem detailsMenuItem = new ToolStripMenuItem("Details");
            detailsMenuItem.Click += (sen, ee) =>
            {
                if (invoicesDGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = invoicesDGV.SelectedRows[0];
                    int id;
                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    List<Service> srvcs = ServiceWrapper.GetServicesFromOrderInvoice(id, "invoice");
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

            };
            contextMenuStripInvoices.Items.Add(detailsMenuItem);

        }

        private void ordersDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            addInvoiceBtn.Enabled = true;
         
        }

        private void addInvoiceBtn_Click(object sender, EventArgs e)
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
                    List<Invoice> invoices = InvoiceWrapper.GetInvoices();
                    invoicesDGV.DataSource = invoices;
                }
                else
                {
                    if (_lang == "en-US")
                        MessageBox.Show("No infomration about invoice type!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show("Niste unijeli tip fakture!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
