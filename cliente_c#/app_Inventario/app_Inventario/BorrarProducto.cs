using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace app_Inventario
{
    public partial class BorrarProducto : Form
    {
        private const string UrlBorrarProducto = "http://localhost:5253/api/Producto/BorrarInfoProducto/";
        private string Token = Config.Token;
        public BorrarProducto()
        {
            InitializeComponent();
        }
        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            // Obtener el ID del producto a borrar
            int idProductoABorrar;
            if (int.TryParse(txtIdBorrar.Text, out idProductoABorrar))
            {
                // Enviar la solicitud para borrar la información del producto
                bool resultado = await BorrarInfoProducto(idProductoABorrar);

                // Manejar el resultado según tus necesidades
                if (resultado)
                {
                    MessageBox.Show("Información del producto borrada exitosamente");
                    txtIdBorrar.Text = "";
                }
                else
                {
                    MessageBox.Show("Error al borrar la información del producto");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido para borrar el producto");
            }
        }

        private async Task<bool> BorrarInfoProducto(int idProducto)
        {
            using (HttpClient client = new HttpClient())
            {
                // Agregar el token al encabezado de la solicitud
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                // Enviar la solicitud DELETE a la API
                HttpResponseMessage response = await client.DeleteAsync(UrlBorrarProducto + idProducto);

                // Verificar si la solicitud fue exitosa
                return response.IsSuccessStatusCode;
            }
        }

        private void BorrarProducto_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide();
        }
    }
}
