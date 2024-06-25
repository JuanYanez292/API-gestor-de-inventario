using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_Inventario
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            GetAll getAllForm = new GetAll();
            getAllForm.Show();
            this.Hide();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            BuscarProducto buscarProducto = new BuscarProducto();
            buscarProducto.Show();
            this.Hide();

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            GuardarProducto guardarProducto = new GuardarProducto();
            guardarProducto.Show();
            this.Hide();
        }


        private void panel6_Click(object sender, EventArgs e)
        {
            ModificarProducto modificarProducto = new ModificarProducto();
            modificarProducto.Show();
            this.Hide();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            BorrarProducto borrarProducto = new BorrarProducto();
            borrarProducto.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        /*hover*/
        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            this.panel3.BackColor = ColorTranslator.FromHtml("#E2DCDB");
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            this.panel3.BackColor = ColorTranslator.FromHtml("#f5f5f5");
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            this.panel4.BackColor = ColorTranslator.FromHtml("#E2DCDB");
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            this.panel4.BackColor = ColorTranslator.FromHtml("#f5f5f5");
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            this.panel5.BackColor = ColorTranslator.FromHtml("#E2DCDB");
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            this.panel5.BackColor = ColorTranslator.FromHtml("#f5f5f5");
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            this.panel6.BackColor = ColorTranslator.FromHtml("#E2DCDB");
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            this.panel6.BackColor = ColorTranslator.FromHtml("#f5f5f5");
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            this.panel7.BackColor = ColorTranslator.FromHtml("#E2DCDB");
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            this.panel7.BackColor = ColorTranslator.FromHtml("#f5f5f5");
        }
    }
}
