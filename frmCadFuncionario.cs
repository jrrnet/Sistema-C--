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
    public partial class frmCadFuncionario : Form
    {
        public frmCadFuncionario()
        {
            InitializeComponent();
        }

        private void funcionarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.funcionarioBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);

        }

        private void frmCadFuncionario_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bDSystemDataSet.Funcionario' table. You can move, or remove it, as needed.
            this.funcionarioTableAdapter.Fill(this.bDSystemDataSet.Funcionario);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.funcionarioBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);
            this.funcionarioTableAdapter.Fill(this.bDSystemDataSet.Funcionario);
            this.funcionarioBindingSource.MoveLast();
        }

        private void funcionarioBindingNavigatorSaveItem_Click_3(object sender, EventArgs e)
        {
            // Barra de ferramentas botão salvar
            if (senhaTextBox.Text == textBox1.Text)
            {
                this.Validate();
                this.funcionarioBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);
                MessageBox.Show("Registro Salvo", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.funcionarioTableAdapter.Fill(this.bDSystemDataSet.Funcionario);
                this.funcionarioBindingSource.MoveLast();
            }
            else
            {
                MessageBox.Show("Senha não confirma", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Botão Cadastrar
            funcionarioBindingNavigatorSaveItem_Click_3(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Botão Cancelar
            this.Dispose();
        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            //Barra botão excluir
            if(MessageBox.Show("Deseja excluir o registro", "Questionamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Validate();
                this.funcionarioBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);
                MessageBox.Show("Registro excluido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operação abortada", "Abortada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.funcionarioTableAdapter.Fill(this.bDSystemDataSet.Funcionario);
            }
        }

        private void funcionarioBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.funcionarioBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDSystemDataSet);

        }           
      
    }
}
