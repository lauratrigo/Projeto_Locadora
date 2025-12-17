using MySql.Data.MySqlClient;
using Projeto_Prog_III;
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
    public partial class ItemLocacaoForms : Form
    {
        public ItemLocacaoForms()
        {
            InitializeComponent();
        }

        public DataGridView DataGridItemLocacao
        {
            get { return dgvItensLocacao; }  // Substitua 'dgvItemLocacao' pelo nome do seu DataGridView
        }

        // método para a caixa de texto do valor entrar como R$ xx,xx
        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            if (decimal.TryParse(txtValor.Text.Replace(",", "."), out decimal resultado))
            {
                // valor válido
                MessageBox.Show("Valor válido: " + resultado.ToString("C"));
            }
            else
            {
                // valor inválido
                MessageBox.Show("Por favor, insira um valor decimal válido.");
                e.Cancel = true;
            }
        }

        // método para limpar os campos do formulário 
        private void LimparCampos()
        {
            txtIdLocacao.Clear();
            txtIdFilme.Clear();
            txtValor.Clear();
        }

        // método para limpar os campos preenchidos
        private void bntLimparCampos_Click(object sender, EventArgs e)
        {
            txtIdLocacao.Clear();
            txtIdFilme.Clear();
            txtValor.Clear();
        }

        // método para carregar os itens do banco de dados
        private void CarregarItemLocacao(int idLocacao)
        {
            List<ItemLocacao> listaItens = ItemLocacao.ReadByLocacao(idLocacao);  // lê os itens da locação específica
            dgvItensLocacao.DataSource = listaItens;  // atualiza o DataGridView com os itens
            dgvItensLocacao.ClearSelection();  // limpa a seleção
        }

        private void AtualizarTabela()
        {
            List<ItemLocacao> listaItens = ItemLocacao.ReadAll(); // Você precisa criar esse método na sua classe ItemLocacao
            dgvItensLocacao.DataSource = null;
            dgvItensLocacao.DataSource = listaItens;
            dgvItensLocacao.ClearSelection();
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // verifica se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(txtIdLocacao.Text) ||
                string.IsNullOrWhiteSpace(txtIdFilme.Text) ||
                string.IsNullOrWhiteSpace(txtValor.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos corretamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // verifica se o valor do aluguel é válido
            if (!decimal.TryParse(txtValor.Text, out decimal valor))
            {
                MessageBox.Show("O valor do aluguel não é válido. Por favor, insira um valor numérico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // verifica se o id da locação e o id do filme são válidos
            if (!int.TryParse(txtIdLocacao.Text, out int idLocacao) || idLocacao <= 0)
            {
                MessageBox.Show("O ID da locação não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtIdFilme.Text, out int idFilme) || idFilme <= 0)
            {
                MessageBox.Show("O ID do filme não é válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // cria o item de locação
            ItemLocacao itemLocacao = new ItemLocacao
            {
                IdLocacao = idLocacao,
                IdFilme = idFilme,
                Valor = valor
            };

            // tenta adicionar o item de locação ao banco de dados
            if (itemLocacao.Create())
            {
                MessageBox.Show("Filme adicionado à locação com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // atualiza a lista de filmes alugados para mostrar o item recém-adicionado
                CarregarItemLocacao(idLocacao);  // método que atualiza a lista de itens de locação

                // limpa os campos após a adição
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao adicionar o filme à locação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bntEditar_Click(object sender, EventArgs e)
        {
            // Pega o idLocacao e idFilme do item selecionado no DataGridView (ou de algum campo)
            int? idLocacao = null;
            int? idFilme = null;

            if (!string.IsNullOrWhiteSpace(txtIdLocacao.Text) && int.TryParse(txtIdLocacao.Text, out int locacao))
                idLocacao = locacao;

            if (!string.IsNullOrWhiteSpace(txtIdFilme.Text) && int.TryParse(txtIdFilme.Text, out int filme))
                idFilme = filme;

            // Busca itens com base nos parâmetros informados (um ou outro)
            List<ItemLocacao> itens = ItemLocacao.ReadByLocacaoOrFilme(idLocacao, idFilme);

            if (itens.Count == 1)
            {
                // Só um item, ótimo! Preenche os campos com ele.
                ItemLocacao item = itens[0];
                txtIdLocacao.Text = item.IdLocacao.ToString();
                txtIdFilme.Text = item.IdFilme.ToString();
                txtValor.Text = item.Valor.ToString("F2");
            }
            else if (itens.Count > 1)
            {
                MessageBox.Show("Mais de um item encontrado. Por favor, refine a busca para um único item.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Você pode exibir os itens na grid para o usuário escolher
            }
            else
            {
                MessageBox.Show("Nenhum item encontrado com os critérios informados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bntExcluir_Click(object sender, EventArgs e)
        {
            if (dgvItensLocacao.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item na tabela para excluir.");
                return;
            }

            // Obtém o idItem, que é a chave primária usada no Delete()
            int idItem = Convert.ToInt32(dgvItensLocacao.CurrentRow.Cells["idItem"].Value);

            ItemLocacao itemLocacao = new ItemLocacao
            {
                IdItem = idItem
            };

            DialogResult confirm = MessageBox.Show(
                "Tem certeza que deseja excluir este item de locação?",
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                if (itemLocacao.Delete())
                {
                    MessageBox.Show("Item de locação excluído com sucesso.");

                    // Atualize a tabela — idealmente filtrando pelo idLocacao do item removido,
                    // para isso você pode pegar o idLocacao da linha também:
                    int idLocacao = Convert.ToInt32(dgvItensLocacao.CurrentRow.Cells["idLocacao"].Value);
                    CarregarItemLocacao(idLocacao);

                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao excluir o item de locação.");
                }
            }
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            int? idLocacao = null;
            int? idFilme = null;

            if (!string.IsNullOrWhiteSpace(txtIdLocacao.Text))
            {
                if (int.TryParse(txtIdLocacao.Text, out int idL) && idL > 0)
                    idLocacao = idL;
                else
                {
                    MessageBox.Show("Por favor, insira um ID válido para a locação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtIdFilme.Text))
            {
                if (int.TryParse(txtIdFilme.Text, out int idF) && idF > 0)
                    idFilme = idF;
                else
                {
                    MessageBox.Show("Por favor, insira um ID válido para o filme.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (idLocacao == null && idFilme == null)
            {
                MessageBox.Show("Por favor, preencha o ID da locação ou o ID do filme para realizar a busca!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<ItemLocacao> resultados = ItemLocacao.ReadByLocacaoOrFilme(idLocacao, idFilme);

            if (resultados.Count > 0)
            {
                dgvItensLocacao.DataSource = resultados;
                dgvItensLocacao.ClearSelection();

                // Opcional: preencher campos com o primeiro resultado encontrado
                var primeiro = resultados[0];
                txtIdLocacao.Text = primeiro.IdLocacao.ToString();
                txtIdFilme.Text = primeiro.IdFilme.ToString();
                txtValor.Text = primeiro.Valor.ToString("F2");
            }
            else
            {
                MessageBox.Show("Nenhum item de locação encontrado para os critérios informados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvItensLocacao.DataSource = null;
                LimparCampos();
            }
        }

        public static decimal? GetValorPorFilme(int idFilme)
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT valor FROM ItemLocacao WHERE idFilme = @idFilme LIMIT 1;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idFilme", idFilme);

            object resultado = cmd.ExecuteScalar();
            if (resultado != null && decimal.TryParse(resultado.ToString(), out decimal valor))
            {
                return valor;
            }

            return null; // Valor não encontrado
        }

        private void ItemLocacaoForms_Load(object sender, EventArgs e)
        {
            AtualizarTabela();
        }

        private void bntAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarTabela();
        }
    }
}
