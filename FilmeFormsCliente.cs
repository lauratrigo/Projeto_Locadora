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
    public partial class FilmeFormsCliente : Form
    {
        private Usuarios usuarioLogado;

        public FilmeFormsCliente(Usuarios usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;  // Salva o usuário logado

            // preenche a combobox dos gêneros dos filmes
            cmbGenero.Items.Clear();
            cmbGenero.Items.Add("ação");
            cmbGenero.Items.Add("comédia");
            cmbGenero.Items.Add("drama");
            cmbGenero.Items.Add("ficção científica");
            cmbGenero.Items.Add("terror");
            cmbGenero.Items.Add("romance");
            cmbGenero.Items.Add("animação");
            cmbGenero.Items.Add("documentário");
            cmbGenero.SelectedIndex = -1;  // nenhuma opção é selecionada

            // preenche a combobox da disponibilidade do filme
            cmbDisponivel.Items.Add("Disponível");
            cmbDisponivel.Items.Add("Indisponível");
            cmbDisponivel.SelectedIndex = -1;  // nenhuma opção é selecionada

            // Faz o formulário abrir maximizado
            this.WindowState = FormWindowState.Maximized;
        }

        // método para carregar os filmes no datagridview
        private void CarregarFilmes()
        {
            // chama o método ReadAll da classe Filme para obter todos os filmes
            List<Filme> listaFilmes = Filme.ReadAll();

            // associa a lista de filmes ao datagridview
            dgvFilmes.DataSource = listaFilmes;
        }

        private void FilmeFormsCliente_Load(object sender, EventArgs e)
        {
            CarregarFilmes(); // carrega os filmes ao abrir o formulário
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            string titulo = txtNome.Text.Trim();
            string genero = cmbGenero.SelectedItem?.ToString();
            bool? disponibilidade = null;

            if (cmbDisponivel.SelectedItem != null)
            {
                string valor = cmbDisponivel.SelectedItem.ToString();
                if (valor == "Disponível")
                    disponibilidade = true;
                else if (valor == "Indisponível")
                    disponibilidade = false;
            }

            // Filtros aplicados
            var filmes = Filme.ReadAll();

            // Filtros aplicados ao listar filmes
            if (!string.IsNullOrEmpty(titulo))
                filmes = filmes.Where(f => f.Titulo.ToLower().Contains(titulo.ToLower())).ToList();

            if (!string.IsNullOrEmpty(genero))
                filmes = filmes.Where(f => f.Genero == genero).ToList();

            if (disponibilidade != null)
                filmes = filmes.Where(f => f.Disponivel == disponibilidade).ToList();

            dgvFilmes.DataSource = filmes;

            if (!filmes.Any())
            {
                MessageBox.Show("Nenhum filme encontrado com os filtros aplicados.");
            }
        }

        private void btnAlugar_Click(object sender, EventArgs e)
        {
            string titulo = txtNome.Text.Trim();

            if (string.IsNullOrEmpty(titulo))
            {
                MessageBox.Show("Digite ou selecione um filme.");
                return;
            }

            var filme = Filme.ReadAll().FirstOrDefault(f => f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (filme == null)
            {
                MessageBox.Show("Filme não encontrado.");
                return;
            }

            if (!filme.Disponivel)
            {
                MessageBox.Show("Filme indisponível.");
                return;
            }

            var confirmarForm = new ConfirmarLocacaoForms(filme, usuarioLogado);
            confirmarForm.ShowDialog(); // abre o form modal
        }

        private void bntHistorico_Click(object sender, EventArgs e)
        {
            try
            {
                // Busca o cliente vinculado ao usuário logado
                Cliente cliente = Cliente.BuscarPorUsuario(usuarioLogado.IdUsuario);

                if (cliente == null)
                {
                    MessageBox.Show("Cliente não encontrado para o usuário logado.");
                    return;
                }

                // Busca o histórico de locações do cliente
                List<Locacao> historicoLocacoes = Locacao.GetHistoricoDeLocacao(cliente.IdCliente);

                if (historicoLocacoes.Any())
                {
                    dgvHistorico.DataSource = historicoLocacoes;
                }
                else
                {
                    dgvHistorico.DataSource = null;
                    MessageBox.Show("Nenhuma locação encontrada para este cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o histórico de locações: {ex.Message}");
            }
        }
    }
}
