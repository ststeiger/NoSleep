namespace NoSleep
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStartSimulate = new System.Windows.Forms.Button();
            this.niTaskBarIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartSimulate
            // 
            this.btnStartSimulate.Location = new System.Drawing.Point(135, 12);
            this.btnStartSimulate.Name = "btnStartSimulate";
            this.btnStartSimulate.Size = new System.Drawing.Size(75, 23);
            this.btnStartSimulate.TabIndex = 0;
            this.btnStartSimulate.Text = "Start";
            this.btnStartSimulate.UseVisualStyleBackColor = true;
            this.btnStartSimulate.Click += new System.EventHandler(this.btnStartSimulate_Click);
            // 
            // niTaskBarIcon
            // 
            this.niTaskBarIcon.Text = "notifyIcon1";
            this.niTaskBarIcon.Visible = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 78);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 151);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartSimulate);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NoSleep / NoLock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartSimulate;
        private System.Windows.Forms.NotifyIcon niTaskBarIcon;
        private System.Windows.Forms.Label label1;
    }
}

