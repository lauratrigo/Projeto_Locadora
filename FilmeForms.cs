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
    public partial class FilmeForms : Form
    {
        private Filme filmeEditando = null; // declarar isso no escopo da classe (fora dos métodos)

        public FilmeForms()
        {
            InitializeComponent();

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

            cmbDisponivel.Items.Add("Disponível");  // preenche a combobox da disponibilidade do filme
            cmbDisponivel.Items.Add("Indisponível");
            cmbDisponivel.SelectedIndex = -1;  // nenhuma opção é selecionada
        }

        public DataGridView DataGridFilmes
        {
            get { return dgvFilmes; }  // Use o nome correto do seu DataGridView de filmes
        }

        // método para carregar os filmes no datagridview
        private void CarregarFilmes()
        {
            List<Filme> listaFilmes = Filme.ReadAll();  // chama o método ReadAll da classe Filme para obter todos os filmes            
            dgvFilmes.DataSource = listaFilmes; // associa a lista de filmes ao datagridview
        }

        // método para limpar os campos do formulário após o filme ser adicionado
        private void LimparCampos()
        {
            txtNome.Clear();
            txtAno.Clear();
            txtDiretor.Clear();
            txtDuracao.Clear();
            cmbGenero.SelectedIndex = -1;
            cmbDisponivel.SelectedIndex = -1;
            btnSalvarFilmeEditado.Tag = null; // limpa o estado de edição
        }

        private void FilmeForms_Load(object sender, EventArgs e)
        {
            CarregarFilmes();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
             string.IsNullOrWhiteSpace(txtAno.Text) ||
             string.IsNullOrWhiteSpace(txtDiretor.Text) ||
             string.IsNullOrWhiteSpace(txtDuracao.Text) ||
             cmbGenero.SelectedIndex == -1 ||
             cmbDisponivel.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, preencha todos os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtDuracao.Text, out int duracao))
            {
                MessageBox.Show("Duração inválida. Digite apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtAno.Text, out int ano))
            {
                MessageBox.Show("Ano inválido. Digite apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool disponivel = cmbDisponivel.SelectedItem.ToString() == "Disponível";

            Filme novoFilme = new Filme
            {
                Titulo = txtNome.Text,
                Genero = cmbGenero.SelectedItem.ToString(),
                Duracao = duracao,
                AnoLancamento = ano,
                Diretor = txtDiretor.Text,
                Disponivel = disponivel
            };

            // tenta criar o filme no banco de dados
            if (novoFilme.Create())
            {
                MessageBox.Show("Filme adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarFilmes(); // se quiser atualizar o DataGridView após adicionar
            }
            else
            {
                MessageBox.Show("Erro ao adicionar o filme", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvFilmes.CurrentRow != null)
            {
                // Obtém o ID do filme selecionado na DataGridView
                int idFilme = Convert.ToInt32(dgvFilmes.CurrentRow.Cells["idFilme"].Value);

                // Carrega os dados do filme com o ID
                Filme filme = Filme.ReadByID(idFilme);

                if (filme != null)
                {
                    // Preenche os campos do formulário com os dados do filme selecionado
                    txtNome.Text = filme.Titulo;
                    txtAno.Text = filme.AnoLancamento.ToString();
                    txtDuracao.Text = filme.Duracao.ToString();
                    txtDiretor.Text = filme.Diretor;
                    cmbGenero.SelectedItem = filme.Genero;
                    cmbDisponivel.SelectedItem = filme.Disponivel ? "Disponível" : "Indisponível";

                    // Armazena o objeto filme que está sendo editado
                    filmeEditando = filme;

                    // Também atualiza o Tag do botão para controle no salvar, se quiser manter
                    btnSalvarFilmeEditado.Tag = filme.IdFilme;
                }
                else
                {
                    MessageBox.Show("Filme não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um filme na tabela para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalvarFilmeEditado_Click(object sender, EventArgs e)
        {
            if (filmeEditando == null)
            {
                MessageBox.Show("Nenhum filme foi carregado para edição.");
                return;
            }

            // Validações básicas (pode melhorar conforme necessário)
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtAno.Text) ||
                string.IsNullOrWhiteSpace(txtDuracao.Text) ||
                string.IsNullOrWhiteSpace(txtDiretor.Text) ||
                cmbGenero.SelectedIndex == -1 ||
                cmbDisponivel.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            // Tenta converter ano e duração
            if (!int.TryParse(txtAno.Text, out int ano) || !int.TryParse(txtDuracao.Text, out int duracao))
            {
                MessageBox.Show("Ano ou duração inválidos.");
                return;
            }

            // Atualiza os dados do filmeEditando com os dados do formulário
            filmeEditando.Titulo = txtNome.Text;
            filmeEditando.AnoLancamento = ano;
            filmeEditando.Duracao = duracao;
            filmeEditando.Diretor = txtDiretor.Text;
            filmeEditando.Genero = cmbGenero.SelectedItem.ToString();
            filmeEditando.Disponivel = cmbDisponivel.SelectedItem.ToString() == "Disponível";

            // Tenta salvar as alterações no banco
            if (filmeEditando.Update())
            {
                MessageBox.Show("Edição salva com sucesso!");
                CarregarFilmes();    // Atualiza o DataGridView com os dados novos
                LimparCampos();      // Limpa os campos do formulário
                filmeEditando = null; // Limpa a referência ao filme editado
            }
            else
            {
                MessageBox.Show("Erro ao salvar as alterações.");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verifica se alguma linha está selecionada no DataGridView
            if (dgvFilmes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um filme na tabela para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtém o ID do filme selecionado
            int idFilme = Convert.ToInt32(dgvFilmes.CurrentRow.Cells["IdFilme"].Value);
            Filme filme = Filme.ReadByID(idFilme);

            if (filme != null)
            {
                // Confirmação com o usuário antes de excluir
                DialogResult confirmacao = MessageBox.Show(
                    $"Tem certeza que deseja excluir o filme \"{filme.Titulo}\"?",
                    "Confirmação de Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacao == DialogResult.Yes)
                {
                    if (filme.Delete())
                    {
                        MessageBox.Show("Filme excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarFilmes();  // Atualiza o DataGridView com os dados restantes
                        LimparCampos();    // Limpa os campos do formulário
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o filme.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Filme não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Busca todos os filmes
            List<Filme> todosFilmes = Filme.ReadAll();

            // Filtros baseados nos campos preenchidos
            string tituloFiltro = txtNome.Text.Trim().ToLower();
            string generoFiltro = cmbGenero.SelectedItem?.ToString().ToLower();
            string diretorFiltro = txtDiretor.Text.Trim().ToLower();
            string duracaoTexto = txtDuracao.Text.Trim();
            string anoTexto = txtAno.Text.Trim();
            string disponibilidadeFiltro = cmbDisponivel.SelectedItem?.ToString();

            // Aplica filtros
            var filmesFiltrados = todosFilmes.Where(f =>
                (string.IsNullOrEmpty(tituloFiltro) || f.Titulo.ToLower().Contains(tituloFiltro)) &&
                (string.IsNullOrEmpty(generoFiltro) || f.Genero.ToLower() == generoFiltro) &&
                (string.IsNullOrEmpty(diretorFiltro) || f.Diretor.ToLower().Contains(diretorFiltro)) &&
                (string.IsNullOrEmpty(duracaoTexto) || (int.TryParse(duracaoTexto, out int duracao) && f.Duracao == duracao)) &&
                (string.IsNullOrEmpty(anoTexto) || (int.TryParse(anoTexto, out int ano) && f.AnoLancamento == ano)) &&
                (string.IsNullOrEmpty(disponibilidadeFiltro) ||
                    (disponibilidadeFiltro == "Disponível" && f.Disponivel) ||
                    (disponibilidadeFiltro == "Indisponível" && !f.Disponivel))
            ).ToList();

            // Verifica se encontrou resultados
            if (filmesFiltrados.Any())
            {
                dgvFilmes.DataSource = filmesFiltrados;
                dgvFilmes.ClearSelection();
                MessageBox.Show($"{filmesFiltrados.Count} filme(s) encontrado(s).", "Resultado da Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvFilmes.DataSource = null;
                MessageBox.Show("Nenhum filme encontrado com os critérios informados.", "Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarFilmes();
            // chama o método para carregar todos os filmes do banco de dados
            List<Filme> listaFilmes = Filme.ReadAll();

            // atualiza a fonte de dados do datagridview
            dgvFilmes.DataSource = listaFilmes;

            // limpa a seleção após atualizar a lista
            dgvFilmes.ClearSelection();

            // mensagem de feedback ao usuário que a lista foi atualizada
            MessageBox.Show("Lista de filmes atualizada com sucesso!", "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
