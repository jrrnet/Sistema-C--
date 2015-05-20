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
    public partial class frmEntrega : Form
    {
        public frmEntrega()
        {
            InitializeComponent();
        }

        private void itemPedidoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.itemPedidoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);

        }

        private void frmEntrega_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bDSystemDataSet.Pizza' table. You can move, or remove it, as needed.
            this.pizzaTableAdapter.Fill(this.bDSystemDataSet.Pizza);
            // TODO: This line of code loads data into the 'bDSystemDataSet.Cliente' table. You can move, or remove it, as needed.
            this.clienteTableAdapter.Fill(this.bDSystemDataSet.Cliente);
            // TODO: This line of code loads data into the 'bDSystemDataSet.itemPedido' table. You can move, or remove it, as needed.
            //this.itemPedidoTableAdapter.Fill(this.bDSystemDataSet.itemPedido);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < itemPedidoDataGridView.Rows.Count; i++)
            {
                if (bool.Parse(itemPedidoDataGridView[0,i].EditedFormattedValue.ToString()))
                {
                    itemPedidoDataGridView[4, i].Value = dateTimePicker1.Value;                   
                }
            }

            itemPedidoBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(this.bDSystemDataSet);

            MessageBox.Show("Entrega efetuado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {            

            if (e.KeyChar == 13)
            {
                ConsultaCliente();                
            }
        }

        private void ConsultaCliente()
        {
            int countUsuario = this.clienteTableAdapter.FillByIdClienteEntrega(this.bDSystemDataSet.Cliente, Convert.ToInt32(textBox1.Text));

            if (countUsuario == 1)
            {
                textBox2.Text = this.bDSystemDataSet.Cliente.FindByidCliente(Convert.ToInt32(textBox1.Text)).nome;

                int countPedidos = itemPedidoTableAdapter.FillByIdPedido(this.bDSystemDataSet.itemPedido, Convert.ToInt32(textBox1.Text));

                if (countPedidos == 0)
                {
                    MessageBox.Show("Cliente não possui pedidos", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                textBox2.Clear();
                bDSystemDataSet.itemPedido.Clear();
                MessageBox.Show("Cliente não cadastro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Chama o formulario de consulta de cliente
            new frmConsCliente(this).ShowDialog();
        }

        // Criando Metodo Publico para outro formulario ter acesso
        public void setCodigoAndNomeCliente(int codigo, String nome)
        {
            textBox1.Text = codigo.ToString();
            textBox2.Text = nome;
            ConsultaCliente();  
        }
    }
}
