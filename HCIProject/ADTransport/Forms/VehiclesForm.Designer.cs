
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
            this.vehicleGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodYearPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationPBOx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // vehicleGBox
            // 
            resources.ApplyResources(this.vehicleGBox, "vehicleGBox");
            this.vehicleGBox.BackColor = System.Drawing.Color.White;
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
            this.vehicleGBox.Name = "vehicleGBox";
            this.vehicleGBox.TabStop = false;
            // 
            // prodYearLbl
            // 
            resources.ApplyResources(this.prodYearLbl, "prodYearLbl");
            this.prodYearLbl.BackColor = System.Drawing.Color.White;
            this.prodYearLbl.Name = "prodYearLbl";
            // 
            // prodYearTBox
            // 
            resources.ApplyResources(this.prodYearTBox, "prodYearTBox");
            this.prodYearTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            resources.ApplyResources(this.registrationTBox, "registrationTBox");
            this.registrationTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registrationTBox.Name = "registrationTBox";
            // 
            // modelTBox
            // 
            resources.ApplyResources(this.modelTBox, "modelTBox");
            this.modelTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            resources.ApplyResources(this.vehiclesDGV, "vehiclesDGV");
            this.vehiclesDGV.AllowUserToAddRows = false;
            this.vehiclesDGV.AllowUserToDeleteRows = false;
            this.vehiclesDGV.BackgroundColor = System.Drawing.Color.White;
            this.vehiclesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vehiclesDGV.Name = "vehiclesDGV";
            this.vehiclesDGV.ReadOnly = true;
            this.vehiclesDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vehiclesDGV_CellClick);
            // 
            // VehiclesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}