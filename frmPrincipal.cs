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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
            toolStripStatusLabel3.Text = DateTime.Now.ToShortTimeString();
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void blocoDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void pizzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCadPizza().ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCadCliente().ShowDialog();
        }      

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCadFuncionario().ShowDialog();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCadFornecedor().ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmConsCliente().ShowDialog();
        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmConsFuncionario().ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            new frmCadPedido().ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            new frmEntrega().ShowDialog();
        }

        private void entregasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmConsRelatorio().ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmInformacao().ShowDialog();
        }

        private void sairToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }  

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.File.Exists(saveFileDialog1.FileName))
                    {
                        System.IO.File.Exists(saveFileDialog1.FileName);
                    }

                    System.IO.File.Copy(Application.StartupPath.ToString() + "\\BDSystem.mdb", saveFileDialog1.FileName);
                    MessageBox.Show("Backup realizado com sucesso!", "Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Operação Cancelada", "Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro" + ex.Message);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(Application.StartupPath.ToString() + "\\BDSystem.mdb"))
                {
                    System.IO.File.Exists(Application.StartupPath.ToString() + "\\BDSystem.mdb");
                }
                
            }
            else
            {
                MessageBox.Show("Operação Cancelada", "Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

            
    }
}
