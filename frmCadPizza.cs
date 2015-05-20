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
    public partial class frmCadPizza : Form
    {
        public frmCadPizza()
        {
            InitializeComponent();
        }

        private void pizzaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pizzaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);

        }

        private void frmCadPizza_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bDSystemDataSet.Pizzaria' table. You can move, or remove it, as needed.
            this.pizzariaTableAdapter.Fill(this.bDSystemDataSet.Pizzaria);
            // TODO: This line of code loads data into the 'bDSystemDataSet.Pizza' table. You can move, or remove it, as needed.
            this.pizzaTableAdapter.Fill(this.bDSystemDataSet.Pizza);

        }

        private void pizzaBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.pizzaBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);
                MessageBox.Show("Pizza salva com sucesso!", "Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Falha ao salvar o registro!", "Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Excluir a Pizza?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Validate();
                this.pizzaBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);
                MessageBox.Show("Registro excluido com sucesso!", "Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.pizzaTableAdapter.Fill(this.bDSystemDataSet.Pizza);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.pizzaTableAdapter.FillByPizzanome(bDSystemDataSet.Pizza, textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pizzaBindingNavigatorSaveItem_Click_1(sender, e);
        }
    }
}