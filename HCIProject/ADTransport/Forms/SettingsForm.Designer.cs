
namespace ADTransport.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.themeGBox = new System.Windows.Forms.GroupBox();
            this.applyThemeBtn = new System.Windows.Forms.Button();
            this.coolThemeBtn = new System.Windows.Forms.RadioButton();
            this.darkThemeBtn = new System.Windows.Forms.RadioButton();
            this.lightThemeBtn = new System.Windows.Forms.RadioButton();
            this.langGBox = new System.Windows.Forms.GroupBox();
            this.applyLangBtn = new System.Windows.Forms.Button();
            this.radioBtnSR = new System.Windows.Forms.RadioButton();
            this.radioBtnUS = new System.Windows.Forms.RadioButton();
            this.themeGBox.SuspendLayout();
            this.langGBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // themeGBox
            // 
            this.themeGBox.Controls.Add(this.applyThemeBtn);
            this.themeGBox.Controls.Add(this.coolThemeBtn);
            this.themeGBox.Controls.Add(this.darkThemeBtn);
            this.themeGBox.Controls.Add(this.lightThemeBtn);
            resources.ApplyResources(this.themeGBox, "themeGBox");
            this.themeGBox.Name = "themeGBox";
            this.themeGBox.TabStop = false;
            // 
            // applyThemeBtn
            // 
            resources.ApplyResources(this.applyThemeBtn, "applyThemeBtn");
            this.applyThemeBtn.Name = "applyThemeBtn";
            this.applyThemeBtn.UseVisualStyleBackColor = true;
            this.applyThemeBtn.Click += new System.EventHandler(this.ApplyThemeBtnClick);
            // 
            // coolThemeBtn
            // 
            resources.ApplyResources(this.coolThemeBtn, "coolThemeBtn");
            this.coolThemeBtn.Name = "coolThemeBtn";
            this.coolThemeBtn.TabStop = true;
            this.coolThemeBtn.UseVisualStyleBackColor = true;
            // 
            // darkThemeBtn
            // 
            resources.ApplyResources(this.darkThemeBtn, "darkThemeBtn");
            this.darkThemeBtn.Name = "darkThemeBtn";
            this.darkThemeBtn.TabStop = true;
            this.darkThemeBtn.UseVisualStyleBackColor = true;
            // 
            // lightThemeBtn
            // 
            resources.ApplyResources(this.lightThemeBtn, "lightThemeBtn");
            this.lightThemeBtn.Name = "lightThemeBtn";
            this.lightThemeBtn.TabStop = true;
            this.lightThemeBtn.UseVisualStyleBackColor = true;
            // 
            // langGBox
            // 
            this.langGBox.Controls.Add(this.applyLangBtn);
            this.langGBox.Controls.Add(this.radioBtnSR);
            this.langGBox.Controls.Add(this.radioBtnUS);
            resources.ApplyResources(this.langGBox, "langGBox");
            this.langGBox.Name = "langGBox";
            this.langGBox.TabStop = false;
            // 
            // applyLangBtn
            // 
            resources.ApplyResources(this.applyLangBtn, "applyLangBtn");
            this.applyLangBtn.Name = "applyLangBtn";
            this.applyLangBtn.UseVisualStyleBackColor = true;
            this.applyLangBtn.Click += new System.EventHandler(this.ApplyLangBtnClick);
            // 
            // radioBtnSR
            // 
            resources.ApplyResources(this.radioBtnSR, "radioBtnSR");
            this.radioBtnSR.Name = "radioBtnSR";
            this.radioBtnSR.TabStop = true;
            this.radioBtnSR.UseVisualStyleBackColor = true;
            // 
            // radioBtnUS
            // 
            resources.ApplyResources(this.radioBtnUS, "radioBtnUS");
            this.radioBtnUS.Name = "radioBtnUS";
            this.radioBtnUS.TabStop = true;
            this.radioBtnUS.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.langGBox);
            this.Controls.Add(this.themeGBox);
            this.Name = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.themeGBox.ResumeLayout(false);
            this.themeGBox.PerformLayout();
            this.langGBox.ResumeLayout(false);
            this.langGBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox themeGBox;
        private System.Windows.Forms.Button applyThemeBtn;
        private System.Windows.Forms.RadioButton coolThemeBtn;
        private System.Windows.Forms.RadioButton darkThemeBtn;
        private System.Windows.Forms.RadioButton lightThemeBtn;
        private System.Windows.Forms.GroupBox langGBox;
        private System.Windows.Forms.Button applyLangBtn;
        private System.Windows.Forms.RadioButton radioBtnSR;
        private System.Windows.Forms.RadioButton radioBtnUS;
    }
}