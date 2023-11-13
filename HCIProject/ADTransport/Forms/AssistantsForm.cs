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

namespace ADTransport.Forms
{
    public partial class AssistantsForm : Form
    {
        public string lang;
        public Employee employee;
        public AssistantsForm(Employee emp, string lang)
        {
            this.lang = lang;
            this.employee = emp;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.TopLevel = false;
            InitializeComponent();
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
        private void AssistansForm_Load(object sender, EventArgs e)
        {
            List<Employee> assistants = EmployeeWrapper.GetAssistants();
            assistantsDGV.DataSource = assistants;
            assistantsDGV.Columns["ID"].Width = 30;
            assistantsDGV.Columns["isAdmin"].Visible = false;
            assistantsDGV.Columns["Theme"].Visible = false;
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            deleteMenuItem.Click += (sen, ee) =>
            {
                if (assistantsDGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = assistantsDGV.SelectedRows[0];

                    int id;

                    int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out id);
                    EmployeeWrapper.DeleteEmployee(id);
                    assistants = EmployeeWrapper.GetAssistants();
                    assistantsDGV.DataSource = assistants;

                }
                else
                {
                    if (lang == "en-US") MessageBox.Show("You must select enitre row");
                    else MessageBox.Show("Potrebno je selektovati cijeli jedan red");
                }

            };
            ContextMenuStrip contextMenuStripOrdrs = new ContextMenuStrip();
            contextMenuStripOrdrs.Items.Add(deleteMenuItem);
            assistantsDGV.ContextMenuStrip = contextMenuStripOrdrs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!"".Equals(usrNameTBox.Text) && !"".Equals(pswdTBox.Text) && !"".Equals(fNameTBox.Text) && !"".Equals(lNameTBox.Text) && !"".Equals(salaryTBox.Text))
            {
                string username = usrNameTBox.Text;
                string password = pswdTBox.Text;
                string firstName = fNameTBox.Text;
                string lastName = lNameTBox.Text;
                double salary;
                double.TryParse(salaryTBox.Text, out salary);
                EmployeeWrapper.InsertEmployee(username,password,firstName,lastName,salary);
                List<Employee> assistants = EmployeeWrapper.GetAssistants();
                assistantsDGV.DataSource = assistants;
                assistantsDGV.Columns["ID"].Width = 30;
                usrNameTBox.Clear();
                pswdTBox.Clear();
                fNameTBox.Clear();
                lNameTBox.Clear();
                salaryTBox.Clear();
            }
            else
            {
                if (lang == "en-US") MessageBox.Show("No data entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Niste unijeli potrebne podatke!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
