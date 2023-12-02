
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
            this.clientsDGV = new System.Windows.Forms.DataGridView();
            this.servicesDGV = new System.Windows.Forms.DataGridView();
            this.addNewOrder = new System.Windows.Forms.Button();
            this.ordersDGV = new System.Windows.Forms.DataGridView();
            this.clientsLbl = new System.Windows.Forms.Label();
            this.servicesLbl = new System.Windows.Forms.Label();
            this.newClientLinkLbl = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clientsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // clientsDGV
            // 
            this.clientsDGV.AllowUserToAddRows = false;
            this.clientsDGV.AllowUserToDeleteRows = false;
            this.clientsDGV.BackgroundColor = System.Drawing.Color.White;
            this.clientsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.clientsDGV, "clientsDGV");
            this.clientsDGV.Name = "clientsDGV";
            this.clientsDGV.ReadOnly = true;
            this.clientsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientsDGV_CellClick);
            // 
            // servicesDGV
            // 
            this.servicesDGV.AllowUserToAddRows = false;
            this.servicesDGV.AllowUserToDeleteRows = false;
            this.servicesDGV.BackgroundColor = System.Drawing.Color.White;
            this.servicesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.servicesDGV, "servicesDGV");
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
            this.ordersDGV.AllowUserToAddRows = false;
            this.ordersDGV.AllowUserToDeleteRows = false;
            this.ordersDGV.BackgroundColor = System.Drawing.Color.White;
            this.ordersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.ordersDGV, "ordersDGV");
            this.ordersDGV.Name = "ordersDGV";
            this.ordersDGV.ReadOnly = true;
            this.ordersDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordersDGV_CellClick);
            this.ordersDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ordersDGV_CellFormatting);
            // 
            // clientsLbl
            // 
            resources.ApplyResources(this.clientsLbl, "clientsLbl");
            this.clientsLbl.Name = "clientsLbl";
            // 
            // servicesLbl
            // 
            resources.ApplyResources(this.servicesLbl, "servicesLbl");
            this.servicesLbl.Name = "servicesLbl";
            // 
            // newClientLinkLbl
            // 
            resources.ApplyResources(this.newClientLinkLbl, "newClientLinkLbl");
            this.newClientLinkLbl.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(4)))));
            this.newClientLinkLbl.Name = "newClientLinkLbl";
            this.newClientLinkLbl.TabStop = true;
            this.newClientLinkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.newClientLinkLbl_LinkClicked);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
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
            // OrdersForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.newClientLinkLbl);
            this.Controls.Add(this.ordersDGV);
            this.Controls.Add(this.servicesLbl);
            this.Controls.Add(this.clientsLbl);
            this.Controls.Add(this.addNewOrder);
            this.Controls.Add(this.servicesDGV);
            this.Controls.Add(this.clientsDGV);
            this.Name = "OrdersForm";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OrdersForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.clientsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView clientsDGV;
        private System.Windows.Forms.DataGridView servicesDGV;
        private System.Windows.Forms.Button addNewOrder;
        private System.Windows.Forms.DataGridView ordersDGV;
        private System.Windows.Forms.Label clientsLbl;
        private System.Windows.Forms.Label servicesLbl;
        private System.Windows.Forms.LinkLabel newClientLinkLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}