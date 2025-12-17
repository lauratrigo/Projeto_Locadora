using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projeto_Final_Prog_III
{
    public class Banco
    {
        // Configurações da conexão (alterar conforme necessário)
        private static readonly string HOST = "127.0.0.1";     // Endereço do servidor MySQL
        private static readonly string USER = "root";          // Usuário do banco
        private static readonly string PWD = "";               // Senha do banco
        private static readonly string DB = "projeto_filmes";// Nome do banco de dados
        private static readonly int PORT = 3306;               // Porta padrão do MySQL

        // Objeto de conexão que será usado em todo o projeto
        private static MySqlConnection CONEXAO = null;

        // Método privado para abrir conexão com o banco
        private static void Conectar()
        {
            // Verifica se a conexão já está criada
            if (CONEXAO == null)
            {
                try
                {
                    // Monta a string de conexão
                    string connString = $"Server={HOST};Port={PORT};Database={DB};Uid={USER};Pwd={PWD};";

                    // Cria e abre a conexão
                    CONEXAO = new MySqlConnection(connString);
                    CONEXAO.Open();
                }
                catch (MySqlException ex)
                {
                    // Lança uma exceção com a mensagem do erro
                    Console.WriteLine("Erro ao conectar no banco: " + ex.Message);
                    throw;
                }
            }
        }

        // Método público para acessar a conexão já aberta ou abrir se estiver fechada
        public static MySqlConnection GetConexao()
        {
            // Se a conexão está nula ou fechada, tenta conectar
            if (CONEXAO == null || CONEXAO.State == ConnectionState.Closed)
            {
                Conectar();
            }
            return CONEXAO; // Retorna a conexão pronta para uso
        }

        //Método opcional para fechar a conexão manualmente, se necessário
        public static void Fechar()
        {
        // Se a conexão existe e está aberta, fecha e libera
            if (CONEXAO != null && CONEXAO.State == ConnectionState.Open)
            {
                CONEXAO.Close();
                CONEXAO = null; // Libera a memória para recriar se necessário
             }
        }
    }
}
