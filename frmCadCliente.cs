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
    public partial class frmCadCliente : Form
    {
        public frmCadCliente()
        {
            InitializeComponent();
        }

        private void clienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clienteBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);

        }

        private void frmCadCliente_Load(object sender, EventArgs e)
        {
            // TODO: Esta linha de código carrega dados na tabela 'bDSystemDataSet.Cliente'. Você pode mover, ou removê-lo, se necessário.
            this.clienteTableAdapter.Fill(this.bDSystemDataSet.Cliente);

        }

        private void clienteBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.clienteBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);
            MessageBox.Show("Cadastro salvo com sucesso!", "Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.clienteTableAdapter.Fill(this.bDSystemDataSet.Cliente);
            this.clienteBindingSource.MoveLast();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Excluir o Registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Validate();
                this.clienteBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);
                MessageBox.Show("Cadastro excluido com sucesso!", "Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operação abortada!", "Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.clienteTableAdapter.Fill(this.bDSystemDataSet.Cliente);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.clienteTableAdapter.FillByClientenome(bDSystemDataSet.Cliente, textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clienteBindingNavigatorSaveItem_Click_1(sender, e);
        }
    }
}
