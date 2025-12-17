namespace Projeto_Final_Prog_III
{
    partial class BackupServiceForms
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
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnFazer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(207, 94);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(104, 56);
            this.btnRestaurar.TabIndex = 46;
            this.btnRestaurar.Text = "Restaurar Backup";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnFazer
            // 
            this.btnFazer.Location = new System.Drawing.Point(97, 94);
            this.btnFazer.Name = "btnFazer";
            this.btnFazer.Size = new System.Drawing.Size(104, 56);
            this.btnFazer.TabIndex = 45;
            this.btnFazer.Text = "Realizar Backup";
            this.btnFazer.UseVisualStyleBackColor = true;
            this.btnFazer.Click += new System.EventHandler(this.btnFazer_Click);
            // 
            // BackupServiceForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 242);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.btnFazer);
            this.Name = "BackupServiceForms";
            this.Text = "BackupServiceForms";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button btnFazer;
    }
}