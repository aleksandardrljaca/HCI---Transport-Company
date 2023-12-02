
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.lbltsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lbltsDGV_CellClick);
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
            this.driversDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.driversDGV_CellClick);
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
            // addLblt
            // 
            resources.ApplyResources(this.addLblt, "addLblt");
            this.addLblt.Name = "addLblt";
            this.addLblt.UseVisualStyleBackColor = true;
            this.addLblt.Click += new System.EventHandler(this.addLblt_Click);
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // LiabilitiesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addLblt);
            this.Controls.Add(this.vehiclesDGV);
            this.Controls.Add(this.driversDGV);
            this.Controls.Add(this.lbltsDGV);
            this.Name = "LiabilitiesForm";
            this.Load += new System.EventHandler(this.LiabilitiesForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LiabilitiesForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.lbltsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driversDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclesDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView lbltsDGV;
        private System.Windows.Forms.DataGridView driversDGV;
        private System.Windows.Forms.DataGridView vehiclesDGV;
        private System.Windows.Forms.Button addLblt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}