namespace Projeto_Final_Prog_III
{
    partial class ItemLocacaoForms
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
            this.lblLista = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.MaskedTextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblIdFilme = new System.Windows.Forms.Label();
            this.txtIdFilme = new System.Windows.Forms.TextBox();
            this.lbIdLocacao = new System.Windows.Forms.Label();
            this.txtIdLocacao = new System.Windows.Forms.TextBox();
            this.bntAtualizar = new System.Windows.Forms.Button();
            this.bntLimparCampos = new System.Windows.Forms.Button();
            this.bntBuscar = new System.Windows.Forms.Button();
            this.bntExcluir = new System.Windows.Forms.Button();
            this.bntEditar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.dgvItensLocacao = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensLocacao)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLista
            // 
            this.lblLista.AutoSize = true;
            this.lblLista.Location = new System.Drawing.Point(329, 11);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(117, 13);
            this.lblLista.TabIndex = 92;
            this.lblLista.Text = "Lista de Itens Locados:";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(12, 142);
            this.txtValor.Mask = "00,00";
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(303, 20);
            this.txtValor.TabIndex = 91;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(9, 126);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(110, 13);
            this.lblValor.TabIndex = 90;
            this.lblValor.Text = "Valor do Aluguel (R$):";
            // 
            // lblIdFilme
            // 
            this.lblIdFilme.AutoSize = true;
            this.lblIdFilme.Location = new System.Drawing.Point(-67, 77);
            this.lblIdFilme.Name = "lblIdFilme";
            this.lblIdFilme.Size = new System.Drawing.Size(63, 13);
            this.lblIdFilme.TabIndex = 89;
            this.lblIdFilme.Text = "ID do Filme:";
            // 
            // txtIdFilme
            // 
            this.txtIdFilme.Location = new System.Drawing.Point(12, 84);
            this.txtIdFilme.Name = "txtIdFilme";
            this.txtIdFilme.Size = new System.Drawing.Size(303, 20);
            this.txtIdFilme.TabIndex = 88;
            // 
            // lbIdLocacao
            // 
            this.lbIdLocacao.AutoSize = true;
            this.lbIdLocacao.Location = new System.Drawing.Point(9, 11);
            this.lbIdLocacao.Name = "lbIdLocacao";
            this.lbIdLocacao.Size = new System.Drawing.Size(81, 13);
            this.lbIdLocacao.TabIndex = 87;
            this.lbIdLocacao.Text = "ID da Locação:";
            // 
            // txtIdLocacao
            // 
            this.txtIdLocacao.Location = new System.Drawing.Point(12, 27);
            this.txtIdLocacao.Name = "txtIdLocacao";
            this.txtIdLocacao.Size = new System.Drawing.Size(303, 20);
            this.txtIdLocacao.TabIndex = 86;
            // 
            // bntAtualizar
            // 
            this.bntAtualizar.Location = new System.Drawing.Point(565, 366);
            this.bntAtualizar.Name = "bntAtualizar";
            this.bntAtualizar.Size = new System.Drawing.Size(104, 56);
            this.bntAtualizar.TabIndex = 85;
            this.bntAtualizar.Text = "Atualizar Lista Filmes Alugados";
            this.bntAtualizar.UseVisualStyleBackColor = true;
            this.bntAtualizar.Click += new System.EventHandler(this.bntAtualizar_Click);
            // 
            // bntLimparCampos
            // 
            this.bntLimparCampos.Location = new System.Drawing.Point(455, 366);
            this.bntLimparCampos.Name = "bntLimparCampos";
            this.bntLimparCampos.Size = new System.Drawing.Size(104, 56);
            this.bntLimparCampos.TabIndex = 84;
            this.bntLimparCampos.Text = "Limpar Campos";
            this.bntLimparCampos.UseVisualStyleBackColor = true;
            this.bntLimparCampos.Click += new System.EventHandler(this.bntLimparCampos_Click);
            // 
            // bntBuscar
            // 
            this.bntBuscar.Location = new System.Drawing.Point(345, 366);
            this.bntBuscar.Name = "bntBuscar";
            this.bntBuscar.Size = new System.Drawing.Size(104, 56);
            this.bntBuscar.TabIndex = 83;
            this.bntBuscar.Text = "Buscar Filme";
            this.bntBuscar.UseVisualStyleBackColor = true;
            this.bntBuscar.Click += new System.EventHandler(this.bntBuscar_Click);
            // 
            // bntExcluir
            // 
            this.bntExcluir.Location = new System.Drawing.Point(235, 366);
            this.bntExcluir.Name = "bntExcluir";
            this.bntExcluir.Size = new System.Drawing.Size(104, 56);
            this.bntExcluir.TabIndex = 82;
            this.bntExcluir.Text = "Excluir Item de Locação";
            this.bntExcluir.UseVisualStyleBackColor = true;
            this.bntExcluir.Click += new System.EventHandler(this.bntExcluir_Click);
            // 
            // bntEditar
            // 
            this.bntEditar.Location = new System.Drawing.Point(125, 366);
            this.bntEditar.Name = "bntEditar";
            this.bntEditar.Size = new System.Drawing.Size(104, 56);
            this.bntEditar.TabIndex = 81;
            this.bntEditar.Text = "\tEditar Item da Locação";
            this.bntEditar.UseVisualStyleBackColor = true;
            this.bntEditar.Click += new System.EventHandler(this.bntEditar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(15, 366);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(104, 56);
            this.btnAdicionar.TabIndex = 80;
            this.btnAdicionar.Text = "Adicionar Filme à Locação";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // dgvItensLocacao
            // 
            this.dgvItensLocacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensLocacao.Location = new System.Drawing.Point(332, 27);
            this.dgvItensLocacao.Name = "dgvItensLocacao";
            this.dgvItensLocacao.Size = new System.Drawing.Size(611, 324);
            this.dgvItensLocacao.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "ID do Filme:";
            // 
            // ItemLocacaoForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 445);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblIdFilme);
            this.Controls.Add(this.txtIdFilme);
            this.Controls.Add(this.lbIdLocacao);
            this.Controls.Add(this.txtIdLocacao);
            this.Controls.Add(this.bntAtualizar);
            this.Controls.Add(this.bntLimparCampos);
            this.Controls.Add(this.bntBuscar);
            this.Controls.Add(this.bntExcluir);
            this.Controls.Add(this.bntEditar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dgvItensLocacao);
            this.Name = "ItemLocacaoForms";
            this.Text = "ItemLocacaoForms";
            this.Load += new System.EventHandler(this.ItemLocacaoForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensLocacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.MaskedTextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblIdFilme;
        private System.Windows.Forms.TextBox txtIdFilme;
        private System.Windows.Forms.Label lbIdLocacao;
        private System.Windows.Forms.TextBox txtIdLocacao;
        private System.Windows.Forms.Button bntAtualizar;
        private System.Windows.Forms.Button bntLimparCampos;
        private System.Windows.Forms.Button bntBuscar;
        private System.Windows.Forms.Button bntExcluir;
        private System.Windows.Forms.Button bntEditar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.DataGridView dgvItensLocacao;
        private System.Windows.Forms.Label label1;
    }
}