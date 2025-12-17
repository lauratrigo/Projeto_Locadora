using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Final_Prog_III
{
    public class Cliente
    {
        // Propriedades que representam as colunas da tabela Clientes
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        public string NivelAcesso { get; set; } // para saber se será admin ou comum


        // Método para inserir um novo cliente no banco de dados
        public bool Create()
        {
            string sql = @"INSERT INTO Clientes (nome, cpf, telefone, email, endereco)
                           VALUES (@nome, @cpf, @telefone, @email, @endereco);";

            using (MySqlCommand cmd = new MySqlCommand(sql, Banco.GetConexao()))
            {
                // Preenche os parâmetros da query com os dados do objeto
                cmd.Parameters.AddWithValue("@nome", this.Nome);
                cmd.Parameters.AddWithValue("@cpf", this.Cpf);
                cmd.Parameters.AddWithValue("@telefone", this.Telefone);
                cmd.Parameters.AddWithValue("@email", this.Email);
                cmd.Parameters.AddWithValue("@endereco", this.Endereco);

                // Executa o comando e retorna se foi bem-sucedido
                bool executou = cmd.ExecuteNonQuery() > 0;

                // Recupera o ID gerado automaticamente pelo banco
                IdCliente = (int)cmd.LastInsertedId;

                return executou;
            }
        }

        // Método para excluir este cliente do banco de dados
        public bool Delete()
        {
            string sql = "DELETE FROM Clientes WHERE idCliente = @idCliente;";

            using (MySqlCommand cmd = new MySqlCommand(sql, Banco.GetConexao()))
            {
                cmd.Parameters.AddWithValue("@idCliente", IdCliente);

                // Retorna true se alguma linha foi afetada (cliente excluído)
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Método para atualizar os dados deste cliente no banco de dados
        public bool Update()
        {
            string sql = @"UPDATE Clientes SET nome = @nome, cpf = @cpf, telefone = @telefone,
                           email = @email, endereco = @endereco WHERE idCliente = @idCliente;";

            using (MySqlCommand cmd = new MySqlCommand(sql, Banco.GetConexao()))
            {
                cmd.Parameters.AddWithValue("@nome", Nome);
                cmd.Parameters.AddWithValue("@cpf", Cpf);
                cmd.Parameters.AddWithValue("@telefone", Telefone);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@endereco", Endereco);
                cmd.Parameters.AddWithValue("@idCliente", IdCliente);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Método estático para retornar todos os clientes cadastrados no banco
        public static List<Cliente> ReadAll()
        {
            List<Cliente> lista = new List<Cliente>();
            string sql = "SELECT * FROM Clientes ORDER BY nome;";

            using (MySqlCommand cmd = new MySqlCommand(sql, Banco.GetConexao()))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                // Lê cada linha retornada e cria um objeto Cliente correspondente
                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        IdCliente = reader.GetInt32("idCliente"),
                        Nome = reader.GetString("nome"),
                        Cpf = reader.GetString("cpf"),
                        Telefone = reader.GetString("telefone"),
                        Email = reader.GetString("email"),
                        Endereco = reader.GetString("endereco")
                    };

                    lista.Add(cliente);
                }
            }

            return lista; // Retorna a lista com todos os clientes encontrados
        }

        // Método estático para buscar um cliente pelo ID
        public static Cliente ReadByID(int idCliente)
        {
            string sql = "SELECT * FROM Clientes WHERE idCliente = @idCliente;";

            using (MySqlCommand cmd = new MySqlCommand(sql, Banco.GetConexao()))
            {
                cmd.Parameters.AddWithValue("@idCliente", idCliente);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Cria e retorna um objeto Cliente preenchido com os dados do banco
                        return new Cliente
                        {
                            IdCliente = reader.GetInt32("idCliente"),
                            Nome = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            Telefone = reader.GetString("telefone"),
                            Email = reader.GetString("email"),
                            Endereco = reader.GetString("endereco")
                        };
                    }
                }
            }

            return null; // Se não encontrar, retorna null
        }

        public static Cliente BuscarPorUsuario(int idUsuario)
        {
            string sql = @"SELECT c.* FROM Clientes c
                   JOIN Usuarios u ON u.idCliente = c.idCliente
                   WHERE u.idUsuario = @idUsuario;";

            using (MySqlCommand cmd = new MySqlCommand(sql, Banco.GetConexao()))
            {
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            IdCliente = reader.GetInt32("idCliente"),
                            Nome = reader.GetString("nome"),
                            Cpf = reader.GetString("cpf"),
                            Telefone = reader.GetString("telefone"),
                            Email = reader.GetString("email"),
                            Endereco = reader.GetString("endereco")
                        };
                    }
                }
            }
            return null;
        }


        // método ToString para exibição de informações
        public override string ToString()
        {
            return $"ID: {IdCliente}, Nome: {Nome}, CPF: {Cpf}";
        }
    }
}
