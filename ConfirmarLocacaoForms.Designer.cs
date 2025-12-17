namespace Projeto_Final_Prog_III
{
    partial class ConfirmarLocacaoForms
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
            this.bntCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblData2 = new System.Windows.Forms.Label();
            this.dtpDevolucao = new System.Windows.Forms.DateTimePicker();
            this.lblData = new System.Windows.Forms.Label();
            this.dtpLocacao = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // bntCancelar
            // 
            this.bntCancelar.Location = new System.Drawing.Point(167, 291);
            this.bntCancelar.Name = "bntCancelar";
            this.bntCancelar.Size = new System.Drawing.Size(104, 56);
            this.bntCancelar.TabIndex = 69;
            this.bntCancelar.Text = "Cancelar Locação";
            this.bntCancelar.UseVisualStyleBackColor = true;
            this.bntCancelar.Click += new System.EventHandler(this.bntCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(57, 291);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(104, 56);
            this.btnConfirmar.TabIndex = 68;
            this.btnConfirmar.Text = "Confirmar Locação";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(12, 200);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(110, 13);
            this.lblValor.TabIndex = 66;
            this.lblValor.Text = "Valor do Aluguel (R$):";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(12, 20);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(80, 13);
            this.lblNome.TabIndex = 65;
            this.lblNome.Text = "Nome do Filme:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(15, 36);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(303, 20);
            this.txtNome.TabIndex = 64;
            // 
            // lblData2
            // 
            this.lblData2.AutoSize = true;
            this.lblData2.Location = new System.Drawing.Point(12, 139);
            this.lblData2.Name = "lblData2";
            this.lblData2.Size = new System.Drawing.Size(194, 13);
            this.lblData2.TabIndex = 63;
            this.lblData2.Text = "Escolha a Data da Devolução Prevista:";
            // 
            // dtpDevolucao
            // 
            this.dtpDevolucao.Location = new System.Drawing.Point(15, 155);
            this.dtpDevolucao.Name = "dtpDevolucao";
            this.dtpDevolucao.Size = new System.Drawing.Size(303, 20);
            this.dtpDevolucao.TabIndex = 62;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(12, 76);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(143, 13);
            this.lblData.TabIndex = 61;
            this.lblData.Text = "Escolha a Data da Locação:";
            // 
            // dtpLocacao
            // 
            this.dtpLocacao.Location = new System.Drawing.Point(15, 92);
            this.dtpLocacao.Name = "dtpLocacao";
            this.dtpLocacao.Size = new System.Drawing.Size(303, 20);
            this.dtpLocacao.TabIndex = 60;
            // 
            // ConfirmarLocacaoForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 419);
            this.Controls.Add(this.bntCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblData2);
            this.Controls.Add(this.dtpDevolucao);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.dtpLocacao);
            this.Name = "ConfirmarLocacaoForms";
            this.Text = "ConfirmarLocacaoForms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblData2;
        private System.Windows.Forms.DateTimePicker dtpDevolucao;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.DateTimePicker dtpLocacao;
    }
}