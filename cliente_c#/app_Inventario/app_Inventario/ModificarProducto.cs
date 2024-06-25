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
    public partial class ModificarProducto : Form
    {
        private const string UrlModificarProducto = "http://localhost:5253/api/Producto/ModificarInfoProducto";
        private string token = Config.Token;

        public ModificarProducto()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear el objeto Producto con la información del formulario
                Producto producto = new Producto
                {
                    CodigoBarras = txtCodigoBarras.Text,
                    NombreProducto = txtNombreProducto.Text,
                    Stock = Convert.ToInt32(txtStock.Text),
                    PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text)
                };

                // Enviar la solicitud para modificar la información del producto
                bool resultado = await ModificarInfoProducto(producto);

                // Manejar el resultado según tus necesidades
                if (resultado)
                {
                    MessageBox.Show("Información del producto modificada exitosamente");
                    txtCodigoBarras.Text = "";
                    txtNombreProducto.Text = "";
                    txtStock.Text = "";
                    txtPrecioUnitario.Text = "";
                }
                else
                {
                    MessageBox.Show("Error al modificar la información del producto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Verificar que los campos se llenaron completamente");
            }
        }

        private async Task<bool> ModificarInfoProducto(Producto producto)
        {
            using (HttpClient client = new HttpClient())
            {
                // Agregar el token al encabezado de la solicitud
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                // Convertir el objeto Producto a formato JSON
                string jsonProducto = Newtonsoft.Json.JsonConvert.SerializeObject(producto);

                // Crear el contenido de la solicitud
                StringContent content = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

                // Enviar la solicitud PUT a la API
                HttpResponseMessage response = await client.PutAsync(UrlModificarProducto, content);

                // Verificar si la solicitud fue exitosa
                return response.IsSuccessStatusCode;
            }
        }

        public class Producto
        {
            public string CodigoBarras { get; set; }
            public string NombreProducto { get; set; }
            public int Stock { get; set; }
            public decimal PrecioUnitario { get; set; }
        }

        private void ModificarProducto_Load(object sender, EventArgs e)
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
