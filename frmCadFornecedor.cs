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
    public partial class frmCadFornecedor : Form
    {
        public frmCadFornecedor()
        {
            InitializeComponent();
        }

        private void pizzariaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pizzariaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);

        }

        private void frmCadFornecedor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bDSystemDataSet.Pizzaria' table. You can move, or remove it, as needed.
            this.pizzariaTableAdapter.Fill(this.bDSystemDataSet.Pizzaria);

        }

        private void pizzariaBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            // Barra de ferramentas botão salvar
            this.Validate();
            this.pizzariaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);
            MessageBox.Show("Registro Salvo", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.pizzariaTableAdapter.Fill(this.bDSystemDataSet.Pizzaria);
            this.pizzariaBindingSource.MoveLast();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            //Barra botão excluir
            if (MessageBox.Show("Deseja excluir o registro", "Questionamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Validate();
                this.pizzariaBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);
                MessageBox.Show("Registro excluido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operação abortada", "Abortada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.pizzariaTableAdapter.Fill(this.bDSystemDataSet.Pizzaria);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pizzariaBindingNavigatorSaveItem_Click_1(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.pizzariaTableAdapter.FillByPizzariaNome(bDSystemDataSet.Pizzaria, textBox1.Text);
        }
    }
}
