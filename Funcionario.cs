using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Projeto_Final_Prog_III
{
    public class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public int IdUsuario { get; set; } // FK para login

        public bool Create()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = @"INSERT INTO Funcionarios (nome, cpf, telefone, email, cargo, idUsuario)
                           VALUES (@nome, @cpf, @telefone, @email, @cargo, @idUsuario);";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", Nome);
            cmd.Parameters.AddWithValue("@cpf", Cpf);
            cmd.Parameters.AddWithValue("@telefone", Telefone);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@cargo", Cargo);
            cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);

            IdFuncionario = (int)cmd.LastInsertedId;
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "DELETE FROM Funcionarios WHERE idFuncionario = @idFuncionario;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idFuncionario", IdFuncionario);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = @"UPDATE Funcionarios 
                           SET nome = @nome, cpf = @cpf, telefone = @telefone, 
                               email = @email, cargo = @cargo, idUsuario = @idUsuario 
                           WHERE idFuncionario = @idFuncionario;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", Nome);
            cmd.Parameters.AddWithValue("@cpf", Cpf);
            cmd.Parameters.AddWithValue("@telefone", Telefone);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@cargo", Cargo);
            cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);
            cmd.Parameters.AddWithValue("@idFuncionario", IdFuncionario);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static List<Funcionario> ReadAll()
        {
            List<Funcionario> lista = new List<Funcionario>();
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Funcionarios ORDER BY nome;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Funcionario f = new Funcionario();
                f.IdFuncionario = reader.GetInt32("idFuncionario");
                f.Nome = reader.GetString("nome");
                f.Cpf = reader.GetString("cpf");
                f.Telefone = reader.GetString("telefone");
                f.Email = reader.GetString("email");
                f.Cargo = reader.GetString("cargo");
                f.IdUsuario = reader.GetInt32("idUsuario");

                lista.Add(f);
            }

            reader.Close();
            return lista;
        }

        public static Funcionario ReadById(int idFuncionario)
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Funcionarios WHERE idFuncionario = @idFuncionario;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idFuncionario", idFuncionario);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Funcionario f = new Funcionario();
                f.IdFuncionario = reader.GetInt32("idFuncionario");
                f.Nome = reader.GetString("nome");
                f.Cpf = reader.GetString("cpf");
                f.Telefone = reader.GetString("telefone");
                f.Email = reader.GetString("email");
                f.Cargo = reader.GetString("cargo");
                f.IdUsuario = reader.GetInt32("idUsuario");

                reader.Close();
                return f;
            }

            reader.Close();
            return null;
        }

        public static Funcionario ReadByCPF(string cpf)
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM Funcionarios WHERE cpf = @cpf;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Funcionario f = new Funcionario();
                f.IdFuncionario = reader.GetInt32("idFuncionario");
                f.Nome = reader.GetString("nome");
                f.Cpf = reader.GetString("cpf");
                f.Telefone = reader.GetString("telefone");
                f.Email = reader.GetString("email");
                f.Cargo = reader.GetString("cargo");
                f.IdUsuario = reader.GetInt32("idUsuario");

                reader.Close();
                return f;
            }

            reader.Close();
            return null;
        }


        public override string ToString()
        {
            return $"{Nome} - {Cargo} - {Email}";
        }
    }
}
