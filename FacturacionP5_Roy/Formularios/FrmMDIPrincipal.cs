using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionP5_Roy.Formularios
{
    public partial class FrmMDIPrincipal : Form
    {
        public FrmMDIPrincipal()
        {
            InitializeComponent();
        }

        private void gestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ObjetosGlobales.MiFormDeGestionDeUsuarios.Visible)
            {
                ObjetosGlobales.MiFormDeGestionDeUsuarios = new FrmUsuariosGestion();
                ObjetosGlobales.MiFormDeGestionDeUsuarios.Show();
            }
        }

        private void FrmMDIPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMDIPrincipal_Load(object sender, EventArgs e)
        {
            string UsuarioLogueado = string.Format("{0}({1};{2})",
                ObjetosGlobales.MiUsuarioGlobal.Nombre,
                ObjetosGlobales.MiUsuarioGlobal.NombreUsuario,
                ObjetosGlobales.MiUsuarioGlobal.MiRol.Rol);


            LblUsuarioLogueado.Text = ObjetosGlobales.MiUsuarioGlobal.Nombre;

            //ahora revisamos el tipo de rol y si es facturador ocultamos ciertas opciones 

            switch (ObjetosGlobales.MiUsuarioGlobal.MiRol.IDUsuarioRol)
            {
                case 1:
                    //Es un admmin, no se debe hacer bloqueo por el momento.
                    break;
                case 2:
                    //Es un facturador y se debe ocultar ciertas opciones del menú 
                    //semana 10 solo el admin pue ver estas opciones

                    MnuUsuariosGestion.Enabled = false;
                    MnuProveedoresGestion.Enabled = false;
                    MnuProductosGestion.Enabled = false;
                    MnuEmpresaGestion.Enabled = false;

                    break;
            }

            //Activamos el timer
            TmrEstablecerFechaHora.Enabled = true;
        }

        private void TmrEstablecerFechaHora_Tick(object sender, EventArgs e)
        {
            LblFechaHora.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }
    }
}
