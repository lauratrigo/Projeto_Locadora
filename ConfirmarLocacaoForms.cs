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
    public partial class ConfirmarLocacaoForms : Form
    {
        private Filme filmeSelecionado;
        private Usuarios usuarioLogado;
        public ConfirmarLocacaoForms(Filme filme, Usuarios usuario)
        {
            InitializeComponent();
            filmeSelecionado = filme;
            usuarioLogado = usuario;

            // Exibe o nome do filme no campo de texto
            txtNome.Text = filmeSelecionado.Titulo;

            // Configura o valor do aluguel (suponha que o valor esteja na classe Filme)
            //txtValor.Text = filmeSelecionado.ValorAluguel.ToString("C"); // formato de moeda

            // Configura a data de locação (pode ser a data atual)
            dtpLocacao.Value = DateTime.Now;

            // Configura a data de devolução (7 dias após a data de locação)
            dtpDevolucao.Value = DateTime.Now.AddDays(7);
            dtpDevolucao.Enabled = false; // Não permite alteração na data de devolução

            CarregarDados();
        }

        private void CarregarDados()
        {
            lblNome.Text = filmeSelecionado.Titulo;
            dtpLocacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dtpDevolucao.Text = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy");

            // Buscar valor do filme no banco via ItemLocacao
            decimal? valor = ItemLocacao.GetValorPorFilme(filmeSelecionado.IdFilme);
            if (valor.HasValue)
            {
                lblValor.Text = $"R$ {valor.Value:0.00}";
            }
            else
            {
                lblValor.Text = "Valor não disponível";
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // Data de locação e devolução
                DateTime dataLocacao = DateTime.Now;
                DateTime dataDevolucao = dataLocacao.AddDays(7);

                Cliente cliente = Cliente.BuscarPorUsuario(usuarioLogado.IdUsuario);

                if (cliente == null)
                {
                    MessageBox.Show("Cliente não encontrado para o usuário logado.");
                    return;
                }

                // Recarrega o filme do banco para garantir que está atualizado
                Filme filmeAtualizado = Filme.ReadByID(filmeSelecionado.IdFilme);
                if (filmeAtualizado == null || !filmeAtualizado.Disponivel)
                {
                    MessageBox.Show("Este filme já foi alugado por outro cliente e está indisponível.");
                    this.Close();
                    return;
                }

                // Criação da locação
                Locacao novaLocacao = new Locacao
                {
                    IdCliente = cliente.IdCliente,
                    DataLocacao = dataLocacao,
                    DataDevolucao = dataDevolucao,
                    DataReal = null
                };

                if (novaLocacao.Create())
                {
                    decimal? valor = ItemLocacao.GetValorPorFilme(filmeAtualizado.IdFilme);
                    if (valor != null)
                    {
                        ItemLocacao novoItem = new ItemLocacao
                        {
                            IdLocacao = novaLocacao.IdLocacao,
                            IdFilme = filmeAtualizado.IdFilme,
                            Valor = valor.Value
                        };
                        novoItem.Create();
                    }

                    // Atualiza no banco que o filme está indisponível
                    filmeAtualizado.Disponivel = false;
                    filmeAtualizado.Update();

                    MessageBox.Show("Locação confirmada com sucesso!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao realizar a locação.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Fecha o formulário sem realizar a locação
        }
    }
}
