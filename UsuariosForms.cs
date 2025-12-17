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
    public partial class UsuariosForms : Form
    {
        private Usuarios usuarioLogado;  // Variável para armazenar o usuário logado

        Usuarios usuarioAtual = new Usuarios(); // Usuário que está sendo criado ou editado

        private bool modoRestrito; // Se true, esconde botões de edição/exclusão/salvar

        public DataGridView DataGridUsuarios
        {
            get { return dgvUsuarios; }  // Substitua "dgvUsuarios" pelo nome real do seu DataGridView de usuários
        }

        // Construtor padrão (sem usuário logado, modo não restrito)
        public UsuariosForms()
        {
            InitializeComponent();
            usuarioLogado = null;
            modoRestrito = false;
            this.Load += UsuariosForms_Load;
        }

        // Construtor com usuário logado, modo não restrito
        public UsuariosForms(Usuarios usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;
            modoRestrito = false;
            this.Load += UsuariosForms_Load;
        }

        // Construtor para modo restrito (ex: novo cliente, sem editar/excluir/salvar)
        public UsuariosForms(Usuarios usuario, bool modoRestrito)
        {
            InitializeComponent();
            usuarioLogado = usuario;
            this.modoRestrito = modoRestrito;
            this.Load += UsuariosForms_Load;
        }

        private void UsuariosForms_Load(object sender, EventArgs e)
        {
            AtualizarTabela();

            // Garantir itens no combo
            if (!cmbNivelAcesso.Items.Contains("admin"))
                cmbNivelAcesso.Items.Add("admin");
            if (!cmbNivelAcesso.Items.Contains("cliente"))
                cmbNivelAcesso.Items.Add("cliente");

            if (modoRestrito)
            {
                // Modo restrito: esconder botões e desabilitar combo
                btnEditar.Visible = false;
                bntExcluir.Visible = false;
                btnSalvarExistente.Visible = false;

                cmbNivelAcesso.SelectedItem = "cliente";
                cmbNivelAcesso.Enabled = false;
            }
            else if (usuarioLogado != null && usuarioLogado.NivelAcesso.ToLower() == "cliente")
            {
                // Usuário cliente normal, sem permissão para editar/excluir/salvar
                btnEditar.Visible = false;
                bntExcluir.Visible = false;
                btnSalvarExistente.Visible = false;

                cmbNivelAcesso.SelectedItem = "cliente";
                cmbNivelAcesso.Enabled = false;
            }
            else
            {
                // Admin ou outro nível: tudo visível e habilitado
                btnEditar.Visible = true;
                bntExcluir.Visible = true;
                btnSalvarExistente.Visible = true;

                cmbNivelAcesso.Enabled = true;
            }

            AtualizarTabela();
        }


        private void LimparCampos()
        {
            txtNomeUsuario.Text = "";
            txtSenha.Text = "";
            cmbNivelAcesso.SelectedIndex = -1;
            usuarioAtual = new Usuarios(); // Reinicia o objeto
        }

        // Método para atualizar os dados na tabela
        private void AtualizarTabela()
        {
            List<Usuarios> lista = new Usuarios().ReadAll();

            // Oculta a coluna de senha (hash) se existir
            if (dgvUsuarios.Columns.Contains("Senha"))
                dgvUsuarios.Columns["Senha"].Visible = false;

            dgvUsuarios.DataSource = null;    // limpa a tabela
            dgvUsuarios.DataSource = new Usuarios().ReadAll();
            dgvUsuarios.DataSource = lista;  // atualiza com nova lista
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            string termo = txtNomeUsuario.Text.Trim();
            List<Usuarios> lista = new Usuarios().ReadAll();

            var filtrado = lista.Where(u => u.NomeUsuario.Contains(termo)).ToList();

            dgvUsuarios.DataSource = filtrado;
        }

        private void bntLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void bntExcluir_Click(object sender, EventArgs e)
        {
            {
                // Verifica se há uma linha selecionada na DataGridView
                if (dgvUsuarios.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um usuário na tabela.");
                    return;
                }

                // Obtém o ID do usuário selecionado
                int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["idUsuario"].Value);
                Usuarios usuario = Usuarios.ReadById(idUsuario);

                // Verifica se o usuário existe
                if (usuario == null)
                {
                    MessageBox.Show("Usuário não encontrado.");
                    return;
                }

                // Confirmação antes de excluir o usuário
                DialogResult confirm = MessageBox.Show(
                    "Tem certeza que deseja excluir este usuário?",
                    "Confirmação de Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                // Se o usuário confirmar, tenta excluir
                if (confirm == DialogResult.Yes)
                {
                    if (usuario.Delete())
                    {
                        MessageBox.Show("Usuário excluído com sucesso.");
                        AtualizarTabela(); // Atualiza a tabela após exclusão
                        LimparCampos(); // Limpa os campos
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o usuário.");
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                // Obtém o ID do usuário selecionado na DataGridView
                int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["idUsuario"].Value);

                // Carrega os dados do usuário com o ID
                Usuarios usuario = Usuarios.ReadById(idUsuario);

                if (usuario != null)
                {
                    // Preenche os campos do formulário com os dados do usuário selecionado
                    txtNomeUsuario.Text = usuario.NomeUsuario;
                    txtSenha.Text = usuario.Senha; // A senha estará em hash, você pode exibir a senha "original" ou permitir que o usuário insira uma nova senha
                    cmbNivelAcesso.SelectedItem = usuario.NivelAcesso;

                    // Agora, o objeto usuarioAtual vai armazenar o usuário que está sendo editado
                    usuarioAtual = usuario;
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um usuário na tabela para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnSalvarExistente_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                // Obtém o ID do usuário selecionado na DataGridView
                int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["idUsuario"].Value);

                // Carrega os dados do usuário com o ID
                Usuarios usuario = Usuarios.ReadById(idUsuario);

                if (usuario == null)
                {
                    MessageBox.Show("Usuário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Preenche os campos com os dados do usuário para edição
                usuario.NomeUsuario = txtNomeUsuario.Text.Trim();
                usuario.Senha = txtSenha.Text;  // Lembre-se que a senha será criptografada com o hash
                usuario.NivelAcesso = cmbNivelAcesso.SelectedItem?.ToString();  // Pega o nível de acesso da ComboBox

                // Validação de campos obrigatórios
                if (string.IsNullOrEmpty(usuario.NomeUsuario) || string.IsNullOrEmpty(usuario.Senha))
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Atualiza o usuário no banco de dados
                bool sucesso = usuario.Update();

                if (sucesso)
                {
                    MessageBox.Show("Usuário atualizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarTabela();  // Atualiza a tabela de usuários
                    LimparCampos();  // Limpa os campos de entrada
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar o usuário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um usuário na tabela para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            if (usuarioLogado == null)
            {
                // Apenas se ninguém estiver logado (auto-cadastro)
                string nomeDigitado = txtNomeUsuario.Text.Trim();
                UsuarioSessaoDAO sessao = new UsuarioSessaoDAO();
                sessao.AtualizarUsuarioSessao(nomeDigitado, "cliente");
            }

            // Captura os dados dos campos de texto
            usuarioAtual.NomeUsuario = txtNomeUsuario.Text.Trim();
            usuarioAtual.Senha = txtSenha.Text;

            if (usuarioLogado != null && usuarioLogado.NivelAcesso == "cliente")
            {
                usuarioAtual.NivelAcesso = "cliente";
            }
            else
            {
                usuarioAtual.NivelAcesso = cmbNivelAcesso.SelectedItem?.ToString();
            }

            // Validação: Verifica se os campos obrigatórios estão preenchidos
            if (string.IsNullOrEmpty(usuarioAtual.NomeUsuario) || string.IsNullOrEmpty(usuarioAtual.Senha))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se o nome de usuário já existe no banco de dados
            if (Usuarios.ReadByNomeUsuario(usuarioAtual.NomeUsuario) != null)
            {
                MessageBox.Show("Este nome de usuário já está em uso. Escolha outro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool sucesso;

            // Se o ID do usuário for 0, significa que é um novo usuário (Criação)
            if (usuarioAtual.IdUsuario == 0)
            {
                sucesso = usuarioAtual.Create(); // Cria um novo usuário
            }
            else
            {
                sucesso = usuarioAtual.Update(); // Atualiza um usuário existente
            }

            // Exibe uma mensagem de sucesso ou erro
            if (sucesso)
            {
                MessageBox.Show("Usuário salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarTabela(); // Atualiza a tabela de usuários após salvar
                LimparCampos(); // Limpa os campos de texto
            }
            else
            {
                MessageBox.Show("Erro ao salvar o usuário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

