using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionP5_Roy
{
    public static class ObjetosGlobales
    {
        public static Logica.Models.Usuario MiUsuarioGlobal = new Logica.Models.Usuario();


        public static Form MiFormularioPrincipal = new Formularios.FrmMDIPrincipal();

        public static Formularios.FrmUsuariosGestion MiFormDeGestionDeUsuarios = new Formularios.FrmUsuariosGestion();

        public static Formularios.FrmFacturacion MiFormFacturador = new Formularios.FrmFacturacion();
    }
}
