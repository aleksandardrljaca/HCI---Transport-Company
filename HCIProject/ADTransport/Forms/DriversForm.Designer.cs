
namespace ADTransport.Forms
{
    partial class DriversForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriversForm));
            this.driversGBox = new System.Windows.Forms.GroupBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.yearsLbl = new System.Windows.Forms.Label();
            this.driverYearsTBox = new System.Windows.Forms.TextBox();
            this.driverYearsPBox = new System.Windows.Forms.PictureBox();
            this.lastNameLbl = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.addDriverBtn = new System.Windows.Forms.Button();
            this.driverNameTBox = new System.Windows.Forms.TextBox();
            this.driverLastNameTBox = new System.Windows.Forms.TextBox();
            this.driverNamePBOx = new System.Windows.Forms.PictureBox();
            this.driverLastNamePicBox = new System.Windows.Forms.PictureBox();
            this.driversDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.driversGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.driverYearsPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverNamePBOx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverLastNamePicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driversDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // driversGBox
            // 
            resources.ApplyResources(this.driversGBox, "driversGBox");
            this.driversGBox.BackColor = System.Drawing.Color.Transparent;
            this.driversGBox.Controls.Add(this.cancelBtn);
            this.driversGBox.Controls.Add(this.yearsLbl);
            this.driversGBox.Controls.Add(this.driverYearsTBox);
            this.driversGBox.Controls.Add(this.driverYearsPBox);
            this.driversGBox.Controls.Add(this.lastNameLbl);
            this.driversGBox.Controls.Add(this.nameLbl);
            this.driversGBox.Controls.Add(this.addDriverBtn);
            this.driversGBox.Controls.Add(this.driverNameTBox);
            this.driversGBox.Controls.Add(this.driverLastNameTBox);
            this.driversGBox.Controls.Add(this.driverNamePBOx);
            this.driversGBox.Controls.Add(this.driverLastNamePicBox);
            this.driversGBox.Name = "driversGBox";
            this.driversGBox.TabStop = false;
            // 
            // cancelBtn
            // 
            resources.ApplyResources(this.cancelBtn, "cancelBtn");
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // yearsLbl
            // 
            resources.ApplyResources(this.yearsLbl, "yearsLbl");
            this.yearsLbl.BackColor = System.Drawing.Color.Transparent;
            this.yearsLbl.Name = "yearsLbl";
            // 
            // driverYearsTBox
            // 
            resources.ApplyResources(this.driverYearsTBox, "driverYearsTBox");
            this.driverYearsTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.driverYearsTBox.Name = "driverYearsTBox";
            // 
            // driverYearsPBox
            // 
            resources.ApplyResources(this.driverYearsPBox, "driverYearsPBox");
            this.driverYearsPBox.Name = "driverYearsPBox";
            this.driverYearsPBox.TabStop = false;
            // 
            // lastNameLbl
            // 
            resources.ApplyResources(this.lastNameLbl, "lastNameLbl");
            this.lastNameLbl.Name = "lastNameLbl";
            // 
            // nameLbl
            // 
            resources.ApplyResources(this.nameLbl, "nameLbl");
            this.nameLbl.Name = "nameLbl";
            // 
            // addDriverBtn
            // 
            resources.ApplyResources(this.addDriverBtn, "addDriverBtn");
            this.addDriverBtn.Name = "addDriverBtn";
            this.addDriverBtn.UseVisualStyleBackColor = true;
            this.addDriverBtn.Click += new System.EventHandler(this.addDriverBtn_Click);
            // 
            // driverNameTBox
            // 
            resources.ApplyResources(this.driverNameTBox, "driverNameTBox");
            this.driverNameTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.driverNameTBox.Name = "driverNameTBox";
            // 
            // driverLastNameTBox
            // 
            resources.ApplyResources(this.driverLastNameTBox, "driverLastNameTBox");
            this.driverLastNameTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.driverLastNameTBox.Name = "driverLastNameTBox";
            // 
            // driverNamePBOx
            // 
            resources.ApplyResources(this.driverNamePBOx, "driverNamePBOx");
            this.driverNamePBOx.Name = "driverNamePBOx";
            this.driverNamePBOx.TabStop = false;
            // 
            // driverLastNamePicBox
            // 
            resources.ApplyResources(this.driverLastNamePicBox, "driverLastNamePicBox");
            this.driverLastNamePicBox.Name = "driverLastNamePicBox";
            this.driverLastNamePicBox.TabStop = false;
            // 
            // driversDGV
            // 
            resources.ApplyResources(this.driversDGV, "driversDGV");
            this.driversDGV.AllowUserToAddRows = false;
            this.driversDGV.AllowUserToDeleteRows = false;
            this.driversDGV.BackgroundColor = System.Drawing.Color.White;
            this.driversDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.driversDGV.Name = "driversDGV";
            this.driversDGV.ReadOnly = true;
            this.driversDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.driversDGV_CellClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DriversForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.driversGBox);
            this.Controls.Add(this.driversDGV);
            this.Name = "DriversForm";
            this.Load += new System.EventHandler(this.DriversForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DriversForm_MouseClick);
            this.driversGBox.ResumeLayout(false);
            this.driversGBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.driverYearsPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverNamePBOx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverLastNamePicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driversDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox driversGBox;
        private System.Windows.Forms.Label yearsLbl;
        private System.Windows.Forms.TextBox driverYearsTBox;
        private System.Windows.Forms.PictureBox driverYearsPBox;
        private System.Windows.Forms.Label lastNameLbl;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Button addDriverBtn;
        private System.Windows.Forms.TextBox driverNameTBox;
        private System.Windows.Forms.TextBox driverLastNameTBox;
        private System.Windows.Forms.PictureBox driverNamePBOx;
        private System.Windows.Forms.PictureBox driverLastNamePicBox;
        private System.Windows.Forms.DataGridView driversDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelBtn;
    }
}