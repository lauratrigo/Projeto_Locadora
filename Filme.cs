using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projeto_Final_Prog_III
{
    public class Filme
    {
        public int IdFilme { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; } // a duração aparece em minutos
        public int AnoLancamento { get; set; }
        public string Diretor { get; set; }
        public bool Disponivel { get; set; }
        public decimal ValorAluguel { get; set; } // propriedade para o valor do aluguel da locação

        public bool Create()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = @"INSERT INTO Filmes (titulo, genero, duracao, ano_lancamento, diretor, disponivel) VALUES (@titulo, @genero, @duracao, @anoLancamento, @diretor, @disponivel);";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@titulo", this.Titulo);
            cmd.Parameters.AddWithValue("@genero", this.Genero);
            cmd.Parameters.AddWithValue("@duracao", this.Duracao);
            cmd.Parameters.AddWithValue("@anoLancamento", this.AnoLancamento);
            cmd.Parameters.AddWithValue("@diretor", this.Diretor);
            cmd.Parameters.AddWithValue("@disponivel", this.Disponivel);

            bool executou = cmd.ExecuteNonQuery() > 0;

            return executou;
        }
        // método para excluir um filme
        public bool Delete()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "DELETE FROM Filmes WHERE idFilme = @idFilme;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idFilme", IdFilme);

            return cmd.ExecuteNonQuery() > 0;
        }

        // método para atualizar os dados de um filme
        public bool Update()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = @"UPDATE Filmes SET titulo = @titulo, genero = @genero, duracao = @duracao, ano_lancamento = @anoLancamento, diretor = @diretor, disponivel = @disponivel WHERE idFilme = @idFilme;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@titulo", this.Titulo);
            cmd.Parameters.AddWithValue("@genero", this.Genero);
            cmd.Parameters.AddWithValue("@duracao", this.Duracao);
            cmd.Parameters.AddWithValue("@anoLancamento", this.AnoLancamento);
            cmd.Parameters.AddWithValue("@diretor", this.Diretor);
            cmd.Parameters.AddWithValue("@disponivel", this.Disponivel);
            cmd.Parameters.AddWithValue("@idFilme", this.IdFilme);

            bool executou = cmd.ExecuteNonQuery() > 0;
            return cmd.ExecuteNonQuery() > 0;
        }

        // método para ler todos os filmes
        public static List<Filme> ReadAll()
        {
            List<Filme> listaFilmes = new List<Filme>();
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Filmes ORDER BY titulo;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Filme filme = new Filme
                {
                    IdFilme = reader.GetInt32("idFilme"),
                    Titulo = reader.GetString("titulo"),
                    Genero = reader.GetString("genero"),
                    Duracao = reader.GetInt32("duracao"),
                    AnoLancamento = reader.GetInt32("ano_lancamento"),
                    Diretor = reader.GetString("diretor"),
                    Disponivel = reader.GetBoolean("disponivel")
                };

                listaFilmes.Add(filme);
            }

            reader.Close();

            // Preenche o ValorAluguel para cada filme depois da leitura
            foreach (Filme f in listaFilmes)
            {
                var valor = Projeto_Prog_III.ItemLocacao.GetValorPorFilme(f.IdFilme);
                f.ValorAluguel = valor ?? 0; // Se não existir, define como 0
            }

            return listaFilmes;
        }

        // método para buscar um filme pelo id
        public static Filme ReadByID(int idFilme)
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Filmes WHERE idFilme = @idFilme;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idFilme", idFilme);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Filme filme = new Filme
                {
                    IdFilme = reader.GetInt32("idFilme"),
                    Titulo = reader.GetString("titulo"),
                    Genero = reader.GetString("genero"),
                    Duracao = reader.GetInt32("duracao"),
                    AnoLancamento = reader.GetInt32("ano_lancamento"),
                    Diretor = reader.GetString("diretor"),
                    Disponivel = reader.GetBoolean("disponivel")
                };
                reader.Close();
                return filme;
            }

            reader.Close();
            return null;
        }

        // para plotar o gráfico dos gêneros
        public static Dictionary<string, int> ObterQuantidadePorGenero()
        {
            var resultado = new Dictionary<string, int>();
            MySqlConnection conexao = Banco.GetConexao();

            string sql = "SELECT genero, COUNT(*) as quantidade FROM Filmes GROUP BY genero;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string genero = reader.GetString("genero");
                int quantidade = reader.GetInt32("quantidade");
                resultado[genero] = quantidade;
            }
            reader.Close();

            return resultado;
        }

        // para obter a quantidade de filmes por ano
        public static Dictionary<string, int> ObterQuantidadePorDiretor()
        {
            var resultado = new Dictionary<string, int>();
            MySqlConnection conexao = Banco.GetConexao();

            string sql = "SELECT diretor, COUNT(*) as quantidade FROM Filmes GROUP BY diretor ORDER BY quantidade DESC;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string diretor = reader.IsDBNull(0) ? "Desconhecido" : reader.GetString("diretor");
                int quantidade = reader.GetInt32("quantidade");
                resultado[diretor] = quantidade;
            }
            reader.Close();

            return resultado;
        }

        // método para imprimir o filme como string
        public override string ToString()
        {
            return $"{Titulo} - {Genero} - {Duracao} min - {AnoLancamento}";
        }
    }
}
