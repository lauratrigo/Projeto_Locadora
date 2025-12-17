using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Projeto_Final_Prog_III
{
    public class Usuarios
    {
        // Propriedades da classe
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string NivelAcesso { get; set; } // 'admin' ou 'cliente'

        // Método para criar um novo usuário no banco de dados
        public bool Create()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = @"INSERT INTO Usuarios (nome_usuario, senha, nivel_acesso)
                           VALUES (@nome_usuario, @senha, @nivel_acesso);";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome_usuario", this.NomeUsuario);
            cmd.Parameters.AddWithValue("@senha", this.Senha); // Senha em texto simples
            cmd.Parameters.AddWithValue("@nivel_acesso", this.NivelAcesso);

            bool executou = cmd.ExecuteNonQuery() > 0;
            this.IdUsuario = (int)cmd.LastInsertedId; // Atribui o ID do novo usuário inserido
            return executou;
        }

        // Método para excluir um usuário
        public bool Delete()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "DELETE FROM Usuarios WHERE idUsuario = @idUsuario;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idUsuario", this.IdUsuario);

            return cmd.ExecuteNonQuery() > 0;
        }

        // Método para atualizar as informações do usuário
        public bool Update()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = @"UPDATE Usuarios 
                           SET nome_usuario = @nome_usuario, senha = @senha, nivel_acesso = @nivel_acesso
                           WHERE idUsuario = @idUsuario;";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome_usuario", this.NomeUsuario);
            cmd.Parameters.AddWithValue("@senha", this.Senha); // Senha em texto simples
            cmd.Parameters.AddWithValue("@nivel_acesso", this.NivelAcesso);
            cmd.Parameters.AddWithValue("@idUsuario", this.IdUsuario);

            return cmd.ExecuteNonQuery() > 0;
        }

        // Método para buscar todos os usuários
        public List<Usuarios> ReadAll()
        {
            List<Usuarios> lista = new List<Usuarios>();
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Usuarios ORDER BY nome_usuario;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = cmd.ExecuteReader();

           while (reader.Read())
                {
                Usuarios u = new Usuarios();
                    {
                    u.IdUsuario = reader.GetInt32("idUsuario");
                    u.NomeUsuario = reader.GetString("nome_usuario");
                    u.Senha = reader.GetString("senha");
                    u.NivelAcesso = reader.GetString("nivel_acesso");

                    lista.Add(u);
                };

            }

            reader.Close();
            return lista;
        }


        // Método para buscar um usuário por ID
        public static Usuarios ReadById(int idUsuario)
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Usuarios WHERE idUsuario = @idUsuario;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Usuarios usuario = new Usuarios
                {
                    IdUsuario = reader.GetInt32("idUsuario"),
                    NomeUsuario = reader.GetString("nome_usuario"),
                    Senha = reader.GetString("senha"), // A senha em texto simples
                    NivelAcesso = reader.GetString("nivel_acesso")
                };
                reader.Close();
                return usuario;
            }

            reader.Close();
            return null;
        }

        // Método para buscar um usuário pelo nome de usuário
        public static Usuarios ReadByNomeUsuario(string nomeUsuario)
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Usuarios WHERE nome_usuario = @nomeUsuario;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nomeUsuario", nomeUsuario);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Usuarios usuario = new Usuarios
                {
                    IdUsuario = reader.GetInt32("idUsuario"),
                    NomeUsuario = reader.GetString("nome_usuario"),
                    Senha = reader.GetString("senha"), // A senha em texto simples
                    NivelAcesso = reader.GetString("nivel_acesso")
                };
                reader.Close();
                return usuario;
            }

            reader.Close();
            return null;
        }

        // Método para verificar a validade da senha
        public bool ValidarSenha(string senhaInformada)
        {
            return this.Senha == senhaInformada; // Compara a senha em texto simples
        }

        // Sobrescreve o método ToString para retornar o nome do usuário
        public override string ToString()
        {
            return this.NomeUsuario;
        }
    }
}
