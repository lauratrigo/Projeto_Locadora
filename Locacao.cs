using MySql.Data.MySqlClient;
using Projeto_Final_Prog_III;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Final_Prog_III
{
    public class Locacao
    {
        public int IdLocacao { get; set; }
        public int IdCliente { get; set; }  // foreign key para a tabela Clientes
        public DateTime DataLocacao { get; set; }  // data da locação
        public DateTime DataDevolucao { get; set; }  // data prevista para devolução
        public DateTime? DataReal { get; set; }  // data real de devolução (pode ser nula caso não tenha sido devolvido ainda)


        // método para criar uma nova locação
        public bool Create()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = @"INSERT INTO Locacoes (idCliente, data_locacao, data_devolucao) VALUES (@idCliente, @dataLocacao, @dataDevolucao);";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idCliente", this.IdCliente);
            cmd.Parameters.AddWithValue("@dataLocacao", this.DataLocacao);
            cmd.Parameters.AddWithValue("@dataDevolucao", this.DataDevolucao);

            bool executou = cmd.ExecuteNonQuery() > 0;
            IdLocacao = (int)cmd.LastInsertedId;  // obtém o id da locação recém inserida
            return executou;
        }

        // método para excluir uma locação
        public bool Delete()
        {
            MySqlConnection conexao = Banco.GetConexao();

            // Primeiro exclui os itens da locação
            string sqlItens = "DELETE FROM Itens_Locacao WHERE idLocacao = @idLocacao;";
            MySqlCommand cmdItens = new MySqlCommand(sqlItens, conexao);
            cmdItens.Parameters.AddWithValue("@idLocacao", IdLocacao);
            cmdItens.ExecuteNonQuery(); // Executa, mas não checa retorno, já que pode não ter itens

            // Depois exclui a locação
            string sqlLocacao = "DELETE FROM Locacoes WHERE idLocacao = @idLocacao;";
            MySqlCommand cmdLocacao = new MySqlCommand(sqlLocacao, conexao);
            cmdLocacao.Parameters.AddWithValue("@idLocacao", IdLocacao);

            return cmdLocacao.ExecuteNonQuery() > 0;
        }

        // método para atualizar uma locação
        public bool Update()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = @"UPDATE Locacoes SET idCliente = @idCliente, data_locacao = @dataLocacao, data_devolucao = @dataDevolucao, data_real = @dataReal WHERE idLocacao = @idLocacao;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idCliente", this.IdCliente);
            cmd.Parameters.AddWithValue("@dataLocacao", this.DataLocacao);
            cmd.Parameters.AddWithValue("@dataDevolucao", this.DataDevolucao);
            cmd.Parameters.AddWithValue("@dataReal", this.DataReal ?? (object)DBNull.Value); // caso datareal seja nula
            cmd.Parameters.AddWithValue("@idLocacao", this.IdLocacao);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static List<Locacao> ReadAll()
        {
            List<Locacao> lista = new List<Locacao>();
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Locacoes ORDER BY data_locacao DESC;";  // ordena pelas datas de locação
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Locacao locacao = new Locacao();
                locacao.IdLocacao = reader.GetInt32("idLocacao");
                locacao.IdCliente = reader.GetInt32("idCliente");
                locacao.DataLocacao = reader.GetDateTime("data_locacao");
                locacao.DataDevolucao = reader.GetDateTime("data_devolucao");
                locacao.DataReal = reader.IsDBNull(reader.GetOrdinal("data_real")) ? (DateTime?)null : reader.GetDateTime("data_real");

                lista.Add(locacao);
            }

            reader.Close();
            return lista;
        }

        // método para buscar uma locação pelo id
        public static Locacao ReadByID(int idLocacao)
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Locacoes WHERE idLocacao = @idLocacao;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idLocacao", idLocacao);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Locacao locacao = new Locacao();
                locacao.IdLocacao = reader.GetInt32("idLocacao");
                locacao.IdCliente = reader.GetInt32("idCliente");
                locacao.DataLocacao = reader.GetDateTime("data_locacao");
                locacao.DataDevolucao = reader.GetDateTime("data_devolucao");
                locacao.DataReal = reader.IsDBNull(reader.GetOrdinal("data_real")) ? (DateTime?)null : reader.GetDateTime("data_real");
                reader.Close();
                return locacao;
            }

            reader.Close();
            return null;
        }

        // Método para buscar o histórico de locação de um cliente específico
        public static List<Locacao> GetHistoricoDeLocacao(int idCliente)
        {
            List<Locacao> lista = new List<Locacao>();
            MySqlConnection conexao = Banco.GetConexao();

            // Ajuste para buscar locações de um cliente específico
            string sql = "SELECT * FROM Locacoes WHERE idCliente = @idCliente ORDER BY data_locacao DESC;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Locacao locacao = new Locacao();
                locacao.IdLocacao = reader.GetInt32("idLocacao");
                locacao.IdCliente = reader.GetInt32("idCliente");
                locacao.DataLocacao = reader.GetDateTime("data_locacao");
                locacao.DataDevolucao = reader.GetDateTime("data_devolucao");
                locacao.DataReal = reader.IsDBNull(reader.GetOrdinal("data_real")) ? (DateTime?)null : reader.GetDateTime("data_real");

                lista.Add(locacao);
            }

            reader.Close();
            return lista;
        }

        // método para converter a classe para string
        public override string ToString()
        {
            return $"Locação {IdLocacao} - Cliente {IdCliente} - Data Locação: {DataLocacao:dd/MM/yyyy}";
        }

    }
}
