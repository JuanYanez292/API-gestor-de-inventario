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
    public partial class GuardarProducto : Form
    {
        private const string UrlApi = "http://localhost:5253/api/Producto/GuardarInfoProducto";
        private string Token = Config.Token;

        public GuardarProducto()
        {
            InitializeComponent();
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
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

                // Enviar la solicitud a la API
                bool resultado = await EnviarSolicitudApi(producto);

                if (resultado)
                {
                    MessageBox.Show("Producto guardado exitosamente");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error: {ex.Message}");
                MessageBox.Show($"Favor de verifcar que los campos se llenaron correctamente");
            }
        }

        private void LimpiarCampos()
        {
            txtCodigoBarras.Text = "";
            txtNombreProducto.Text = "";
            txtStock.Text = "";
            txtPrecioUnitario.Text = "";
        }


        private async Task<bool> EnviarSolicitudApi(Producto producto)
        {
            using (HttpClient client = new HttpClient())
            {
                // Agregar el token al encabezado de la solicitud
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                // Convertir el objeto Producto a formato JSON
                string jsonProducto = Newtonsoft.Json.JsonConvert.SerializeObject(producto);

                // Crear el contenido de la solicitud
                StringContent content = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

                // Enviar la solicitud POST a la API
                HttpResponseMessage response = await client.PostAsync(UrlApi, content);

                // Verificar si la solicitud fue exitosa
                return response.IsSuccessStatusCode;
            }
        }
  

        public class Producto
        {
            public int Id { get; set; }
            public string CodigoBarras { get; set; }
            public string NombreProducto { get; set; }
            public int Stock { get; set; }
            public decimal PrecioUnitario { get; set; }
        }

        private void GuardarProducto_Load(object sender, EventArgs e)
            {

            }

        private void panel2_Paint(object sender, PaintEventArgs e)
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
