
namespace ADTransport.Forms
{
    partial class OrdersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersForm));
            this.servicesDGV = new System.Windows.Forms.DataGridView();
            this.addNewOrder = new System.Windows.Forms.Button();
            this.ordersDGV = new System.Windows.Forms.DataGridView();
            this.servicesLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.newOrderGBox = new System.Windows.Forms.GroupBox();
            this.clientsDGV = new System.Windows.Forms.DataGridView();
            this.chooseClientLbl = new System.Windows.Forms.Label();
            this.newClientCBox = new System.Windows.Forms.CheckBox();
            this.newClientGBox = new System.Windows.Forms.GroupBox();
            this.clientContactTBox = new System.Windows.Forms.TextBox();
            this.clientNameTBox = new System.Windows.Forms.TextBox();
            this.clientContactLbl = new System.Windows.Forms.Label();
            this.clientNameLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDGV)).BeginInit();
            this.newOrderGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientsDGV)).BeginInit();
            this.newClientGBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // servicesDGV
            // 
            resources.ApplyResources(this.servicesDGV, "servicesDGV");
            this.servicesDGV.AllowUserToAddRows = false;
            this.servicesDGV.AllowUserToDeleteRows = false;
            this.servicesDGV.BackgroundColor = System.Drawing.Color.White;
            this.servicesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.servicesDGV.Name = "servicesDGV";
            this.servicesDGV.ReadOnly = true;
            this.servicesDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.servicesDGV_CellClick);
            // 
            // addNewOrder
            // 
            resources.ApplyResources(this.addNewOrder, "addNewOrder");
            this.addNewOrder.Name = "addNewOrder";
            this.addNewOrder.UseVisualStyleBackColor = true;
            this.addNewOrder.Click += new System.EventHandler(this.addNewOrder_Click);
            // 
            // ordersDGV
            // 
            resources.ApplyResources(this.ordersDGV, "ordersDGV");
            this.ordersDGV.AllowUserToAddRows = false;
            this.ordersDGV.AllowUserToDeleteRows = false;
            this.ordersDGV.BackgroundColor = System.Drawing.Color.White;
            this.ordersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersDGV.Name = "ordersDGV";
            this.ordersDGV.ReadOnly = true;
            this.ordersDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordersDGV_CellClick);
            this.ordersDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ordersDGV_CellFormatting);
            // 
            // servicesLbl
            // 
            resources.ApplyResources(this.servicesLbl, "servicesLbl");
            this.servicesLbl.Name = "servicesLbl";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // newOrderGBox
            // 
            resources.ApplyResources(this.newOrderGBox, "newOrderGBox");
            this.newOrderGBox.Controls.Add(this.clientsDGV);
            this.newOrderGBox.Controls.Add(this.chooseClientLbl);
            this.newOrderGBox.Controls.Add(this.newClientCBox);
            this.newOrderGBox.Controls.Add(this.newClientGBox);
            this.newOrderGBox.Controls.Add(this.servicesDGV);
            this.newOrderGBox.Controls.Add(this.addNewOrder);
            this.newOrderGBox.Controls.Add(this.servicesLbl);
            this.newOrderGBox.Name = "newOrderGBox";
            this.newOrderGBox.TabStop = false;
            // 
            // clientsDGV
            // 
            resources.ApplyResources(this.clientsDGV, "clientsDGV");
            this.clientsDGV.AllowUserToAddRows = false;
            this.clientsDGV.AllowUserToDeleteRows = false;
            this.clientsDGV.BackgroundColor = System.Drawing.Color.White;
            this.clientsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientsDGV.Name = "clientsDGV";
            this.clientsDGV.ReadOnly = true;
            this.clientsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientsDGV_CellClick);
            // 
            // chooseClientLbl
            // 
            resources.ApplyResources(this.chooseClientLbl, "chooseClientLbl");
            this.chooseClientLbl.Name = "chooseClientLbl";
            // 
            // newClientCBox
            // 
            resources.ApplyResources(this.newClientCBox, "newClientCBox");
            this.newClientCBox.Name = "newClientCBox";
            this.newClientCBox.UseVisualStyleBackColor = true;
            this.newClientCBox.Click += new System.EventHandler(this.newClientCBox_Click);
            // 
            // newClientGBox
            // 
            resources.ApplyResources(this.newClientGBox, "newClientGBox");
            this.newClientGBox.Controls.Add(this.clientContactTBox);
            this.newClientGBox.Controls.Add(this.clientNameTBox);
            this.newClientGBox.Controls.Add(this.clientContactLbl);
            this.newClientGBox.Controls.Add(this.clientNameLbl);
            this.newClientGBox.Name = "newClientGBox";
            this.newClientGBox.TabStop = false;
            // 
            // clientContactTBox
            // 
            resources.ApplyResources(this.clientContactTBox, "clientContactTBox");
            this.clientContactTBox.Name = "clientContactTBox";
            // 
            // clientNameTBox
            // 
            resources.ApplyResources(this.clientNameTBox, "clientNameTBox");
            this.clientNameTBox.Name = "clientNameTBox";
            // 
            // clientContactLbl
            // 
            resources.ApplyResources(this.clientContactLbl, "clientContactLbl");
            this.clientContactLbl.Name = "clientContactLbl";
            // 
            // clientNameLbl
            // 
            resources.ApplyResources(this.clientNameLbl, "clientNameLbl");
            this.clientNameLbl.Name = "clientNameLbl";
            // 
            // OrdersForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newOrderGBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ordersDGV);
            this.Name = "OrdersForm";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OrdersForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.servicesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDGV)).EndInit();
            this.newOrderGBox.ResumeLayout(false);
            this.newOrderGBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientsDGV)).EndInit();
            this.newClientGBox.ResumeLayout(false);
            this.newClientGBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView servicesDGV;
        private System.Windows.Forms.Button addNewOrder;
        private System.Windows.Forms.DataGridView ordersDGV;
        private System.Windows.Forms.Label servicesLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox newOrderGBox;
        private System.Windows.Forms.GroupBox newClientGBox;
        private System.Windows.Forms.TextBox clientContactTBox;
        private System.Windows.Forms.TextBox clientNameTBox;
        private System.Windows.Forms.Label clientContactLbl;
        private System.Windows.Forms.Label clientNameLbl;
        private System.Windows.Forms.Label chooseClientLbl;
        private System.Windows.Forms.CheckBox newClientCBox;
        private System.Windows.Forms.DataGridView clientsDGV;
    }
}