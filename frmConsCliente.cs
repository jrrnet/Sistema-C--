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
    public partial class frmConsCliente : Form
    {

        private frmEntrega frmEntregapizza;
        
        public frmConsCliente()
        {
            InitializeComponent();
        }

        public frmConsCliente(frmEntrega frm)
        {
            frmEntregapizza = frm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void clienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clienteBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);

        }

        private void frmConsCliente_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bDSystemDataSet.Cliente' table. You can move, or remove it, as needed.
            this.clienteTableAdapter.Fill(this.bDSystemDataSet.Cliente);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.clienteTableAdapter.FillByClientenome(bDSystemDataSet.Cliente, textBox1.Text);

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            this.clienteTableAdapter.FillByClientenome(this.bDSystemDataSet.Cliente, textBox1.Text);
        }

        private void clienteDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEntregapizza.setCodigoAndNomeCliente(Convert.ToInt32(clienteDataGridView.CurrentRow.Cells[0].Value.ToString()),
                clienteDataGridView.CurrentRow.Cells[1].Value.ToString());

            this.Dispose();
        }
    }
}
