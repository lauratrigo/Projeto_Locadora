using MySql.Data.MySqlClient;
using Projeto_Final_Prog_III;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Prog_III;  // Importa o namespace da classe ItemLocacao


namespace Projeto_Prog_III
{
    public class ItemLocacao
    {
        public int IdItem { get; set; }
        public int IdLocacao { get; set; } // foreign key
        public int IdFilme { get; set; }   // foreign key
        public decimal Valor { get; set; }

        // método para criar
        public bool Create()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = @"INSERT INTO Itens_Locacao (idLocacao, idFilme, valor) VALUES (@idLocacao, @idFilme, @valor);";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idLocacao", this.IdLocacao);
            cmd.Parameters.AddWithValue("@idFilme", this.IdFilme);
            cmd.Parameters.AddWithValue("@valor", this.Valor);

            bool executou = cmd.ExecuteNonQuery() > 0;
            this.IdItem = (int)cmd.LastInsertedId;
            return executou;
        }

        // método para deletar
        public bool Delete()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "DELETE FROM Itens_Locacao WHERE idItem = @idItem;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idItem", this.IdItem);

            return cmd.ExecuteNonQuery() > 0;
        }

        // método para atualizar
        public bool Update()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = @"UPDATE Itens_Locacao SET idLocacao = @idLocacao, idFilme = @idFilme, valor = @valor WHERE idItem = @idItem;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idLocacao", this.IdLocacao);
            cmd.Parameters.AddWithValue("@idFilme", this.IdFilme);
            cmd.Parameters.AddWithValue("@valor", this.Valor);
            cmd.Parameters.AddWithValue("@idItem", this.IdItem);

            return cmd.ExecuteNonQuery() > 0;
        }

        // método para ler
        public static List<ItemLocacao> ReadAll()
        {
            List<ItemLocacao> lista = new List<ItemLocacao>();
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Itens_Locacao ORDER BY idItem;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ItemLocacao item = new ItemLocacao();
                item.IdItem = reader.GetInt32("idItem");
                item.IdLocacao = reader.GetInt32("idLocacao");
                item.IdFilme = reader.GetInt32("idFilme");
                item.Valor = reader.GetDecimal("valor");

                lista.Add(item);
            }

            reader.Close();
            return lista;
        }

        public static ItemLocacao ReadByID(int idItem)
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Itens_Locacao WHERE idItem = @idItem;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idItem", idItem);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                ItemLocacao item = new ItemLocacao();
                item.IdItem = reader.GetInt32("idItem");
                item.IdLocacao = reader.GetInt32("idLocacao");
                item.IdFilme = reader.GetInt32("idFilme");
                item.Valor = reader.GetDecimal("valor");

                reader.Close();
                return item;
            }

            reader.Close();
            return null;
        }

        // Método para ler todos os itens de uma locação específica
        public static List<ItemLocacao> ReadByLocacao(int idLocacao)
        {
            List<ItemLocacao> lista = new List<ItemLocacao>();
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Itens_Locacao WHERE idLocacao = @idLocacao;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idLocacao", idLocacao);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ItemLocacao item = new ItemLocacao();
                item.IdItem = reader.GetInt32("idItem");
                item.IdLocacao = reader.GetInt32("idLocacao");
                item.IdFilme = reader.GetInt32("idFilme");
                item.Valor = reader.GetDecimal("valor");

                lista.Add(item);
            }

            reader.Close();
            return lista;
        }

        public static List<ItemLocacao> ReadByLocacaoOrFilme(int? idLocacao, int? idFilme)
        {
            List<ItemLocacao> lista = new List<ItemLocacao>();
            MySqlConnection conexao = Banco.GetConexao();

            // Montar a query dinamicamente
            string sql = "SELECT * FROM Itens_Locacao WHERE 1=1 ";

            if (idLocacao.HasValue)
                sql += "AND idLocacao = @idLocacao ";
            if (idFilme.HasValue)
                sql += "AND idFilme = @idFilme ";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            if (idLocacao.HasValue)
                cmd.Parameters.AddWithValue("@idLocacao", idLocacao.Value);
            if (idFilme.HasValue)
                cmd.Parameters.AddWithValue("@idFilme", idFilme.Value);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ItemLocacao item = new ItemLocacao
                {
                    IdItem = reader.GetInt32("idItem"),
                    IdLocacao = reader.GetInt32("idLocacao"),
                    IdFilme = reader.GetInt32("idFilme"),
                    Valor = reader.GetDecimal("valor")
                };
                lista.Add(item);
            }

            reader.Close();
            return lista;
        }


        // método para obter o valor do aluguel de um filme (usado no ConfirmarLcoacaoForms.cs)
        public static decimal? GetValorPorFilme(int idFilme)
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT valor FROM Itens_Locacao WHERE idFilme = @idFilme LIMIT 1;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idFilme", idFilme);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                decimal valor = reader.GetDecimal("valor");
                reader.Close();
                return valor;
            }

            reader.Close();
            return null;  // Caso não encontre, retorna null
        }

        public override string ToString()
        {
            return $"Locação: {IdLocacao} | Filme: {IdFilme} | Valor: R$ {Valor:F2}";
        }
    }
}
