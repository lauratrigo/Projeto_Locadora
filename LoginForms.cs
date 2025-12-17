using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Final_Prog_III
{
    public partial class LoginForms : Form
    {
        public LoginForms()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string nome = txtUsuario.Text.Trim();
            string senha = txtSenha.Text.Trim();

            // Buscando o usuário no banco
            var usuario = Usuarios.ReadByNomeUsuario(nome);


            // Verifica se o usuário existe
            if (usuario == null)
            {
                DialogResult r = MessageBox.Show("Usuário não encontrado. Deseja se cadastrar?", "Cadastro", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    // Redireciona para o formulário de cadastro de cliente
                    CadastrarClienteForms formCadastro = new CadastrarClienteForms();
                    formCadastro.ShowDialog();
                }
                return;
            }

            // Verifica se a senha está correta
            if (!usuario.ValidarSenha(senha))
            {
                MessageBox.Show("Senha incorreta. Tente novamente.");
                return;
            }

            // Atualiza sessão do usuário (novo código)
            var conexao = Banco.GetConexao();
            if (conexao.State == System.Data.ConnectionState.Closed)
                conexao.Open();

            // (Opcional) Atualiza sessão na tabela UsuarioSessao, se ainda quiser
            UsuarioSessaoDAO sessao = new UsuarioSessaoDAO();
            sessao.AtualizarUsuarioSessao(nome, usuario.NivelAcesso);

            // Acesso liberado conforme o nível de acesso
            if (usuario.NivelAcesso == "admin")
            {
                MessageBox.Show("Bem-vindo, administrador!");

                // Formulário para funcionário/admin
                MDIAdmin telaAdmin = new MDIAdmin(usuario);
                telaAdmin.Show();
                this.Hide();
            }
            else if (usuario.NivelAcesso == "cliente")
            {
                MessageBox.Show("Bem-vindo à locadora!");

                // Formulário para cliente
                MDICliente telaCliente = new MDICliente(usuario);
                telaCliente.Show();
                this.Hide();
            }
            else
            {
                // Caso o usuário tenha um nível de acesso inválido
                MessageBox.Show("Nível de acesso inválido. Contate o administrador.");
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Define usuário provisório como visitante/auto-cadastro
            UsuarioSessaoDAO sessao = new UsuarioSessaoDAO();
            sessao.AtualizarUsuarioSessao("auto-cadastro", "cliente");

            // Caso o usuário queira se cadastrar
            CadastrarClienteForms formCadastro = new CadastrarClienteForms();
            formCadastro.ShowDialog();
        }
    }
}
