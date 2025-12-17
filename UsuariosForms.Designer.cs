namespace Projeto_Final_Prog_III
{
    partial class UsuariosForms
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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.bntBuscar = new System.Windows.Forms.Button();
            this.bntExcluir = new System.Windows.Forms.Button();
            this.bntLimparCampos = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.cmbNivelAcesso = new System.Windows.Forms.ComboBox();
            this.lblNivelAcesso = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtNomeUsuario = new System.Windows.Forms.TextBox();
            this.lblNomeUsuario = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnSalvarExistente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLista
            // 
            this.lblLista.AutoSize = true;
            this.lblLista.Location = new System.Drawing.Point(334, 52);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(91, 13);
            this.lblLista.TabIndex = 90;
            this.lblLista.Text = "Lista de Usuários:";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToOrderColumns = true;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(337, 68);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Size = new System.Drawing.Size(689, 296);
            this.dgvUsuarios.TabIndex = 89;
            // 
            // bntBuscar
            // 
            this.bntBuscar.Location = new System.Drawing.Point(379, 382);
            this.bntBuscar.Name = "bntBuscar";
            this.bntBuscar.Size = new System.Drawing.Size(104, 56);
            this.bntBuscar.TabIndex = 88;
            this.bntBuscar.Text = "Buscar (pelo nome do usuário)";
            this.bntBuscar.UseVisualStyleBackColor = true;
            this.bntBuscar.Click += new System.EventHandler(this.bntBuscar_Click);
            // 
            // bntExcluir
            // 
            this.bntExcluir.Location = new System.Drawing.Point(259, 382);
            this.bntExcluir.Name = "bntExcluir";
            this.bntExcluir.Size = new System.Drawing.Size(104, 56);
            this.bntExcluir.TabIndex = 87;
            this.bntExcluir.Text = "Excluir Usuário";
            this.bntExcluir.UseVisualStyleBackColor = true;
            this.bntExcluir.Click += new System.EventHandler(this.bntExcluir_Click);
            // 
            // bntLimparCampos
            // 
            this.bntLimparCampos.Location = new System.Drawing.Point(140, 382);
            this.bntLimparCampos.Name = "bntLimparCampos";
            this.bntLimparCampos.Size = new System.Drawing.Size(104, 56);
            this.bntLimparCampos.TabIndex = 86;
            this.bntLimparCampos.Text = "Limpar Campos";
            this.bntLimparCampos.UseVisualStyleBackColor = true;
            this.bntLimparCampos.Click += new System.EventHandler(this.bntLimparCampos_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(21, 382);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(104, 56);
            this.btnAdicionar.TabIndex = 85;
            this.btnAdicionar.Text = "Adicionar Usuário";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click_1);
            // 
            // cmbNivelAcesso
            // 
            this.cmbNivelAcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivelAcesso.FormattingEnabled = true;
            this.cmbNivelAcesso.Location = new System.Drawing.Point(21, 205);
            this.cmbNivelAcesso.Name = "cmbNivelAcesso";
            this.cmbNivelAcesso.Size = new System.Drawing.Size(296, 21);
            this.cmbNivelAcesso.TabIndex = 84;
            // 
            // lblNivelAcesso
            // 
            this.lblNivelAcesso.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblNivelAcesso.AutoSize = true;
            this.lblNivelAcesso.Location = new System.Drawing.Point(18, 189);
            this.lblNivelAcesso.Name = "lblNivelAcesso";
            this.lblNivelAcesso.Size = new System.Drawing.Size(89, 13);
            this.lblNivelAcesso.TabIndex = 83;
            this.lblNivelAcesso.Text = "Nível de Acesso:";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(21, 135);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(296, 20);
            this.txtSenha.TabIndex = 82;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(18, 119);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 81;
            this.lblSenha.Text = "Senha:";
            // 
            // txtNomeUsuario
            // 
            this.txtNomeUsuario.Location = new System.Drawing.Point(21, 68);
            this.txtNomeUsuario.Name = "txtNomeUsuario";
            this.txtNomeUsuario.Size = new System.Drawing.Size(296, 20);
            this.txtNomeUsuario.TabIndex = 80;
            // 
            // lblNomeUsuario
            // 
            this.lblNomeUsuario.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblNomeUsuario.AutoSize = true;
            this.lblNomeUsuario.Location = new System.Drawing.Point(18, 52);
            this.lblNomeUsuario.Name = "lblNomeUsuario";
            this.lblNomeUsuario.Size = new System.Drawing.Size(92, 13);
            this.lblNomeUsuario.TabIndex = 79;
            this.lblNomeUsuario.Text = "Nome do Usuário:";
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(504, 382);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(104, 56);
            this.btnEditar.TabIndex = 91;
            this.btnEditar.Text = "Editar usuário existente";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalvarExistente
            // 
            this.btnSalvarExistente.Location = new System.Drawing.Point(629, 382);
            this.btnSalvarExistente.Name = "btnSalvarExistente";
            this.btnSalvarExistente.Size = new System.Drawing.Size(104, 56);
            this.btnSalvarExistente.TabIndex = 92;
            this.btnSalvarExistente.Text = "Salvar Usuário Editado";
            this.btnSalvarExistente.UseVisualStyleBackColor = true;
            this.btnSalvarExistente.Click += new System.EventHandler(this.btnSalvarExistente_Click);
            // 
            // UsuariosForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 471);
            this.Controls.Add(this.btnSalvarExistente);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.bntBuscar);
            this.Controls.Add(this.bntExcluir);
            this.Controls.Add(this.bntLimparCampos);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.cmbNivelAcesso);
            this.Controls.Add(this.lblNivelAcesso);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtNomeUsuario);
            this.Controls.Add(this.lblNomeUsuario);
            this.Name = "UsuariosForms";
            this.Text = "UsuariosForms";
            this.Load += new System.EventHandler(this.UsuariosForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button bntBuscar;
        private System.Windows.Forms.Button bntExcluir;
        private System.Windows.Forms.Button bntLimparCampos;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ComboBox cmbNivelAcesso;
        private System.Windows.Forms.Label lblNivelAcesso;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtNomeUsuario;
        private System.Windows.Forms.Label lblNomeUsuario;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnSalvarExistente;
    }
}