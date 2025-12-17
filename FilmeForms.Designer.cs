namespace Projeto_Final_Prog_III
{
    partial class FilmeForms
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
            this.btnSalvarFilmeEditado = new System.Windows.Forms.Button();
            this.lblLista = new System.Windows.Forms.Label();
            this.dgvFilmes = new System.Windows.Forms.DataGridView();
            this.txtDuracao = new System.Windows.Forms.TextBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnLimparCampos = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.cmbDisponivel = new System.Windows.Forms.ComboBox();
            this.lblDisponivel = new System.Windows.Forms.Label();
            this.txtDiretor = new System.Windows.Forms.TextBox();
            this.lblDiretor = new System.Windows.Forms.Label();
            this.lblDuracao = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.lblAno = new System.Windows.Forms.Label();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvarFilmeEditado
            // 
            this.btnSalvarFilmeEditado.Location = new System.Drawing.Point(226, 387);
            this.btnSalvarFilmeEditado.Name = "btnSalvarFilmeEditado";
            this.btnSalvarFilmeEditado.Size = new System.Drawing.Size(104, 56);
            this.btnSalvarFilmeEditado.TabIndex = 122;
            this.btnSalvarFilmeEditado.Text = "Salvar Filme Editado";
            this.btnSalvarFilmeEditado.UseVisualStyleBackColor = true;
            this.btnSalvarFilmeEditado.Click += new System.EventHandler(this.btnSalvarFilmeEditado_Click);
            // 
            // lblLista
            // 
            this.lblLista.AutoSize = true;
            this.lblLista.Location = new System.Drawing.Point(333, 18);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(79, 13);
            this.lblLista.TabIndex = 121;
            this.lblLista.Text = "Lista de Filmes:";
            // 
            // dgvFilmes
            // 
            this.dgvFilmes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilmes.Location = new System.Drawing.Point(336, 34);
            this.dgvFilmes.Name = "dgvFilmes";
            this.dgvFilmes.RowHeadersWidth = 51;
            this.dgvFilmes.Size = new System.Drawing.Size(788, 325);
            this.dgvFilmes.TabIndex = 120;
            // 
            // txtDuracao
            // 
            this.txtDuracao.Location = new System.Drawing.Point(9, 138);
            this.txtDuracao.Name = "txtDuracao";
            this.txtDuracao.Size = new System.Drawing.Size(303, 20);
            this.txtDuracao.TabIndex = 119;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(666, 387);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(104, 56);
            this.btnAtualizar.TabIndex = 116;
            this.btnAtualizar.Text = "Atualizar Lista de Filmes";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnLimparCampos
            // 
            this.btnLimparCampos.Location = new System.Drawing.Point(556, 387);
            this.btnLimparCampos.Name = "btnLimparCampos";
            this.btnLimparCampos.Size = new System.Drawing.Size(104, 56);
            this.btnLimparCampos.TabIndex = 115;
            this.btnLimparCampos.Text = "Limpar Campos";
            this.btnLimparCampos.UseVisualStyleBackColor = true;
            this.btnLimparCampos.Click += new System.EventHandler(this.btnLimparCampos_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(446, 387);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(104, 56);
            this.btnBuscar.TabIndex = 114;
            this.btnBuscar.Text = "Buscar Filme";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(336, 387);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(104, 56);
            this.btnExcluir.TabIndex = 113;
            this.btnExcluir.Text = "Excluir Filme";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(116, 387);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(104, 56);
            this.btnEditar.TabIndex = 112;
            this.btnEditar.Text = "Editar um Filme Existente";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(6, 387);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(104, 56);
            this.btnAdicionar.TabIndex = 111;
            this.btnAdicionar.Text = "Adicionar Novo Filme";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // cmbDisponivel
            // 
            this.cmbDisponivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisponivel.FormattingEnabled = true;
            this.cmbDisponivel.Location = new System.Drawing.Point(9, 285);
            this.cmbDisponivel.Name = "cmbDisponivel";
            this.cmbDisponivel.Size = new System.Drawing.Size(303, 21);
            this.cmbDisponivel.TabIndex = 110;
            // 
            // lblDisponivel
            // 
            this.lblDisponivel.AutoSize = true;
            this.lblDisponivel.Location = new System.Drawing.Point(6, 269);
            this.lblDisponivel.Name = "lblDisponivel";
            this.lblDisponivel.Size = new System.Drawing.Size(81, 13);
            this.lblDisponivel.TabIndex = 109;
            this.lblDisponivel.Text = "Disponibilidade:";
            // 
            // txtDiretor
            // 
            this.txtDiretor.Location = new System.Drawing.Point(9, 239);
            this.txtDiretor.Name = "txtDiretor";
            this.txtDiretor.Size = new System.Drawing.Size(303, 20);
            this.txtDiretor.TabIndex = 108;
            // 
            // lblDiretor
            // 
            this.lblDiretor.AutoSize = true;
            this.lblDiretor.Location = new System.Drawing.Point(6, 223);
            this.lblDiretor.Name = "lblDiretor";
            this.lblDiretor.Size = new System.Drawing.Size(41, 13);
            this.lblDiretor.TabIndex = 107;
            this.lblDiretor.Text = "Diretor:";
            // 
            // lblDuracao
            // 
            this.lblDuracao.AutoSize = true;
            this.lblDuracao.Location = new System.Drawing.Point(6, 122);
            this.lblDuracao.Name = "lblDuracao";
            this.lblDuracao.Size = new System.Drawing.Size(51, 13);
            this.lblDuracao.TabIndex = 106;
            this.lblDuracao.Text = "Duração:";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(9, 193);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(303, 20);
            this.txtAno.TabIndex = 105;
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Location = new System.Drawing.Point(6, 177);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(106, 13);
            this.lblAno.TabIndex = 104;
            this.lblAno.Text = "Ano de Lançamento:";
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Location = new System.Drawing.Point(9, 85);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(303, 21);
            this.cmbGenero.TabIndex = 103;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(6, 69);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(45, 13);
            this.lblGenero.TabIndex = 102;
            this.lblGenero.Text = "Gênero:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(6, 18);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(80, 13);
            this.lblNome.TabIndex = 101;
            this.lblNome.Text = "Título do Filme:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(9, 34);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(303, 20);
            this.txtNome.TabIndex = 100;
            // 
            // FilmeForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 466);
            this.Controls.Add(this.btnSalvarFilmeEditado);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.dgvFilmes);
            this.Controls.Add(this.txtDuracao);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnLimparCampos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.cmbDisponivel);
            this.Controls.Add(this.lblDisponivel);
            this.Controls.Add(this.txtDiretor);
            this.Controls.Add(this.lblDiretor);
            this.Controls.Add(this.lblDuracao);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.lblAno);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Name = "FilmeForms";
            this.Text = "FilmeForms";
            this.Load += new System.EventHandler(this.FilmeForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalvarFilmeEditado;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.DataGridView dgvFilmes;
        private System.Windows.Forms.TextBox txtDuracao;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnLimparCampos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ComboBox cmbDisponivel;
        private System.Windows.Forms.Label lblDisponivel;
        private System.Windows.Forms.TextBox txtDiretor;
        private System.Windows.Forms.Label lblDiretor;
        private System.Windows.Forms.Label lblDuracao;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
    }
}