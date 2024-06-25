using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BL_AUTENTICACION
    {
        public static async Task<Boolean> ValidaUsuarioInterfaces(string PCadena, string PUsuario, string PContra, string PGuid)
        {
            Boolean Validacion = false;

            var dpParametros = new
            {
                P_Usuario = PUsuario,
                P_Contra = PContra,
                P_Guid = PGuid

            };

            DataTable Dt = Contexto.Funcion_StoreDB(PCadena, "spValidaInterfaceTOKEN", dpParametros);

            if (Dt.Rows.Count > 0)
            {
                Validacion = true;
            }

            return await Task.FromResult(Validacion);
        }
    }
}
