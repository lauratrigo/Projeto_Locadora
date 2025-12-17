using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
    public partial class ClienteForms : Form
    {
        private Cliente clienteEditando = null;
        private Cliente clienteLogado;
        private bool modoRestrito; // Se true, esconde botões de edição/exclusão/salvar


        public DataGridView DataGridClientes
        {
            get { return dgvClientes; }
        }

        public ClienteForms()
        {
            InitializeComponent();
            clienteLogado = null; // ou algum valor padrão
        }

        public ClienteForms(Cliente cliente)
        {
            InitializeComponent();
            clienteLogado = cliente;
            modoRestrito = false;
        }

        // Construtor para modo restrito (novo cliente, sem edição)
        public ClienteForms(bool modoRestrito)
        {
            InitializeComponent();
            this.modoRestrito = modoRestrito;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Atualiza a sessão com o nome do cliente que está se cadastrando
            string nomeDigitado = txtNome.Text.Trim();
            UsuarioSessaoDAO sessao = new UsuarioSessaoDAO();
            sessao.AtualizarUsuarioSessao(nomeDigitado, "cliente");

            // verifica se os campos obrigatórios foram preenchidos
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtCpf.Text) ||
                string.IsNullOrWhiteSpace(txtTelefone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtEndereco.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios");
                return;
            }
            // verifica se o cpf está no formato correto
            if (!txtCpf.MaskCompleted)
            {
                MessageBox.Show("Por favor, insira um CPF válido");
                return;
            }
            // Cria um novo objeto Cliente com os dados dos campos de texto
            Cliente cliente = new Cliente
            {
                Nome = txtNome.Text,
                Cpf = txtCpf.Text,
                Telefone = txtTelefone.Text,
                Email = txtEmail.Text,
                Endereco = txtEndereco.Text
            };

            // Salva o cliente no banco de dados
            if (cliente.Create())
            {
                MessageBox.Show("Cliente adicionado com sucesso!"); // Exibe mensagem de sucesso
                AtualizarTabela(); // Atualiza o DataGridView com os novos dados
                LimparCampos();    // Limpa os campos do formulário
            }
            else
            {
                MessageBox.Show("Erro ao adicionar cliente."); 
            }
        }

        // Método que atualiza o DataGridView com todos os clientes do banco
        private void AtualizarTabela()
        {
            List<Cliente> clientes = Cliente.ReadAll();

            var listaComNivel = clientes.Select(c => new
            {
                c.IdCliente,
                c.Nome,
                c.Cpf,
                c.Telefone,
                c.Email,
                c.Endereco,
                NivelAcesso = c.NivelAcesso // incluído, mas escondido
            }).ToList();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaComNivel;
            dgvClientes.ClearSelection();

            if (dgvClientes.Columns["NivelAcesso"] != null)
                dgvClientes.Columns["NivelAcesso"].Visible = false;  // ESCONDER a coluna no grid
        }
        private void bntAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarTabela(); // Chama o método para recarregar os dados
        }

        // Método que limpa todos os campos de entrada do formulário
        private void LimparCampos()
        {
            txtNome.Clear();       
            txtCpf.Clear();        
            txtTelefone.Clear();   
            txtEmail.Clear();      
            txtEndereco.Clear();   
        }
        private void bntLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void bntEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                // Obtém o ID do cliente selecionado na DataGridView
                int idCliente = Convert.ToInt32(dgvClientes.CurrentRow.Cells["IdCliente"].Value);

                // Carrega os dados do cliente com o ID
                Cliente cliente = Cliente.ReadByID(idCliente);

                if (cliente != null)
                {
                    // Preenche os campos do formulário com os dados do cliente selecionado
                    txtNome.Text = cliente.Nome;
                    txtCpf.Text = cliente.Cpf;
                    txtTelefone.Text = cliente.Telefone;
                    txtEmail.Text = cliente.Email;
                    txtEndereco.Text = cliente.Endereco;

                    // Agora, o objeto clienteEditando vai armazenar o cliente que está sendo editado
                    clienteEditando = cliente;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente na tabela para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // botão para buscar o cliente
        private void bntBuscar_Click(object sender, EventArgs e)
        {
            // Verifica se o campo de pesquisa não está vazio
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Por favor, forneça um nome de cliente para busca");
                return;
            }

            string nomeCliente = txtNome.Text.Trim().ToLower(); // Converte para minúsculas

            // Puxa todos os clientes do banco
            List<Cliente> clientes = Cliente.ReadAll();

            // Filtra a lista de clientes, buscando o nome (sem diferenciar maiúsculas e minúsculas)
            var clientesEncontrados = clientes.Where(c => c.Nome.ToLower().Contains(nomeCliente)).ToList();

            // Verifica se encontrou clientes
            if (clientesEncontrados.Count > 0)
            {
                // Preenche o DataGridView com os resultados
                dgvClientes.DataSource = clientesEncontrados;
                dgvClientes.ClearSelection(); // Limpa qualquer seleção existente
                MessageBox.Show($"{clientesEncontrados.Count} cliente(s) encontrado(s).");
            }
            else
            {
                MessageBox.Show("Nenhum cliente encontrado com esse nome.");
                dgvClientes.DataSource = null; // Limpa o DataGridView caso nenhum cliente seja encontrado
            }
        }


        private void bntExcluir_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cliente na tabela.");
                return;
            }

            // Obtém o ID do cliente selecionado
            int idCliente = Convert.ToInt32(dgvClientes.CurrentRow.Cells["IdCliente"].Value);
            Cliente cliente = Cliente.ReadByID(idCliente);

            if (cliente != null)
            {
                // Confirmação antes de excluir o cliente
                DialogResult confirm = MessageBox.Show(
                    "Tem certeza que deseja excluir este cliente?",
                    "Confirmação de Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    // Exclui o cliente
                    if (cliente.Delete())
                    {
                        MessageBox.Show("Cliente excluído com sucesso.");
                        AtualizarTabela();  // Atualiza a tabela após exclusão
                        LimparCampos();  // Limpa os campos
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o cliente.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Cliente não encontrado.");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (clienteEditando == null)
            {
                MessageBox.Show("Nenhum cliente foi carregado para edição.");
                return;
            }

            // Atualiza o cliente com os novos dados
            clienteEditando.Nome = txtNome.Text;
            clienteEditando.Cpf = txtCpf.Text;
            clienteEditando.Telefone = txtTelefone.Text;
            clienteEditando.Email = txtEmail.Text;
            clienteEditando.Endereco = txtEndereco.Text;

            // Tenta atualizar no banco de dados
            if (clienteEditando.Update())
            {
                MessageBox.Show("Edição salva com sucesso!");
                AtualizarTabela();     // Recarrega a tabela
                LimparCampos();        // Limpa os campos
                clienteEditando = null; // Limpa a referência do cliente editado
            }
            else
            {
                MessageBox.Show("Erro ao salvar as alterações.");
            }
        }

        private void ClienteForms_Load(object sender, EventArgs e)
        {
            AtualizarTabela();
            if (modoRestrito)
            {
                // Esconde botões e DataGridView no modo restrito (cadastro novo)
                bntEditar.Visible = false;
                bntExcluir.Visible = false;
                btnSalvar.Visible = false;
                dgvClientes.Visible = true;
            }
            else if (clienteLogado != null && clienteLogado.NivelAcesso == "Comum")
            {
                // Cliente comum: esconde botões que ele não deve usar
                bntEditar.Visible = false;
                bntExcluir.Visible = false;
                btnSalvar.Visible = false;
                dgvClientes.Visible = false;
            }
            else
            {
                // Admin ou outro nível: mostrar tudo
                bntEditar.Visible = true;
                bntExcluir.Visible = true;
                btnSalvar.Visible = true;
                dgvClientes.Visible = true;
            }
        }



    }
}
