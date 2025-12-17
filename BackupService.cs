using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Prog_III
{
    public class BackupService
    {
        private string _caminhoBackup;
        private string _usuarioMySQL;
        private string _senhaMySQL;
        private string _nomeBanco;

        public BackupService(string caminhoBackup, string usuarioMySQL, string senhaMySQL, string nomeBanco)
        {
            _caminhoBackup = caminhoBackup;
            _usuarioMySQL = usuarioMySQL;
            _senhaMySQL = senhaMySQL;
            _nomeBanco = nomeBanco;
        }

        // método para realizar o backup
        public bool FazerBackup()
        {
            try
            {
                string comandoBackup = $"mysqldump -u {_usuarioMySQL} -p{_senhaMySQL} {_nomeBanco} > {_caminhoBackup}";
                ExecutarComando(comandoBackup);
                return true;
            }
            catch (Exception ex)
            {
                //lLog de erro ou mensagem de falha
                Console.WriteLine("Erro ao fazer backup: " + ex.Message);
                return false;
            }
        }

        // método para restaurar o backup
        public bool RestaurarBackup(string caminhoArquivoBackup)
        {
            try
            {
                string comandoRestauracao = $"mysql -u {_usuarioMySQL} -p{_senhaMySQL} {_nomeBanco} < {caminhoArquivoBackup}";
                ExecutarComando(comandoRestauracao);
                return true;
            }
            catch (Exception ex)
            {
                // log de erro ou mensagem de falha
                Console.WriteLine("Erro ao restaurar backup: " + ex.Message);
                return false;
            }
        }

        // método para executar o comando
        private void ExecutarComando(string comando)
        {
            ProcessStartInfo processo = new ProcessStartInfo("cmd.exe", "/C " + comando);
            processo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(processo);
        }
    }
}
