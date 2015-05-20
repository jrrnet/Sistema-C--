using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = funcionarioTableAdapter.FillByFuncionarioLogin(bDSystemDataSet.Funcionario, textBox1.Text, textBox2.Text);
            
            if (result == 1)
            {
                //Instancia o formulario
                frmPrincipal frmp = new frmPrincipal();

                //Mostra o formulario
                frmp.Show();

                //Esconde o formulario de login
                this.Visible = false;

            }
            else
            {
                MessageBox.Show("Usuário ou Senha Inválidos!", "Ocorreu um Erro ao Autenticar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void funcionarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.funcionarioBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bDSystemDataSet.Funcionario' table. You can move, or remove it, as needed.
            this.funcionarioTableAdapter.Fill(this.bDSystemDataSet.Funcionario);

        }
    }
}
