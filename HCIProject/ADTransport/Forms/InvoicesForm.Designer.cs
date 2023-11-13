
namespace ADTransport.Forms
{
    partial class InvoicesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoicesForm));
            this.ordersDGV = new System.Windows.Forms.DataGridView();
            this.addInvoiceBtn = new System.Windows.Forms.Button();
            this.invoicesDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ordersDGV
            // 
            this.ordersDGV.BackgroundColor = System.Drawing.Color.White;
            this.ordersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.ordersDGV, "ordersDGV");
            this.ordersDGV.Name = "ordersDGV";
            this.ordersDGV.RowTemplate.Height = 24;
            this.ordersDGV.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ordersDGV_RowHeaderMouseClick);
            // 
            // addInvoiceBtn
            // 
            this.addInvoiceBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(4)))));
            resources.ApplyResources(this.addInvoiceBtn, "addInvoiceBtn");
            this.addInvoiceBtn.Name = "addInvoiceBtn";
            this.addInvoiceBtn.UseVisualStyleBackColor = true;
            this.addInvoiceBtn.Click += new System.EventHandler(this.addInvoiceBtn_Click);
            // 
            // invoicesDGV
            // 
            this.invoicesDGV.BackgroundColor = System.Drawing.Color.White;
            this.invoicesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.invoicesDGV, "invoicesDGV");
            this.invoicesDGV.Name = "invoicesDGV";
            this.invoicesDGV.RowTemplate.Height = 24;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // InvoicesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.invoicesDGV);
            this.Controls.Add(this.addInvoiceBtn);
            this.Controls.Add(this.ordersDGV);
            this.Name = "InvoicesForm";
            this.Load += new System.EventHandler(this.InvoicesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordersDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicesDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ordersDGV;
        private System.Windows.Forms.Button addInvoiceBtn;
        private System.Windows.Forms.DataGridView invoicesDGV;
        private System.Windows.Forms.Label label1;
    }
}