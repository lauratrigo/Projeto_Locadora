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
    public partial class CadastrarClienteForms : Form
    {
        private Usuarios usuarioLogado; // Declarar variável para armazenar usuário logado

        public CadastrarClienteForms()
        {
            InitializeComponent();
            //this.usuarioLogado = usuarioLogado; // Salvar o usuário logado para usar depois
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteForms clienteForm = new ClienteForms(true);
            clienteForm.MdiParent = this;  // Define que será filho do MDI
            clienteForm.Show();
        }

        private void MDICadastrarClienteForms_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosForms usuarioForm = new UsuariosForms(usuarioLogado, true);
            usuarioForm.MdiParent = this;  // Define que será filho do MDI
            usuarioForm.Show();
        }
    }
}
