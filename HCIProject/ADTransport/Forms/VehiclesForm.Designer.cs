
namespace ADTransport.Forms
{
    partial class VehiclesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VehiclesForm));
            this.vehicleGBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.prodYearLbl = new System.Windows.Forms.Label();
            this.prodYearTBox = new System.Windows.Forms.TextBox();
            this.prodYearPBox = new System.Windows.Forms.PictureBox();
            this.modelLbl = new System.Windows.Forms.Label();
            this.regLbl = new System.Windows.Forms.Label();
            this.addVehicleBtn = new System.Windows.Forms.Button();
            this.registrationTBox = new System.Windows.Forms.TextBox();
            this.modelTBox = new System.Windows.Forms.TextBox();
            this.registrationPBOx = new System.Windows.Forms.PictureBox();
            this.modelPicBox = new System.Windows.Forms.PictureBox();
            this.vehiclesDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.vehicleGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodYearPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationPBOx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // vehicleGBox
            // 
            this.vehicleGBox.BackColor = System.Drawing.Color.Transparent;
            this.vehicleGBox.Controls.Add(this.button1);
            this.vehicleGBox.Controls.Add(this.prodYearLbl);
            this.vehicleGBox.Controls.Add(this.prodYearTBox);
            this.vehicleGBox.Controls.Add(this.prodYearPBox);
            this.vehicleGBox.Controls.Add(this.modelLbl);
            this.vehicleGBox.Controls.Add(this.regLbl);
            this.vehicleGBox.Controls.Add(this.addVehicleBtn);
            this.vehicleGBox.Controls.Add(this.registrationTBox);
            this.vehicleGBox.Controls.Add(this.modelTBox);
            this.vehicleGBox.Controls.Add(this.registrationPBOx);
            this.vehicleGBox.Controls.Add(this.modelPicBox);
            resources.ApplyResources(this.vehicleGBox, "vehicleGBox");
            this.vehicleGBox.Name = "vehicleGBox";
            this.vehicleGBox.TabStop = false;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // prodYearLbl
            // 
            resources.ApplyResources(this.prodYearLbl, "prodYearLbl");
            this.prodYearLbl.BackColor = System.Drawing.Color.Transparent;
            this.prodYearLbl.Name = "prodYearLbl";
            // 
            // prodYearTBox
            // 
            this.prodYearTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.prodYearTBox, "prodYearTBox");
            this.prodYearTBox.Name = "prodYearTBox";
            // 
            // prodYearPBox
            // 
            resources.ApplyResources(this.prodYearPBox, "prodYearPBox");
            this.prodYearPBox.Name = "prodYearPBox";
            this.prodYearPBox.TabStop = false;
            // 
            // modelLbl
            // 
            resources.ApplyResources(this.modelLbl, "modelLbl");
            this.modelLbl.Name = "modelLbl";
            // 
            // regLbl
            // 
            resources.ApplyResources(this.regLbl, "regLbl");
            this.regLbl.Name = "regLbl";
            // 
            // addVehicleBtn
            // 
            resources.ApplyResources(this.addVehicleBtn, "addVehicleBtn");
            this.addVehicleBtn.Name = "addVehicleBtn";
            this.addVehicleBtn.UseVisualStyleBackColor = true;
            this.addVehicleBtn.Click += new System.EventHandler(this.addVehicleBtn_Click);
            // 
            // registrationTBox
            // 
            this.registrationTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.registrationTBox, "registrationTBox");
            this.registrationTBox.Name = "registrationTBox";
            // 
            // modelTBox
            // 
            this.modelTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.modelTBox, "modelTBox");
            this.modelTBox.Name = "modelTBox";
            // 
            // registrationPBOx
            // 
            resources.ApplyResources(this.registrationPBOx, "registrationPBOx");
            this.registrationPBOx.Name = "registrationPBOx";
            this.registrationPBOx.TabStop = false;
            // 
            // modelPicBox
            // 
            resources.ApplyResources(this.modelPicBox, "modelPicBox");
            this.modelPicBox.Name = "modelPicBox";
            this.modelPicBox.TabStop = false;
            // 
            // vehiclesDGV
            // 
            this.vehiclesDGV.AllowUserToAddRows = false;
            this.vehiclesDGV.AllowUserToDeleteRows = false;
            this.vehiclesDGV.BackgroundColor = System.Drawing.Color.White;
            this.vehiclesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.vehiclesDGV, "vehiclesDGV");
            this.vehiclesDGV.Name = "vehiclesDGV";
            this.vehiclesDGV.ReadOnly = true;
            this.vehiclesDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vehiclesDGV_CellClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // VehiclesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vehiclesDGV);
            this.Controls.Add(this.vehicleGBox);
            this.Name = "VehiclesForm";
            this.Load += new System.EventHandler(this.VehiclesForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VehiclesForm_MouseClick);
            this.vehicleGBox.ResumeLayout(false);
            this.vehicleGBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodYearPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationPBOx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox vehicleGBox;
        private System.Windows.Forms.Label prodYearLbl;
        private System.Windows.Forms.TextBox prodYearTBox;
        private System.Windows.Forms.PictureBox prodYearPBox;
        private System.Windows.Forms.Label modelLbl;
        private System.Windows.Forms.Label regLbl;
        private System.Windows.Forms.Button addVehicleBtn;
        private System.Windows.Forms.TextBox registrationTBox;
        private System.Windows.Forms.TextBox modelTBox;
        private System.Windows.Forms.PictureBox registrationPBOx;
        private System.Windows.Forms.PictureBox modelPicBox;
        private System.Windows.Forms.DataGridView vehiclesDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}