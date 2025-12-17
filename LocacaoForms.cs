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
    public partial class LocacaoForms : Form
    {
        public LocacaoForms()
        {
            InitializeComponent();
        }

        public DataGridView DataGridLocacoes
        {
            get { return dgvLocacoes; }  // Substitua 'dgvLocacoes' pelo nome correto do seu DataGridView
        }

        // método para carregar as locações no datagridview
        private void CarregarLocacoes()
        {
            List<Locacao> listaLocacoes = Locacao.ReadAll();  // método que retorna todas as locações do banco de dados
            dgvLocacoes.DataSource = listaLocacoes;  // atualiza a datagridview com a lista de locações
            dgvLocacoes.ClearSelection();  // limpa qualquer seleção anterior
        }

        // método para limpar os campos do formulário de locações
        private void LimparCampos()
        {
            // limpa o campo de pesquisa do id do cliente
            txtPesquisar.Clear();

            // reseta as datas para o estado inicial
            dtpLocacao.Value = DateTime.Now;  // reseta para a data atual
            dtpDevolucao.Value = DateTime.Now.AddDays(1);  // reseta para o dia seguinte (data de devolução padrão)

            // limpa a seleção no DataGridView (dgvLocacoes)
            dgvLocacoes.ClearSelection();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // verifica se todos os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(txtPesquisar.Text) || dtpLocacao.Value == null || dtpDevolucao.Value == null)
            {
                MessageBox.Show("Por favor, preencha todos os campos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // cria a locação
            Locacao locacao = new Locacao
            {
                IdCliente = int.Parse(txtPesquisar.Text),  // id do cliente a partir da textbox
                DataLocacao = dtpLocacao.Value,  // data da locação selecionada
                DataDevolucao = dtpDevolucao.Value  // data de devolução prevista selecionada
            };

            // tenta adicionar a locação ao banco de dados
            if (locacao.Create())  // método que insere a locação no banco de dados
            {
                MessageBox.Show("Locação adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarLocacoes();  // Atualiza a lista de locações no DataGridView
                LimparCampos();  // Limpa os campos
            }
            else
            {
                MessageBox.Show("Erro ao adicionar a locação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // botão que edita uma locação no banco de dados
        private void bntEditar_Click(object sender, EventArgs e)
        {
            // Verifica se uma locação foi selecionada no DataGridView
            if (dgvLocacoes.SelectedRows.Count > 0)
            {
                // Obtém o ID da locação selecionada
                int idLocacao = ((Locacao)dgvLocacoes.SelectedRows[0].DataBoundItem).IdLocacao;

                // Busca a locação no banco de dados
                Locacao locacao = Locacao.ReadByID(idLocacao);

                if (locacao != null)
                {
                    // Verifica se o campo de ID do Cliente (txtPesquisar) contém um valor válido
                    if (!int.TryParse(txtPesquisar.Text, out int idCliente))
                    {
                        MessageBox.Show("Por favor, insira um ID de cliente válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Atualiza os dados da locação com os valores editados no formulário
                    locacao.IdCliente = idCliente;  // ID do Cliente
                    locacao.DataLocacao = dtpLocacao.Value;  // Nova Data de Locação
                    locacao.DataDevolucao = dtpDevolucao.Value;  // Nova Data de Devolução

                    // Verifica se todos os campos obrigatórios estão preenchidos
                    if (string.IsNullOrWhiteSpace(txtPesquisar.Text) || locacao.DataLocacao == null || locacao.DataDevolucao == null)
                    {
                        MessageBox.Show("Por favor, preencha todos os campos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Chama o método Update da classe Locacao para salvar as alterações no banco
                    if (locacao.Update())  // Atualiza a locação no banco de dados
                    {
                        MessageBox.Show("Locação editada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarLocacoes();  // Atualiza a lista de locações no DataGridView
                        LimparCampos();  // Limpa os campos do formulário
                    }
                    else
                    {
                        MessageBox.Show("Erro ao editar a locação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Locação não encontrada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma locação para editar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // botão para excluir uma locação do banco de dados
        private void bntExcluir_Click(object sender, EventArgs e)
        {
            // verifica se uma locação foi selecionada no datagridview
            if (dgvLocacoes.SelectedRows.Count > 0)
            {
                // obtém o id da locação selecionada
                int idLocacao = ((Locacao)dgvLocacoes.SelectedRows[0].DataBoundItem).IdLocacao;

                // exclui a locação no banco de dados
                Locacao locacao = Locacao.ReadByID(idLocacao);
                if (locacao.Delete())  // método que exclui a locação do banco de dados
                {
                    MessageBox.Show("Locação excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarLocacoes();  // atualiza a lista de locações no datagridview
                }
                else
                {
                    MessageBox.Show("Erro ao excluir a locação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma locação para excluir!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // botão para buscar uma locação com base no id do cliente
        private void bntBuscar_Click(object sender, EventArgs e)
        {
            // verifica se o id da locação foi informado corretamente
            if (int.TryParse(txtPesquisar.Text, out int idLocacao) && idLocacao > 0)
            {
                // busca a locação pelo idLocacao
                Locacao locacao = Locacao.ReadByID(idLocacao);

                if (locacao != null)
                {
                    // exibe a locação encontrada no DataGridView (você pode preencher o DataGridView com uma lista contendo só essa locação)
                    List<Locacao> locacoes = new List<Locacao> { locacao };
                    dgvLocacoes.DataSource = locacoes;
                }
                else
                {
                    MessageBox.Show("Locação não encontrada com o ID informado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um ID de locação válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // método para limpar os campos
        private void bntLimparCampos_Click(object sender, EventArgs e)
        {
            // limpa os campos de texto
            txtPesquisar.Clear();

            // reseta as datas para o estado inicial
            dtpLocacao.Value = DateTime.Now;
            dtpDevolucao.Value = DateTime.Now.AddDays(1);

            // limpa a seleção no datagridview
            dgvLocacoes.ClearSelection();
        }

        private void bntAtualizar_Click(object sender, EventArgs e)
        {
            // Chama o método CarregarLocacoes para atualizar a lista de locações no DataGridView
            CarregarLocacoes();

            // Opcionalmente, você pode exibir uma mensagem informando que a lista foi atualizada com sucesso
            MessageBox.Show("Lista de locações atualizada!", "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Verifica se uma locação foi selecionada no DataGridView
            if (dgvLocacoes.SelectedRows.Count > 0)
            {
                // Obtém o ID da locação selecionada
                int idLocacao = ((Locacao)dgvLocacoes.SelectedRows[0].DataBoundItem).IdLocacao;

                // Busca a locação no banco de dados
                Locacao locacao = Locacao.ReadByID(idLocacao);

                if (locacao != null)
                {
                    // Preenche os dados da locação com os valores dos campos do formulário
                    locacao.IdCliente = int.Parse(txtPesquisar.Text);  // Assume que o ID do cliente foi preenchido na TextBox
                    locacao.DataLocacao = dtpLocacao.Value;  // Data de locação
                    locacao.DataDevolucao = dtpDevolucao.Value;  // Data de devolução

                    // Verifica se todos os campos obrigatórios estão preenchidos
                    if (string.IsNullOrWhiteSpace(txtPesquisar.Text) || locacao.DataLocacao == null || locacao.DataDevolucao == null)
                    {
                        MessageBox.Show("Por favor, preencha todos os campos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Chama o método Update da classe Locacao para salvar as alterações no banco
                    if (locacao.Update())
                    {
                        MessageBox.Show("Locação editada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarLocacoes();  // Atualiza a lista de locações no DataGridView
                        LimparCampos();  // Limpa os campos do formulário
                    }
                    else
                    {
                        MessageBox.Show("Erro ao editar a locação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Locação não encontrada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma locação para editar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LocacaoForms_Load(object sender, EventArgs e)
        {
            CarregarLocacoes(); // carrega os dados do banco no datagridview assim que o programa roda
        }
    }
}
