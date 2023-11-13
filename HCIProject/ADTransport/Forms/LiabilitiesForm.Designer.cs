
namespace ADTransport.Forms
{
    partial class LiabilitiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiabilitiesForm));
            this.lbltsDGV = new System.Windows.Forms.DataGridView();
            this.driversDGV = new System.Windows.Forms.DataGridView();
            this.vehiclesDGV = new System.Windows.Forms.DataGridView();
            this.addLblt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lbltsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driversDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltsDGV
            // 
            this.lbltsDGV.AllowUserToAddRows = false;
            this.lbltsDGV.AllowUserToDeleteRows = false;
            this.lbltsDGV.BackgroundColor = System.Drawing.Color.White;
            this.lbltsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.lbltsDGV, "lbltsDGV");
            this.lbltsDGV.Name = "lbltsDGV";
            this.lbltsDGV.ReadOnly = true;
            // 
            // driversDGV
            // 
            this.driversDGV.AllowUserToAddRows = false;
            this.driversDGV.AllowUserToDeleteRows = false;
            this.driversDGV.BackgroundColor = System.Drawing.Color.White;
            this.driversDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.driversDGV, "driversDGV");
            this.driversDGV.Name = "driversDGV";
            this.driversDGV.ReadOnly = true;
            this.driversDGV.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.driversDGV_RowHeaderMouseClick);
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
            this.vehiclesDGV.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.vehiclesDGV_RowHeaderMouseClick);
            // 
            // addLblt
            // 
            resources.ApplyResources(this.addLblt, "addLblt");
            this.addLblt.Name = "addLblt";
            this.addLblt.UseVisualStyleBackColor = true;
            this.addLblt.Click += new System.EventHandler(this.addLblt_Click);
            // 
            // LiabilitiesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addLblt);
            this.Controls.Add(this.vehiclesDGV);
            this.Controls.Add(this.driversDGV);
            this.Controls.Add(this.lbltsDGV);
            this.Name = "LiabilitiesForm";
            this.Load += new System.EventHandler(this.LiabilitiesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lbltsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driversDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView lbltsDGV;
        private System.Windows.Forms.DataGridView driversDGV;
        private System.Windows.Forms.DataGridView vehiclesDGV;
        private System.Windows.Forms.Button addLblt;
    }
}