using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Final_Prog_III
{
    public partial class MDICliente : Form
    {
        private Usuarios usuarioLogado;
        private FilmeFormsCliente filmeFormsCliente;
        public MDICliente(Usuarios usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;  // salva o usuário logado, se necessário
        }

        private void filmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filmeFormsCliente == null || filmeFormsCliente.IsDisposed)
            {
                filmeFormsCliente = new FilmeFormsCliente(usuarioLogado); // Passa o usuário logado para o formulário de filmes
                filmeFormsCliente.MdiParent = this;  // Define a janela principal (MDI)
                filmeFormsCliente.WindowState = FormWindowState.Maximized;  // Maximiza a janela filha
                filmeFormsCliente.Show();
            }
            else
            {
                filmeFormsCliente.BringToFront();  // Se já estiver aberto, apenas traz a janela para frente
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MDICliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
