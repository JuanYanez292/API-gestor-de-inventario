using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class BuscarProducto : Form
    {
        private const string apiUrl = "http://localhost:5253/api/Producto/GetAll/";
        private string token = Config.Token;

        public BuscarProducto()
        {
            InitializeComponent();
        }
        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigoBuscado = txtCodigo.Text.Trim();

            if (!string.IsNullOrEmpty(codigoBuscado))
            {
                string url = $"{apiUrl}{codigoBuscado}";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                            // Mostrar solo ciertas columnas en el DataGridView
                            dgvDatos.DataSource = apiResponse.Respuesta.Select(p => new
                            {
                                NombreProducto = p.NombreProducto,
                                Stock = p.Stock,
                                Precio = p.PrecioUnitario
                            }).ToList();
                        }
                        else
                        {
                            MessageBox.Show($"Error al obtener datos. Código de estado: {response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese un código antes de realizar la búsqueda.");
            }
        }
        public class ApiResponse
        {
            public string Codigo { get; set; }
            public List<Producto> Respuesta { get; set; }
        }

        public class Producto
        {
            public int Id { get; set; }
            public string CodigoBarras { get; set; }
            public string NombreProducto { get; set; }
            public int Stock { get; set; }
            public decimal PrecioUnitario { get; set; }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide();
        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
