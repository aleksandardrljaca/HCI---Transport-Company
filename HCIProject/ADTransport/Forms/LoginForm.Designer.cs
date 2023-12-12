
namespace ADTransport.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUS = new System.Windows.Forms.LinkLabel();
            this.lblSR = new System.Windows.Forms.LinkLabel();
            this.picBoxUS = new System.Windows.Forms.PictureBox();
            this.picBoxSR = new System.Windows.Forms.PictureBox();
            this.logoPicBox = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.exitPicBox = new System.Windows.Forms.PictureBox();
            this.accntPicBox = new System.Windows.Forms.PictureBox();
            this.usrNamePicBox = new System.Windows.Forms.PictureBox();
            this.pswdPicBox = new System.Windows.Forms.PictureBox();
            this.usrNameTxtBox = new System.Windows.Forms.TextBox();
            this.pswdTxtBox = new System.Windows.Forms.TextBox();
            this.usrNameLbl = new System.Windows.Forms.Label();
            this.pswdLbl = new System.Windows.Forms.Label();
            this.logInBtn = new System.Windows.Forms.Button();
            this.loginLbl = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accntPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usrNamePicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pswdPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
            this.panel2.Controls.Add(this.lblUS);
            this.panel2.Controls.Add(this.lblSR);
            this.panel2.Controls.Add(this.picBoxUS);
            this.panel2.Controls.Add(this.picBoxSR);
            this.panel2.Controls.Add(this.logoPicBox);
            this.panel2.Name = "panel2";
            // 
            // lblUS
            // 
            resources.ApplyResources(this.lblUS, "lblUS");
            this.lblUS.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(4)))));
            this.lblUS.Name = "lblUS";
            this.lblUS.TabStop = true;
            this.lblUS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblUS_LinkClicked);
            // 
            // lblSR
            // 
            resources.ApplyResources(this.lblSR, "lblSR");
            this.lblSR.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(4)))));
            this.lblSR.Name = "lblSR";
            this.lblSR.TabStop = true;
            this.lblSR.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblSR_LinkClicked);
            // 
            // picBoxUS
            // 
            resources.ApplyResources(this.picBoxUS, "picBoxUS");
            this.picBoxUS.Name = "picBoxUS";
            this.picBoxUS.TabStop = false;
            // 
            // picBoxSR
            // 
            resources.ApplyResources(this.picBoxSR, "picBoxSR");
            this.picBoxSR.Name = "picBoxSR";
            this.picBoxSR.TabStop = false;
            // 
            // logoPicBox
            // 
            resources.ApplyResources(this.logoPicBox, "logoPicBox");
            this.logoPicBox.Name = "logoPicBox";
            this.logoPicBox.TabStop = false;
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
            this.panel3.Controls.Add(this.exitPicBox);
            this.panel3.Name = "panel3";
            // 
            // exitPicBox
            // 
            resources.ApplyResources(this.exitPicBox, "exitPicBox");
            this.exitPicBox.Name = "exitPicBox";
            this.exitPicBox.TabStop = false;
            this.exitPicBox.Click += new System.EventHandler(this.ExitPicBox_Click);
            // 
            // accntPicBox
            // 
            resources.ApplyResources(this.accntPicBox, "accntPicBox");
            this.accntPicBox.Name = "accntPicBox";
            this.accntPicBox.TabStop = false;
            // 
            // usrNamePicBox
            // 
            resources.ApplyResources(this.usrNamePicBox, "usrNamePicBox");
            this.usrNamePicBox.BackColor = System.Drawing.Color.Gainsboro;
            this.usrNamePicBox.Name = "usrNamePicBox";
            this.usrNamePicBox.TabStop = false;
            this.usrNamePicBox.Click += new System.EventHandler(this.txtBoxFocus);
            // 
            // pswdPicBox
            // 
            resources.ApplyResources(this.pswdPicBox, "pswdPicBox");
            this.pswdPicBox.BackColor = System.Drawing.Color.Gainsboro;
            this.pswdPicBox.Name = "pswdPicBox";
            this.pswdPicBox.TabStop = false;
            this.pswdPicBox.Click += new System.EventHandler(this.txtBoxFocus);
            // 
            // usrNameTxtBox
            // 
            resources.ApplyResources(this.usrNameTxtBox, "usrNameTxtBox");
            this.usrNameTxtBox.BackColor = System.Drawing.Color.Gainsboro;
            this.usrNameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usrNameTxtBox.Name = "usrNameTxtBox";
            this.usrNameTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usrNameTxtBox_KeyPress);
            // 
            // pswdTxtBox
            // 
            resources.ApplyResources(this.pswdTxtBox, "pswdTxtBox");
            this.pswdTxtBox.BackColor = System.Drawing.Color.Gainsboro;
            this.pswdTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pswdTxtBox.Name = "pswdTxtBox";
            this.pswdTxtBox.UseSystemPasswordChar = true;
            this.pswdTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pswdTxtBox_KeyPress);
            // 
            // usrNameLbl
            // 
            resources.ApplyResources(this.usrNameLbl, "usrNameLbl");
            this.usrNameLbl.BackColor = System.Drawing.Color.Gainsboro;
            this.usrNameLbl.Name = "usrNameLbl";
            this.usrNameLbl.Click += new System.EventHandler(this.usrNameLbl_Click);
            // 
            // pswdLbl
            // 
            resources.ApplyResources(this.pswdLbl, "pswdLbl");
            this.pswdLbl.BackColor = System.Drawing.Color.Gainsboro;
            this.pswdLbl.Name = "pswdLbl";
            this.pswdLbl.Click += new System.EventHandler(this.pswdLbl_Click);
            // 
            // logInBtn
            // 
            resources.ApplyResources(this.logInBtn, "logInBtn");
            this.logInBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
            this.logInBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(4)))));
            this.logInBtn.Name = "logInBtn";
            this.logInBtn.UseVisualStyleBackColor = false;
            this.logInBtn.Click += new System.EventHandler(this.LogInBtnClick);
            // 
            // loginLbl
            // 
            resources.ApplyResources(this.loginLbl, "loginLbl");
            this.loginLbl.Name = "loginLbl";
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pswdTxtBox);
            this.Controls.Add(this.usrNameTxtBox);
            this.Controls.Add(this.loginLbl);
            this.Controls.Add(this.logInBtn);
            this.Controls.Add(this.pswdLbl);
            this.Controls.Add(this.usrNameLbl);
            this.Controls.Add(this.pswdPicBox);
            this.Controls.Add(this.usrNamePicBox);
            this.Controls.Add(this.accntPicBox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accntPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usrNamePicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pswdPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox exitPicBox;
        private System.Windows.Forms.PictureBox logoPicBox;
        private System.Windows.Forms.LinkLabel lblUS;
        private System.Windows.Forms.LinkLabel lblSR;
        private System.Windows.Forms.PictureBox picBoxUS;
        private System.Windows.Forms.PictureBox picBoxSR;
        private System.Windows.Forms.PictureBox accntPicBox;
        private System.Windows.Forms.PictureBox usrNamePicBox;
        private System.Windows.Forms.PictureBox pswdPicBox;
        private System.Windows.Forms.TextBox usrNameTxtBox;
        private System.Windows.Forms.TextBox pswdTxtBox;
        private System.Windows.Forms.Label usrNameLbl;
        private System.Windows.Forms.Label pswdLbl;
        private System.Windows.Forms.Button logInBtn;
        private System.Windows.Forms.Label loginLbl;
    }
}