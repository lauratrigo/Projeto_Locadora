namespace Projeto_Final_Prog_III
{
    partial class LocacaoForms
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
            this.lblData2 = new System.Windows.Forms.Label();
            this.dtpDevolucao = new System.Windows.Forms.DateTimePicker();
            this.lblData = new System.Windows.Forms.Label();
            this.dtpLocacao = new System.Windows.Forms.DateTimePicker();
            this.dgvLocacoes = new System.Windows.Forms.DataGridView();
            this.bntAtualizar = new System.Windows.Forms.Button();
            this.bntLimparCampos = new System.Windows.Forms.Button();
            this.bntBuscar = new System.Windows.Forms.Button();
            this.bntExcluir = new System.Windows.Forms.Button();
            this.bntEditar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLista
            // 
            this.lblLista.AutoSize = true;
            this.lblLista.Location = new System.Drawing.Point(330, 15);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(97, 13);
            this.lblLista.TabIndex = 92;
            this.lblLista.Text = "Lista de Locações:";
            // 
            // lblData2
            // 
            this.lblData2.AutoSize = true;
            this.lblData2.Location = new System.Drawing.Point(13, 132);
            this.lblData2.Name = "lblData2";
            this.lblData2.Size = new System.Drawing.Size(194, 13);
            this.lblData2.TabIndex = 91;
            this.lblData2.Text = "Escolha a Data da Devolução Prevista:";
            // 
            // dtpDevolucao
            // 
            this.dtpDevolucao.Location = new System.Drawing.Point(16, 148);
            this.dtpDevolucao.Name = "dtpDevolucao";
            this.dtpDevolucao.Size = new System.Drawing.Size(267, 20);
            this.dtpDevolucao.TabIndex = 90;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(13, 69);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(143, 13);
            this.lblData.TabIndex = 89;
            this.lblData.Text = "Escolha a Data da Locação:";
            // 
            // dtpLocacao
            // 
            this.dtpLocacao.Location = new System.Drawing.Point(16, 85);
            this.dtpLocacao.Name = "dtpLocacao";
            this.dtpLocacao.Size = new System.Drawing.Size(267, 20);
            this.dtpLocacao.TabIndex = 88;
            // 
            // dgvLocacoes
            // 
            this.dgvLocacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocacoes.Location = new System.Drawing.Point(333, 31);
            this.dgvLocacoes.Name = "dgvLocacoes";
            this.dgvLocacoes.Size = new System.Drawing.Size(611, 324);
            this.dgvLocacoes.TabIndex = 87;
            // 
            // bntAtualizar
            // 
            this.bntAtualizar.Location = new System.Drawing.Point(566, 371);
            this.bntAtualizar.Name = "bntAtualizar";
            this.bntAtualizar.Size = new System.Drawing.Size(104, 56);
            this.bntAtualizar.TabIndex = 86;
            this.bntAtualizar.Text = "Atualizar Lista de Locações";
            this.bntAtualizar.UseVisualStyleBackColor = true;
            this.bntAtualizar.Click += new System.EventHandler(this.bntAtualizar_Click);
            // 
            // bntLimparCampos
            // 
            this.bntLimparCampos.Location = new System.Drawing.Point(456, 371);
            this.bntLimparCampos.Name = "bntLimparCampos";
            this.bntLimparCampos.Size = new System.Drawing.Size(104, 56);
            this.bntLimparCampos.TabIndex = 85;
            this.bntLimparCampos.Text = "Limpar Campos";
            this.bntLimparCampos.UseVisualStyleBackColor = true;
            this.bntLimparCampos.Click += new System.EventHandler(this.bntLimparCampos_Click);
            // 
            // bntBuscar
            // 
            this.bntBuscar.Location = new System.Drawing.Point(346, 371);
            this.bntBuscar.Name = "bntBuscar";
            this.bntBuscar.Size = new System.Drawing.Size(104, 56);
            this.bntBuscar.TabIndex = 84;
            this.bntBuscar.Text = "Buscar Locação";
            this.bntBuscar.UseVisualStyleBackColor = true;
            this.bntBuscar.Click += new System.EventHandler(this.bntBuscar_Click);
            // 
            // bntExcluir
            // 
            this.bntExcluir.Location = new System.Drawing.Point(236, 371);
            this.bntExcluir.Name = "bntExcluir";
            this.bntExcluir.Size = new System.Drawing.Size(104, 56);
            this.bntExcluir.TabIndex = 83;
            this.bntExcluir.Text = "Excluir Locação";
            this.bntExcluir.UseVisualStyleBackColor = true;
            this.bntExcluir.Click += new System.EventHandler(this.bntExcluir_Click);
            // 
            // bntEditar
            // 
            this.bntEditar.Location = new System.Drawing.Point(126, 371);
            this.bntEditar.Name = "bntEditar";
            this.bntEditar.Size = new System.Drawing.Size(104, 56);
            this.bntEditar.TabIndex = 82;
            this.bntEditar.Text = "Editar uma Locação Existente ";
            this.bntEditar.UseVisualStyleBackColor = true;
            this.bntEditar.Click += new System.EventHandler(this.bntEditar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(16, 371);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(104, 56);
            this.btnAdicionar.TabIndex = 81;
            this.btnAdicionar.Text = "Adicionar Nova Locação";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(16, 31);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(303, 20);
            this.txtPesquisar.TabIndex = 80;
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Location = new System.Drawing.Point(13, 15);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(120, 13);
            this.lblPesquisar.TabIndex = 79;
            this.lblPesquisar.Text = "Digite o ID da Locação:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(676, 371);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(104, 56);
            this.btnSalvar.TabIndex = 93;
            this.btnSalvar.Text = "Salvar Locação Editada";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // LocacaoForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 450);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.lblData2);
            this.Controls.Add(this.dtpDevolucao);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.dtpLocacao);
            this.Controls.Add(this.dgvLocacoes);
            this.Controls.Add(this.bntAtualizar);
            this.Controls.Add(this.bntLimparCampos);
            this.Controls.Add(this.bntBuscar);
            this.Controls.Add(this.bntExcluir);
            this.Controls.Add(this.bntEditar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.lblPesquisar);
            this.Name = "LocacaoForms";
            this.Text = "LocacaoForms";
            this.Load += new System.EventHandler(this.LocacaoForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocacoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.Label lblData2;
        private System.Windows.Forms.DateTimePicker dtpDevolucao;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.DateTimePicker dtpLocacao;
        private System.Windows.Forms.DataGridView dgvLocacoes;
        private System.Windows.Forms.Button bntAtualizar;
        private System.Windows.Forms.Button bntLimparCampos;
        private System.Windows.Forms.Button bntBuscar;
        private System.Windows.Forms.Button bntExcluir;
        private System.Windows.Forms.Button bntEditar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.Button btnSalvar;
    }
}