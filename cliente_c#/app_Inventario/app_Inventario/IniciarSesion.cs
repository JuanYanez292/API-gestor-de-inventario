using Newtonsoft.Json;
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
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Obtén los valores de los TextBox
            string usuario = txtUsuario.Text;
            string contrasena = txtContraseña.Text;
            string uGuid = txtUGuid.Text;

            // Crea el objeto con los parámetros
            var parametros = new
            {
                usuario,
                contra = contrasena,
                uGuid
            };

            // Convierte el objeto a JSON
            string jsonInput = JsonConvert.SerializeObject(parametros);

            // Realiza la solicitud HTTP
            string resultado = await ObtenerToken(jsonInput);

            // Deserializa el resultado JSON
            var tokenInfo = JsonConvert.DeserializeObject<TokenInfo>(resultado);

            // Guarda el token en la clase Config
            Config.Token = tokenInfo.access_token;

            // Puedes acceder a la fecha de vencimiento si es necesario
            DateTime expiresDate = tokenInfo.expires_Date;

            Menu getAllForm = new Menu();
            getAllForm.Show();
            this.Hide();
        }
        private async Task<string> ObtenerToken(string jsonInput)
        {
            using (HttpClient cliente = new HttpClient())
            {
                // Establece la URL del servicio
                string url = "http://localhost:5253/api/Autenticacion/Token";

                // Crea el contenido de la solicitud
                StringContent contenido = new StringContent(jsonInput, System.Text.Encoding.UTF8, "application/json");

                // Realiza la solicitud POST y obtén la respuesta
                HttpResponseMessage respuesta = await cliente.PostAsync(url, contenido);

                // Lee y devuelve el contenido de la respuesta
                return await respuesta.Content.ReadAsStringAsync();
            }
        }

        private class TokenInfo
        {
            public string access_token { get; set; }
            public DateTime expires_Date { get; set; }
        }
    }
}
