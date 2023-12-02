
namespace ADTransport.Forms
{
    partial class MyAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyAccountForm));
            this.askBox = new System.Windows.Forms.CheckBox();
            this.usrTBox = new System.Windows.Forms.TextBox();
            this.pswdTBox = new System.Windows.Forms.TextBox();
            this.crdntlsGBox = new System.Windows.Forms.GroupBox();
            this.reTypePswdLbl = new System.Windows.Forms.Label();
            this.rePswdTBox = new System.Windows.Forms.TextBox();
            this.rePswdPBox = new System.Windows.Forms.PictureBox();
            this.pswdLbl = new System.Windows.Forms.Label();
            this.usrNameLbl = new System.Windows.Forms.Label();
            this.changeCrdntlsBtn = new System.Windows.Forms.Button();
            this.usrNmPBOx = new System.Windows.Forms.PictureBox();
            this.pswdPicBox = new System.Windows.Forms.PictureBox();
            this.crdntlsGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rePswdPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usrNmPBOx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pswdPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // askBox
            // 
            resources.ApplyResources(this.askBox, "askBox");
            this.askBox.Name = "askBox";
            this.askBox.UseVisualStyleBackColor = true;
            this.askBox.Click += new System.EventHandler(this.askBox_Click);
            // 
            // usrTBox
            // 
            this.usrTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.usrTBox, "usrTBox");
            this.usrTBox.Name = "usrTBox";
            // 
            // pswdTBox
            // 
            this.pswdTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pswdTBox, "pswdTBox");
            this.pswdTBox.Name = "pswdTBox";
            this.pswdTBox.UseSystemPasswordChar = true;
            // 
            // crdntlsGBox
            // 
            this.crdntlsGBox.BackColor = System.Drawing.Color.White;
            this.crdntlsGBox.Controls.Add(this.reTypePswdLbl);
            this.crdntlsGBox.Controls.Add(this.rePswdTBox);
            this.crdntlsGBox.Controls.Add(this.rePswdPBox);
            this.crdntlsGBox.Controls.Add(this.pswdLbl);
            this.crdntlsGBox.Controls.Add(this.usrNameLbl);
            this.crdntlsGBox.Controls.Add(this.changeCrdntlsBtn);
            this.crdntlsGBox.Controls.Add(this.usrTBox);
            this.crdntlsGBox.Controls.Add(this.pswdTBox);
            this.crdntlsGBox.Controls.Add(this.usrNmPBOx);
            this.crdntlsGBox.Controls.Add(this.pswdPicBox);
            resources.ApplyResources(this.crdntlsGBox, "crdntlsGBox");
            this.crdntlsGBox.Name = "crdntlsGBox";
            this.crdntlsGBox.TabStop = false;
            // 
            // reTypePswdLbl
            // 
            resources.ApplyResources(this.reTypePswdLbl, "reTypePswdLbl");
            this.reTypePswdLbl.Name = "reTypePswdLbl";
            // 
            // rePswdTBox
            // 
            this.rePswdTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.rePswdTBox, "rePswdTBox");
            this.rePswdTBox.Name = "rePswdTBox";
            this.rePswdTBox.UseSystemPasswordChar = true;
            // 
            // rePswdPBox
            // 
            resources.ApplyResources(this.rePswdPBox, "rePswdPBox");
            this.rePswdPBox.Name = "rePswdPBox";
            this.rePswdPBox.TabStop = false;
            this.rePswdPBox.Click += new System.EventHandler(this.txtBoxFocus);
            // 
            // pswdLbl
            // 
            resources.ApplyResources(this.pswdLbl, "pswdLbl");
            this.pswdLbl.Name = "pswdLbl";
            // 
            // usrNameLbl
            // 
            resources.ApplyResources(this.usrNameLbl, "usrNameLbl");
            this.usrNameLbl.Name = "usrNameLbl";
            // 
            // changeCrdntlsBtn
            // 
            resources.ApplyResources(this.changeCrdntlsBtn, "changeCrdntlsBtn");
            this.changeCrdntlsBtn.Name = "changeCrdntlsBtn";
            this.changeCrdntlsBtn.UseVisualStyleBackColor = true;
            this.changeCrdntlsBtn.Click += new System.EventHandler(this.changeCrdntlsBtn_Click);
            // 
            // usrNmPBOx
            // 
            resources.ApplyResources(this.usrNmPBOx, "usrNmPBOx");
            this.usrNmPBOx.Name = "usrNmPBOx";
            this.usrNmPBOx.TabStop = false;
            this.usrNmPBOx.Click += new System.EventHandler(this.txtBoxFocus);
            // 
            // pswdPicBox
            // 
            resources.ApplyResources(this.pswdPicBox, "pswdPicBox");
            this.pswdPicBox.Name = "pswdPicBox";
            this.pswdPicBox.TabStop = false;
            this.pswdPicBox.Click += new System.EventHandler(this.txtBoxFocus);
            // 
            // MyAccountForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.crdntlsGBox);
            this.Controls.Add(this.askBox);
            this.Name = "MyAccountForm";
            this.Load += new System.EventHandler(this.MyAccountForm_Load);
            this.crdntlsGBox.ResumeLayout(false);
            this.crdntlsGBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rePswdPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usrNmPBOx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pswdPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox askBox;
        private System.Windows.Forms.TextBox usrTBox;
        private System.Windows.Forms.TextBox pswdTBox;
        private System.Windows.Forms.GroupBox crdntlsGBox;
        private System.Windows.Forms.Button changeCrdntlsBtn;
        private System.Windows.Forms.Label pswdLbl;
        private System.Windows.Forms.Label usrNameLbl;
        private System.Windows.Forms.PictureBox usrNmPBOx;
        private System.Windows.Forms.PictureBox pswdPicBox;
        private System.Windows.Forms.Label reTypePswdLbl;
        private System.Windows.Forms.TextBox rePswdTBox;
        private System.Windows.Forms.PictureBox rePswdPBox;
    }
}