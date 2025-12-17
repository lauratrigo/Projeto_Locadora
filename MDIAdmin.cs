using MySql.Data.MySqlClient;
using Projeto_Final_Prog_III;
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
using System.IO;

namespace Projeto_Final_Prog_III
{
    public partial class MDIAdmin : Form
    {
        private Usuarios usuarioLogado;

        public MDIAdmin(Usuarios usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Passa o usuário logado para o formulário ClienteForms
            ClienteForms clienteForm = new ClienteForms(false);
            clienteForm.MdiParent = this;  // Define que será filho do MDI
            clienteForm.Show();
        }

        private void MDIAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abre o formulário de usuários passando o usuário logado para controlar acesso
            UsuariosForms usuarioForm = new UsuariosForms(usuarioLogado);
            usuarioForm.MdiParent = this;
            usuarioForm.Show();
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuncionarioForms funcionarioForms = new FuncionarioForms();
            funcionarioForms.MdiParent = this;
            funcionarioForms.Show();
        }

        private void filmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilmeForms filmesForm = new FilmeForms();
            filmesForm.MdiParent = this;
            filmesForm.Show();
        }

        private void locaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocacaoForms locacaoForm = new LocacaoForms();
            locacaoForm.MdiParent = this;
            locacaoForm.Show();
        }

        private void itemLocaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemLocacaoForms itemLocacao = new ItemLocacaoForms();
            itemLocacao.MdiParent = this;
            itemLocacao.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClienteForms clienteForm = this.MdiChildren.OfType<ClienteForms>().FirstOrDefault();


            if (clienteForm == null)
            {
                clienteForm = new ClienteForms(false);
                clienteForm.MdiParent = this;
                clienteForm.Show();
            }

            // Usar a propriedade pública DataGridClientes, não dgvClientes diretamente
            ExportadorPDF.ExportarDataGridViewParaPDF(clienteForm.DataGridClientes, "Lista de Clientes", "ClientesExportados.pdf");

        }

        private void usuáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UsuariosForms usuarioForm = this.MdiChildren.OfType<UsuariosForms>().FirstOrDefault();

            if (usuarioForm == null)
            {
                usuarioForm = new UsuariosForms(usuarioLogado);  // Passe o usuário logado, se precisar
                usuarioForm.MdiParent = this;
                usuarioForm.Show();
            }

            ExportadorPDF.ExportarDataGridViewParaPDF(usuarioForm.DataGridUsuarios, "Lista de Usuários", "UsuariosExportados.pdf");
        }

        private void funcionáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FuncionarioForms funcionarioForm = this.MdiChildren.OfType<FuncionarioForms>().FirstOrDefault();

            if (funcionarioForm == null)
            {
                funcionarioForm = new FuncionarioForms(); 
                funcionarioForm.MdiParent = this;
                funcionarioForm.Show();
            }

            ExportadorPDF.ExportarDataGridViewParaPDF(funcionarioForm.DataGridFuncionarios, "Lista de Funcionários", "FuncionariosExportados.pdf");
        }

        private void filmesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FilmeForms filmesForm = this.MdiChildren.OfType<FilmeForms>().FirstOrDefault();

            if (filmesForm == null)
            {
                filmesForm = new FilmeForms(); 
                filmesForm.MdiParent = this;
                filmesForm.Show();
            }

            ExportadorPDF.ExportarDataGridViewParaPDF(filmesForm.DataGridFilmes, "Lista de Filmes", "FilmesExportados.pdf");
        }

        private void locaçõesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LocacaoForms locacoesForm = this.MdiChildren.OfType<LocacaoForms>().FirstOrDefault();

            if (locacoesForm == null)
            {
                locacoesForm = new LocacaoForms();
                locacoesForm.MdiParent = this;
                locacoesForm.Show();
            }

            ExportadorPDF.ExportarDataGridViewParaPDF(locacoesForm.DataGridLocacoes, "Lista de Locações", "LocacoesExportadas.pdf");
        }

        private void itemLocaçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemLocacaoForms itemLocacaoForm = this.MdiChildren.OfType<ItemLocacaoForms>().FirstOrDefault();

            if (itemLocacaoForm == null)
            {
                itemLocacaoForm = new ItemLocacaoForms(); 
                itemLocacaoForm.MdiParent = this;
                itemLocacaoForm.Show();
            }

            ExportadorPDF.ExportarDataGridViewParaPDF(itemLocacaoForm.DataGridItemLocacao, "Lista de Itens da Locação", "ItensLocacaoExportados.pdf");
        }

        private void backupServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupServiceForms backupService = new BackupServiceForms();
            backupService.MdiParent = this; 
            backupService.Show();
        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv|Todos os arquivos (*.*)|*.*";
            openFileDialog.Title = "Selecione o arquivo CSV com nome da tabela na primeira linha";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminho = openFileDialog.FileName;

                try
                {
                    string[] linhas = File.ReadAllLines(caminho, Encoding.UTF8);

                    if (linhas.Length < 3)
                    {
                        MessageBox.Show("Arquivo CSV inválido. Deve conter pelo menos 3 linhas (tabela, cabeçalho e dados).");
                        return;
                    }

                    // Detecta a tabela
                    string primeiraLinha = linhas[0].Trim();
                    if (!primeiraLinha.StartsWith("#tabela="))
                    {
                        MessageBox.Show("A primeira linha do CSV deve conter o nome da tabela: #tabela=NomeTabela");
                        return;
                    }

                    string nomeTabela = primeiraLinha.Replace("#tabela=", "").Trim();

                    // Lê cabeçalho
                    string[] cabecalho = linhas[1].Split(',');

                    // Lê colunas da tabela no banco
                    List<string> colunasBanco = new List<string>();
                    MySqlConnection connLeitura = Banco.GetConexao(); // aqui a conexão permanece aberta
                    string sqlColunas = $"SHOW COLUMNS FROM {nomeTabela}";
                    MySqlCommand cmdColunas = new MySqlCommand(sqlColunas, connLeitura);
                    using (MySqlDataReader reader = cmdColunas.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            colunasBanco.Add(reader.GetString("Field"));
                        }
                    }

                    // Processa cada linha de dados
                    for (int i = 2; i < linhas.Length; i++)
                    {
                        string[] dados = linhas[i].Split(',');

                        List<string> colunasValidas = new List<string>();
                        List<string> parametros = new List<string>();
                        List<MySqlParameter> valoresParametros = new List<MySqlParameter>();

                        for (int j = 0; j < cabecalho.Length && j < dados.Length; j++)
                        {
                            string colunaCSV = cabecalho[j].Trim();
                            if (colunasBanco.Contains(colunaCSV))
                            {
                                string valor = dados[j].Trim();
                                colunasValidas.Add(colunaCSV);
                                string nomeParametro = "@" + colunaCSV;
                                parametros.Add(nomeParametro);
                                valoresParametros.Add(new MySqlParameter(nomeParametro, valor));
                            }
                        }

                        // Executa o INSERT (sem usar using)
                        MySqlConnection connInsert = Banco.GetConexao();
                        if (connInsert.State != ConnectionState.Open)
                        {
                            MessageBox.Show("Conexão não está aberta.");
                            return;
                        }

                        string sqlInsert = $"INSERT INTO {nomeTabela} ({string.Join(",", colunasValidas)}) VALUES ({string.Join(",", parametros)})";
                        MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, connInsert);
                        cmdInsert.Parameters.AddRange(valoresParametros.ToArray());
                        cmdInsert.ExecuteNonQuery();
                    }

                    MessageBox.Show("Importação concluída com sucesso!", "Sucesso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao importar: " + ex.Message);
                }
            }
        }

        private void graficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraficosForms grafics = new GraficosForms();
            grafics.MdiParent = this;
            grafics.Show();
        }
    }
}


