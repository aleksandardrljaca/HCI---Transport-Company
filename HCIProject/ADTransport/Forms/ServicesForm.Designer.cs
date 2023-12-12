
namespace ADTransport.Forms
{
    partial class ServicesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicesForm));
            this.serviceGBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.priceLbl = new System.Windows.Forms.Label();
            this.serviceTypeLbl = new System.Windows.Forms.Label();
            this.addServiceBtn = new System.Windows.Forms.Button();
            this.serviceTypeTBox = new System.Windows.Forms.TextBox();
            this.priceTBox = new System.Windows.Forms.TextBox();
            this.typePBOx = new System.Windows.Forms.PictureBox();
            this.pricePicBox = new System.Windows.Forms.PictureBox();
            this.servicesDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.serviceGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typePBOx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pricePicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // serviceGBox
            // 
            resources.ApplyResources(this.serviceGBox, "serviceGBox");
            this.serviceGBox.BackColor = System.Drawing.Color.Transparent;
            this.serviceGBox.Controls.Add(this.button1);
            this.serviceGBox.Controls.Add(this.priceLbl);
            this.serviceGBox.Controls.Add(this.serviceTypeLbl);
            this.serviceGBox.Controls.Add(this.addServiceBtn);
            this.serviceGBox.Controls.Add(this.serviceTypeTBox);
            this.serviceGBox.Controls.Add(this.priceTBox);
            this.serviceGBox.Controls.Add(this.typePBOx);
            this.serviceGBox.Controls.Add(this.pricePicBox);
            this.serviceGBox.Name = "serviceGBox";
            this.serviceGBox.TabStop = false;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // priceLbl
            // 
            resources.ApplyResources(this.priceLbl, "priceLbl");
            this.priceLbl.Name = "priceLbl";
            // 
            // serviceTypeLbl
            // 
            resources.ApplyResources(this.serviceTypeLbl, "serviceTypeLbl");
            this.serviceTypeLbl.Name = "serviceTypeLbl";
            // 
            // addServiceBtn
            // 
            resources.ApplyResources(this.addServiceBtn, "addServiceBtn");
            this.addServiceBtn.Name = "addServiceBtn";
            this.addServiceBtn.UseVisualStyleBackColor = true;
            this.addServiceBtn.Click += new System.EventHandler(this.addServiceBtn_Click);
            // 
            // serviceTypeTBox
            // 
            resources.ApplyResources(this.serviceTypeTBox, "serviceTypeTBox");
            this.serviceTypeTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serviceTypeTBox.Name = "serviceTypeTBox";
            // 
            // priceTBox
            // 
            resources.ApplyResources(this.priceTBox, "priceTBox");
            this.priceTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.priceTBox.Name = "priceTBox";
            // 
            // typePBOx
            // 
            resources.ApplyResources(this.typePBOx, "typePBOx");
            this.typePBOx.Name = "typePBOx";
            this.typePBOx.TabStop = false;
            // 
            // pricePicBox
            // 
            resources.ApplyResources(this.pricePicBox, "pricePicBox");
            this.pricePicBox.Name = "pricePicBox";
            this.pricePicBox.TabStop = false;
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ServicesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serviceGBox);
            this.Controls.Add(this.servicesDGV);
            this.Name = "ServicesForm";
            this.Load += new System.EventHandler(this.Services_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ServicesForm_MouseClick);
            this.serviceGBox.ResumeLayout(false);
            this.serviceGBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typePBOx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pricePicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox serviceGBox;
        private System.Windows.Forms.Label priceLbl;
        private System.Windows.Forms.Label serviceTypeLbl;
        private System.Windows.Forms.Button addServiceBtn;
        private System.Windows.Forms.TextBox serviceTypeTBox;
        private System.Windows.Forms.TextBox priceTBox;
        private System.Windows.Forms.PictureBox typePBOx;
        private System.Windows.Forms.PictureBox pricePicBox;
        private System.Windows.Forms.DataGridView servicesDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}