using Microsoft.AspNetCore.Mvc;
using BLL;
using MODELS;
using Microsoft.AspNetCore.Authorization;

namespace API_Inventario.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    //[Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly string Cadena;

        public ProductoController(IConfiguration Config)
        {
            Cadena = Config.GetConnectionString("PROD");
        }


        [HttpPost]
        [Route("GuardarInfoProducto")]
        public IActionResult GuardarInfoEmpleado([FromBody] DtoProducto Producto)
        {
            List<string> lstValidaciones = BL_Producto.ValidaInfo(Producto);

            if(lstValidaciones.Count == 0)
            {
                List<string> lstDatos = BL_Producto.GuardarInfo(Cadena, Producto);

                if (lstDatos[0] == "00") 
                {
                    return Ok(new { Codigo = "00", response = lstDatos[1] });
                }else
                {
                    return Ok(new { Codigo = lstDatos[0], response = lstDatos[1] });
                }
            }
            else
            {
                return Ok(new { Codigo = "14", respone = lstValidaciones });
            }

        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<DtoCatProducto> lstProducto = BL_Producto.ConsultaProducto(Cadena);
            return Ok(new { codigo = "00", Respuesta = lstProducto});
        }

        //[HttpGet]
        //[Route("GetAll/{Descrip}")]
        //public IActionResult GetAllNombre(string Descrip)
        //{
        //    List<DtoCatProducto> lstProducto = BL_Producto.ConsultaProducto(Cadena, Descrip);
        //    return Ok(new { codigo = "00", Respuesta = lstProducto });
        //}

        [HttpGet]
        [Route("GetAll/{Codigo}")]
        public IActionResult GetAllCodigo(string Codigo)
        {
            List<DtoCatProducto> lstProducto = BL_Producto.ConsultaProductoCodigo(Cadena, Codigo);
            return Ok(new { codigo = "00", Respuesta = lstProducto });
        }






        [HttpPut]
        [Route("ModificarInfoProducto")]
        public IActionResult ModificarInfoEmpleado([FromBody] DtoProducto Producto)
        {
            List<string> lstValidaciones = BL_Producto.ValidaInfo(Producto);

            if (lstValidaciones.Count == 0)
            {
                List<string> lstDatos = BL_Producto.ModificarInfo(Cadena, Producto);

                if (lstDatos[0] == "00")
                {
                    return Ok(new { Codigo = "00", response = lstDatos[1] });
                }
                else
                {
                    return Ok(new { Codigo = lstDatos[0], response = lstDatos[1] });
                }
            }
            else
            {
                return Ok(new { Codigo = "14", respone = lstValidaciones });
            }

        }

        [HttpDelete]
        [Route("BorrarInfoProducto/{id:int}")]
        public IActionResult BorrarInfoEmpleado(int id)
        {

            
                List<string> lstDatos = BL_Producto.BorrarInfo(Cadena, id);

                if (lstDatos[0] == "00")
                {
                    return Ok(new { Codigo = "00", response = lstDatos[1] });
                }
                else
                {
                    return Ok(new { Codigo = lstDatos[0], response = lstDatos[1] });
                }
            
            

        }


    }
}
