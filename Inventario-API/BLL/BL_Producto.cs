using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MODELS;
using DAL;

namespace BLL
{
    public class BL_Producto
    {
        public static List<string> ValidaInfo(DtoProducto PProducto)
        {
            List<string> lstValidaciones = new List<string>();
            if (ValidacionTexto(PProducto.NombreProducto))
            {
                lstValidaciones.Add("Revisar el NombreProducto");
            }
            if (PProducto.Stock < 0)
            {
                lstValidaciones.Add("El stock no puede ser negativo");
            }

            // Validación para el campo 'PrecioUnitario'
            if (PProducto.PrecioUnitario <= 0)
            {
                lstValidaciones.Add("El precio unitario no puede ser negativo o igual a 0");
            }

            return lstValidaciones;
        }

        public static Boolean ValidacionTexto(string Texto)
        {
            Boolean Validacion = false;

            foreach(char Letra in Texto.Replace(" ", ""))
            {
                if (!char.IsLetter(Letra))
                {
                    Validacion = true;
                    break;
                }
            }
            return Validacion;
        }

        public static List<string> GuardarInfo(string PCadena, DtoProducto PProducto)
        {
            List<string> lstDatos = new List<string>();

            try
            {
                var dpParametro = new
                {
                    P_CodigoBarras = PProducto.CodigoBarras,
                    P_NombreProducto = PProducto.NombreProducto,
                    P_Stock =  PProducto.Stock,
                    P_PrecioUnitario = PProducto.PrecioUnitario,
                };

                Contexto.Procedimiento_StoreDB(PCadena, "InsertarProducto", dpParametro);

                lstDatos.Add("00");
                lstDatos.Add("El Producto fue registrado con exito");
            }
            catch(Exception e)
            {
                lstDatos.Add("14");
                lstDatos.Add(e.Message);
            }

            return lstDatos;
        }

        public static List<DtoCatProducto> ConsultaProducto(string PCadena)
        {
            List<DtoCatProducto> lstProducto = new List<DtoCatProducto>();

            var dpParametros = new
            {
                P_Accion = 1,
            };

            //*Veriicar si existe spConsul
            DataTable Dt = Contexto.Funcion_StoreDB(PCadena, "spConsulProducto", dpParametros);

            if(Dt.Rows.Count > 0)
            {
                lstProducto = (from item in Dt.AsEnumerable()
                              select new DtoCatProducto
                              {
                                  id = item.Field<int>("id"),
                                  CodigoBarras = item.Field<string>("CodigoBarras"),
                                  NombreProducto = item.Field<string>("NombreProducto"),
                                  Stock = item.Field<int>("Stock"),
                                  PrecioUnitario = item.Field<decimal>("PrecioUnitario"), 
                              }).ToList();
            }

            return lstProducto;

        }

        public static List<DtoCatProducto> ConsultaProducto(string PCadena, string PTexto)
        {
            List<DtoCatProducto> lstProducto = new List<DtoCatProducto>();

            var dpParametros = new
            {
                P_Accion = 2,
                P_Texto = PTexto
            };

            //*Veriicar si existe spConsul
            DataTable Dt = Contexto.Funcion_StoreDB(PCadena, "spConsulProducto", dpParametros);

            if (Dt.Rows.Count > 0)
            {
                lstProducto = (from item in Dt.AsEnumerable()
                              select new DtoCatProducto
                              {
                                  id = item.Field<int>("id"),
                                  CodigoBarras = item.Field<string>("CodigoBarras"),
                                  NombreProducto = item.Field<string>("NombreProducto"),
                                  Stock = item.Field<int>("Stock"),
                                  PrecioUnitario = item.Field<decimal>("PrecioUnitario"),
                              }).ToList();
            }

            return lstProducto;

        }

        public static List<DtoCatProducto> ConsultaProductoCodigo(string PCadena, string PTexto)
        {
            List<DtoCatProducto> lstProducto = new List<DtoCatProducto>();

            var dpParametros = new
            {
                P_Accion = 3,
                P_Texto = PTexto
            };

            //*Veriicar si existe spConsul
            DataTable Dt = Contexto.Funcion_StoreDB(PCadena, "spConsulProducto", dpParametros);

            if (Dt.Rows.Count > 0)
            {
                lstProducto = (from item in Dt.AsEnumerable()
                               select new DtoCatProducto
                               {
                                   id = item.Field<int>("id"),
                                   CodigoBarras = item.Field<string>("CodigoBarras"),
                                   NombreProducto = item.Field<string>("NombreProducto"),
                                   Stock = item.Field<int>("Stock"),
                                   PrecioUnitario = item.Field<decimal>("PrecioUnitario"),
                               }).ToList();
            }

            return lstProducto;

        }


        public static List<string> ModificarInfo(string PCadena, DtoProducto PProducto)
        {
            List<string> lstDatos = new List<string>();

            try
            {
                var dpParametro = new
                {
                    P_CodigoBarras = PProducto.CodigoBarras,
                    P_NombreProducto = PProducto.NombreProducto,
                    P_Stock = PProducto.Stock,
                    P_PrecioUnitario = PProducto.PrecioUnitario,
                };

                Contexto.Procedimiento_StoreDB(PCadena, "spModifProducto", dpParametro);

                lstDatos.Add("00");
                lstDatos.Add("El Producto fue modificado con exito");
            }
            catch (Exception e)
            {
                lstDatos.Add("14");
                lstDatos.Add(e.Message);
            }

            return lstDatos;
        }

        public static List<string> BorrarInfo(string PCadena, int id)
        {
            List<string> lstDatos = new List<string>();

            try
            {
                var dpParametro = new
                {
                    P_IdProducto = id
                };

                Contexto.Procedimiento_StoreDB(PCadena, "spBorrarProducto", dpParametro);

                lstDatos.Add("00");
                lstDatos.Add("El Producto fue borrado con exito");

            }
            catch (Exception e)
            {
                lstDatos.Add("14");
                lstDatos.Add(e.Message);
            }

            return lstDatos;
        }
    }
    
}