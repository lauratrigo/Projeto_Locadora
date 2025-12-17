using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Final_Prog_III
{
    public class UsuarioSessaoDAO
    {
        public void AtualizarUsuarioSessao(string usuarioLogado, string tipoUsuario)
        {
            MySqlConnection conexao = Banco.GetConexao();

            // Verifica se a conexão está fechada antes de abrir
            if (conexao.State == System.Data.ConnectionState.Closed)
                conexao.Open();

            string sql = "UPDATE UsuarioSessao SET usuario = @usuario, tipo_usuario = @tipo, data_hora = NOW() WHERE id = 1;";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@usuario", usuarioLogado);
            cmd.Parameters.AddWithValue("@tipo", tipoUsuario);
            cmd.ExecuteNonQuery();

            // Aqui você pode decidir fechar a conexão se quiser
            // conexao.Close();
        }
    }
}
