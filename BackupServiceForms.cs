using Projeto_Prog_III;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Final_Prog_III
{
    public partial class BackupServiceForms : Form
    {
        //private BackupService _backupService;
        //private string usuarioLogado;  // Variável para armazenar o nome do usuário logado
        public BackupServiceForms()
        {
            InitializeComponent();
        }

        // botão para realizar o backup
        private void btnFazer_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog salvar = new SaveFileDialog();
                salvar.Filter = "Arquivo SQL (*.sql)|*.sql";
                salvar.FileName = "backup_projeto_filmes.sql";

                if (salvar.ShowDialog() == DialogResult.OK)
                {
                    string caminho = salvar.FileName;
                    string mysqldump = @"C:\xampp\mysql\bin\mysqldump.exe"; // ajuste se necessário
                    string argumentos = $"--user=root --password= --databases projeto_filmes -r \"{caminho}\"";

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = mysqldump,
                        Arguments = argumentos,
                        RedirectStandardOutput = false,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    Process processo = Process.Start(psi);
                    processo.WaitForExit();

                    MessageBox.Show("Backup realizado com sucesso!", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fazer backup: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog abrir = new OpenFileDialog();
                abrir.Filter = "Arquivo SQL (*.sql)|*.sql";

                if (abrir.ShowDialog() == DialogResult.OK)
                {
                    string caminho = abrir.FileName;
                    string mysql = @"C:\xampp\mysql\bin\mysql.exe";

                    string argumentos = $"--user=root --password= projeto_filmes < \"{caminho}\"";

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c {mysql} {argumentos}",
                        RedirectStandardOutput = false,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    Process processo = Process.Start(psi);
                    processo.WaitForExit();

                    MessageBox.Show("Backup restaurado com sucesso!", "Restaurar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao restaurar backup: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
