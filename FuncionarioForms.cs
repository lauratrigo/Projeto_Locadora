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
    public partial class FuncionarioForms : Form
    {
        private Funcionario funcionarioEditando = null;

        public DataGridView DataGridFuncionarios
        {
            get { return dgvFuncionarios; }  // Troque 'dgvFuncionarios' pelo nome real do seu DataGridView
        }

        public FuncionarioForms()
        {
            InitializeComponent();
        }

        // método para limpar os campos do formulário após o cliente ser adicionado
        private void LimparCampos()
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtCargo.Clear();
        }
        // método para carregar os funcionários no DataGridView
        private void CarregarFuncionarios()
        {
            List<Funcionario> listaFuncionarios = Funcionario.ReadAll(); // chama o método ReadAll da classe Funcionario para obter todos os funcionários

            dgvFuncionarios.DataSource = listaFuncionarios; // associa a lista de funcionários ao DataGridView
        }

        private void AtualizarTabela()
        {
            dgvFuncionarios.DataSource = null;
            dgvFuncionarios.DataSource = Funcionario.ReadAll();
            dgvFuncionarios.ClearSelection();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
        string.IsNullOrWhiteSpace(txtCpf.Text) ||
        string.IsNullOrWhiteSpace(txtTelefone.Text) ||
        string.IsNullOrWhiteSpace(txtEmail.Text) ||
        string.IsNullOrWhiteSpace(txtCargo.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            // Cria o usuário correspondente (senha e nome simples para exemplo)
            Usuarios novoUsuario = new Usuarios
            {
                NomeUsuario = txtCpf.Text.Trim(), // ou um txtUsuario se você quiser um campo separado
                Senha = "123", // use hash depois!
                NivelAcesso = "comum"
            };

            if (!novoUsuario.Create())
            {
                MessageBox.Show("Erro ao criar o usuário relacionado.");
                return;
            }

            Funcionario f = new Funcionario
            {
                Nome = txtNome.Text.Trim(),
                Cpf = txtCpf.Text.Trim(),
                Telefone = txtTelefone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Cargo = txtCargo.Text.Trim(),
                IdUsuario = novoUsuario.IdUsuario
            };

            if (f.Create())
            {
                MessageBox.Show("Funcionário cadastrado com sucesso!");
                AtualizarTabela();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar funcionário.");
            }
        }

        private void bntEditar_Click(object sender, EventArgs e)
        {
            if (dgvFuncionarios.CurrentRow != null)
            {
                // Supondo que você tenha uma coluna com o ID do funcionário no DataGridView chamada "IdFuncionario"
                int idFuncionario = Convert.ToInt32(dgvFuncionarios.CurrentRow.Cells["IdFuncionario"].Value);

                // Busca o funcionário pelo ID
                Funcionario funcionario = Funcionario.ReadById(idFuncionario);

                if (funcionario != null)
                {
                    // Preenche as textboxes com os dados do funcionário selecionado
                    txtNome.Text = funcionario.Nome;
                    txtCpf.Text = funcionario.Cpf;
                    txtTelefone.Text = funcionario.Telefone;
                    txtEmail.Text = funcionario.Email;
                    txtCargo.Text = funcionario.Cargo;

                    // Guarda o funcionário que será editado
                    funcionarioEditando = funcionario;
                }
                else
                {
                    MessageBox.Show("Funcionário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um funcionário na tabela para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bntExcluir_Click(object sender, EventArgs e)
        {
            if (dgvFuncionarios.CurrentRow == null)
            {
                MessageBox.Show("Selecione um funcionário na tabela.");
                return;
            }

            // Obtém o ID do funcionário selecionado no DataGridView
            int idFuncionario = Convert.ToInt32(dgvFuncionarios.CurrentRow.Cells["IdFuncionario"].Value);

            // Busca o funcionário pelo ID
            Funcionario funcionario = Funcionario.ReadById(idFuncionario);

            if (funcionario != null)
            {
                // Confirmação antes de excluir
                DialogResult confirm = MessageBox.Show(
                    "Tem certeza que deseja excluir este funcionário?",
                    "Confirmação de Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    // Exclui o funcionário
                    if (funcionario.Delete())
                    {
                        MessageBox.Show("Funcionário excluído com sucesso.");
                        AtualizarTabela();  // Atualiza o DataGridView após exclusão
                        LimparCampos();     // Limpa os campos do formulário
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o funcionário.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Funcionário não encontrado.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cpf = txtCpf.Text.Trim();

            if (string.IsNullOrWhiteSpace(cpf))
            {
                MessageBox.Show("Por favor, digite um CPF.");
                return;
            }

            // Busca o funcionário pelo CPF
            Funcionario funcionario = Funcionario.ReadByCPF(cpf);

            if (funcionario != null)
            {
                // Preenche os campos com os dados encontrados
                txtNome.Text = funcionario.Nome;
                txtCpf.Text = funcionario.Cpf;
                txtTelefone.Text = funcionario.Telefone;
                txtEmail.Text = funcionario.Email;
                txtCargo.Text = funcionario.Cargo;

                // Atualiza o DataGridView para mostrar só o funcionário encontrado
                dgvFuncionarios.DataSource = new List<Funcionario> { funcionario };
                dgvFuncionarios.ClearSelection();

                MessageBox.Show("Funcionário encontrado!");
            }
            else
            {
                MessageBox.Show("Funcionário não encontrado.");

                // Limpa o DataGridView quando não achar ninguém
                dgvFuncionarios.DataSource = null;

                // Também limpa os campos para evitar confusão
                LimparCampos();
            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            // limpa todos os campos de texto

            txtNome.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtCargo.Clear();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            // recarregar os funcionários a partir do banco de dados
            List<Funcionario> listaFuncionarios = Funcionario.ReadAll();  // chama o método ReadAll para pegar todos os funcionários

            // atualiza a fonte de dados do DataGridView
            dgvFuncionarios.DataSource = listaFuncionarios;  // define a lista de funcionários como a fonte de dados para o DataGridView

            // limpa a seleção
            dgvFuncionarios.ClearSelection();
        }

        private void FuncionarioForms_Load(object sender, EventArgs e)
        {
            AtualizarTabela();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (funcionarioEditando == null)
            {
                MessageBox.Show("Nenhum funcionário foi carregado para edição.");
                return;
            }

            // Atualiza o funcionário com os novos dados dos campos
            funcionarioEditando.Nome = txtNome.Text.Trim();
            funcionarioEditando.Cpf = txtCpf.Text.Trim();
            funcionarioEditando.Telefone = txtTelefone.Text.Trim();
            funcionarioEditando.Email = txtEmail.Text.Trim();
            funcionarioEditando.Cargo = txtCargo.Text.Trim();

            // Tenta atualizar no banco de dados
            if (funcionarioEditando.Update())
            {
                MessageBox.Show("Edição salva com sucesso!");
                AtualizarTabela();   // Recarrega o DataGridView com os dados atualizados
                LimparCampos();      // Limpa os campos do formulário
                funcionarioEditando = null; // Limpa a referência do funcionário editado
            }
            else
            {
                MessageBox.Show("Erro ao salvar as alterações.");
            }
        }
    }
}
