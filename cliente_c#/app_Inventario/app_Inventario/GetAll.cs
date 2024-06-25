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
using Newtonsoft.Json;

namespace app_Inventario
{
    public partial class GetAll : Form
    {
        private const string apiUrl = "http://localhost:5253/api/Producto/GetAll";
        private string token = Config.Token;

        public GetAll()
        {
            InitializeComponent();
        }

        private async void btnObtenerDatos_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Agregar el token al encabezado de autorización
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    // Realizar la solicitud GET a la API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Verificar si la solicitud fue exitosa (código 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer y mostrar la respuesta en un DataGridView
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Deserializar el JSON a un objeto para facilitar su manipulación
                        var data = JsonConvert.DeserializeObject<MyApiResponse>(responseBody);

                        // Asignar los datos al DataGridView (suponiendo que tienes un control DataGridView llamado dgvDatos)
                        dgvDatos.DataSource = data.respuesta;

                        // Opcional: Ajustar las columnas automáticamente para que se ajusten al contenido
                        dgvDatos.AutoResizeColumns();
                    }
                    else
                    {
                        // Si la solicitud no fue exitosa, mostrar el código de estado
                        MessageBox.Show($"Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        // Clase para representar la estructura del JSON recibido
        public class MyApiResponse
        {
            public string codigo { get; set; }
            public List<Producto> respuesta { get; set; }
        }

        // Clase para representar la estructura de cada producto en la respuesta JSON
        public class Producto
        {
            public int id { get; set; }
            public string codigoBarras { get; set; }
            public string nombreProducto { get; set; }
            public int stock { get; set; }
            public decimal precioUnitario { get; set; }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide();
        }
    }
}
