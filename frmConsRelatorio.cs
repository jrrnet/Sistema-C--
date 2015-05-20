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
    public partial class frmConsRelatorio : Form
    {
        public frmConsRelatorio()
        {
            InitializeComponent();
        }

        private void frmConsRelatorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BDSystemDataSet.Pedido' table. You can move, or remove it, as needed.
            this.PedidoTableAdapter.Fill(this.BDSystemDataSet.Pedido);

            this.reportViewer1.RefreshReport();
        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
