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
    public partial class frmCadPedido : Form
    {
        public frmCadPedido()
        {
            InitializeComponent();
        }

        // Novo metodo para alterar datas
        private void AlteraData()
        {

            horaDateTimePicker.Text = DateTime.Now.ToShortTimeString();
            diaDateTimePicker.Text = DateTime.Now.ToShortDateString();

        }

        private void pedidoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            this.Validate();
            this.pedidoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);

        }

        private void frmCadPedido_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bDSystemDataSet.Pizza' table. You can move, or remove it, as needed.
            this.pizzaTableAdapter.Fill(this.bDSystemDataSet.Pizza);
            this.pedidoBindingSource.AddNew();
            AlteraData();
            pedidoBindingNavigatorSaveItem_Click(sender, e);
            
            // TODO: This line of code loads data into the 'bDSystemDataSet.Cliente' table. You can move, or remove it, as needed.
            this.clienteTableAdapter.Fill(this.bDSystemDataSet.Cliente);
            // TODO: This line of code loads data into the 'bDSystemDataSet.itemPedido' table. You can move, or remove it, as needed.
            this.itemPedidoTableAdapter.Fill(this.bDSystemDataSet.itemPedido);
            // TODO: This line of code loads data into the 'bDSystemDataSet.Pedido' table. You can move, or remove it, as needed.
            this.pedidoTableAdapter.Fill(this.bDSystemDataSet.Pedido);

            this.pedidoBindingSource.MoveLast();

        }

        // Chama o metodo AlteraData no adicionar pedido
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            AlteraData();
        }

        private void idClienteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                comboBox1.SelectedValue = idClienteTextBox.Text;

                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Cliente não cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idClienteTextBox.Text = comboBox1.SelectedValue.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((idClienteTextBox.Text != "") && (comboBox1.Text != ""))
            {
                if (itemPedidoDataGridView.RowCount > 1)
                {
                    pedidoBindingNavigatorSaveItem_Click(sender, e);
                    MessageBox.Show("Compra realizada com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Informe as Pizzas", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Informe o Cliente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int idx;
            bool flag = false;

            try
            {
                if (e.KeyChar == 13)
                {
                    idx = this.pizzaTableAdapter.FillByidPizza(bDSystemDataSet.Pizza, Convert.ToInt32(textBox1.Text));

                    this.pizzaTableAdapter.Fill(bDSystemDataSet.Pizza);

                    if (idx == 1)
                    {
                        String Nome = this.bDSystemDataSet.Pizza.FindByidPizza(Convert.ToInt32(textBox1.Text)).nome;

                        for (int i = 0; i < itemPedidoDataGridView.RowCount; i++)
                        {
                            if (itemPedidoDataGridView[2, i].EditedFormattedValue.ToString() == Nome)
                            {
                                flag = true;
                                break;
                            }
                        }

                        if (flag)
                        {
                            MessageBox.Show("Pizza já foi pedida!", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            this.bDSystemDataSet.itemPedido.Rows.Add(null, Convert.ToInt32(idPedidoTextBox.Text), Convert.ToInt32(textBox1.Text), null);
                        }

                        // Limpa dados no Textbox
                        textBox1.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Pizza não cadastrada", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("Ocorreu um erro" + EX.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.itemPedidoBindingSource.RemoveCurrent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
