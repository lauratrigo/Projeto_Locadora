namespace Projeto_Final_Prog_III
{
    partial class FilmeFormsCliente
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
            this.lblHistorico = new System.Windows.Forms.Label();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.txtDuracao = new System.Windows.Forms.TextBox();
            this.dgvFilmes = new System.Windows.Forms.DataGridView();
            this.bntHistorico = new System.Windows.Forms.Button();
            this.bntBuscar = new System.Windows.Forms.Button();
            this.btnAlugar = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLista
            // 
            this.lblLista.AutoSize = true;
            this.lblLista.Location = new System.Drawing.Point(361, 17);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(79, 13);
            this.lblLista.TabIndex = 93;
            this.lblLista.Text = "Lista de Filmes:";
            // 
            // lblHistorico
            // 
            this.lblHistorico.AutoSize = true;
            this.lblHistorico.Location = new System.Drawing.Point(364, 378);
            this.lblHistorico.Name = "lblHistorico";
            this.lblHistorico.Size = new System.Drawing.Size(116, 13);
            this.lblHistorico.TabIndex = 92;
            this.lblHistorico.Text = "Histórico de Locações:";
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Location = new System.Drawing.Point(364, 394);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.RowHeadersWidth = 51;
            this.dgvHistorico.Size = new System.Drawing.Size(788, 279);
            this.dgvHistorico.TabIndex = 91;
            // 
            // txtDuracao
            // 
            this.txtDuracao.Location = new System.Drawing.Point(16, 127);
            this.txtDuracao.Name = "txtDuracao";
            this.txtDuracao.Size = new System.Drawing.Size(303, 20);
            this.txtDuracao.TabIndex = 90;
            // 
            // dgvFilmes
            // 
            this.dgvFilmes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilmes.Location = new System.Drawing.Point(364, 38);
            this.dgvFilmes.Name = "dgvFilmes";
            this.dgvFilmes.RowHeadersWidth = 51;
            this.dgvFilmes.Size = new System.Drawing.Size(788, 325);
            this.dgvFilmes.TabIndex = 89;
            // 
            // bntHistorico
            // 
            this.bntHistorico.Location = new System.Drawing.Point(235, 394);
            this.bntHistorico.Name = "bntHistorico";
            this.bntHistorico.Size = new System.Drawing.Size(104, 56);
            this.bntHistorico.TabIndex = 88;
            this.bntHistorico.Text = "Ver Histórico de Locação";
            this.bntHistorico.UseVisualStyleBackColor = true;
            this.bntHistorico.Click += new System.EventHandler(this.bntHistorico_Click);
            // 
            // bntBuscar
            // 
            this.bntBuscar.Location = new System.Drawing.Point(16, 394);
            this.bntBuscar.Name = "bntBuscar";
            this.bntBuscar.Size = new System.Drawing.Size(104, 56);
            this.bntBuscar.TabIndex = 87;
            this.bntBuscar.Text = "Buscar Filmes";
            this.bntBuscar.UseVisualStyleBackColor = true;
            this.bntBuscar.Click += new System.EventHandler(this.bntBuscar_Click);
            // 
            // btnAlugar
            // 
            this.btnAlugar.Location = new System.Drawing.Point(126, 394);
            this.btnAlugar.Name = "btnAlugar";
            this.btnAlugar.Size = new System.Drawing.Size(104, 56);
            this.btnAlugar.TabIndex = 86;
            this.btnAlugar.Text = "Alugar Filme";
            this.btnAlugar.UseVisualStyleBackColor = true;
            this.btnAlugar.Click += new System.EventHandler(this.btnAlugar_Click);
            // 
            // cmbDisponivel
            // 
            this.cmbDisponivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisponivel.FormattingEnabled = true;
            this.cmbDisponivel.Location = new System.Drawing.Point(16, 274);
            this.cmbDisponivel.Name = "cmbDisponivel";
            this.cmbDisponivel.Size = new System.Drawing.Size(303, 21);
            this.cmbDisponivel.TabIndex = 85;
            // 
            // lblDisponivel
            // 
            this.lblDisponivel.AutoSize = true;
            this.lblDisponivel.Location = new System.Drawing.Point(13, 258);
            this.lblDisponivel.Name = "lblDisponivel";
            this.lblDisponivel.Size = new System.Drawing.Size(81, 13);
            this.lblDisponivel.TabIndex = 84;
            this.lblDisponivel.Text = "Disponibilidade:";
            // 
            // txtDiretor
            // 
            this.txtDiretor.Location = new System.Drawing.Point(16, 228);
            this.txtDiretor.Name = "txtDiretor";
            this.txtDiretor.Size = new System.Drawing.Size(303, 20);
            this.txtDiretor.TabIndex = 83;
            // 
            // lblDiretor
            // 
            this.lblDiretor.AutoSize = true;
            this.lblDiretor.Location = new System.Drawing.Point(13, 212);
            this.lblDiretor.Name = "lblDiretor";
            this.lblDiretor.Size = new System.Drawing.Size(41, 13);
            this.lblDiretor.TabIndex = 82;
            this.lblDiretor.Text = "Diretor:";
            // 
            // lblDuracao
            // 
            this.lblDuracao.AutoSize = true;
            this.lblDuracao.Location = new System.Drawing.Point(13, 111);
            this.lblDuracao.Name = "lblDuracao";
            this.lblDuracao.Size = new System.Drawing.Size(51, 13);
            this.lblDuracao.TabIndex = 81;
            this.lblDuracao.Text = "Duração:";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(16, 182);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(303, 20);
            this.txtAno.TabIndex = 80;
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Location = new System.Drawing.Point(13, 166);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(106, 13);
            this.lblAno.TabIndex = 79;
            this.lblAno.Text = "Ano de Lançamento:";
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Location = new System.Drawing.Point(16, 74);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(303, 21);
            this.cmbGenero.TabIndex = 78;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(13, 58);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(45, 13);
            this.lblGenero.TabIndex = 77;
            this.lblGenero.Text = "Gênero:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(13, 7);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(80, 13);
            this.lblNome.TabIndex = 76;
            this.lblNome.Text = "Nome do Filme:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(16, 23);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(303, 20);
            this.txtNome.TabIndex = 75;
            // 
            // FilmeFormsCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 670);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.lblHistorico);
            this.Controls.Add(this.dgvHistorico);
            this.Controls.Add(this.txtDuracao);
            this.Controls.Add(this.dgvFilmes);
            this.Controls.Add(this.bntHistorico);
            this.Controls.Add(this.bntBuscar);
            this.Controls.Add(this.btnAlugar);
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
            this.Name = "FilmeFormsCliente";
            this.Text = "FilmeFormsCliente";
            this.Load += new System.EventHandler(this.FilmeFormsCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.Label lblHistorico;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.TextBox txtDuracao;
        private System.Windows.Forms.DataGridView dgvFilmes;
        private System.Windows.Forms.Button bntHistorico;
        private System.Windows.Forms.Button bntBuscar;
        private System.Windows.Forms.Button btnAlugar;
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