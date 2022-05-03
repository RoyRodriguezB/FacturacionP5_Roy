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
    public partial class FrmFacturacion : Form
    {
        public Logica.Models.Factura FacturaLocal { get; set; }

        //para administrar los detalles de forma local, la composición del obj
        //factura local, sin embargo ya que usamos un datagridview 
        //datatable local para almacenar la info de detalles. 
        //contenida en el datatable de detalles,
        //pasará al objeto compuesto para agregar esos detalle en la tabla de muchos a muchos. 
        public DataTable ListaDetallesLocal { get; set; }
        public FrmFacturacion()
        {
            InitializeComponent();

            FacturaLocal = new Logica.Models.Factura();

            ListaDetallesLocal = new DataTable();
        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            MdiParent = ObjetosGlobales.MiFormularioPrincipal;

            CargarComboEmpresas();
            CargarComboFacturaTipos();
            CargarComboUsuarios();

            Limpiar();


        }

        private void Limpiar()
        {
            CboxUsuario.SelectedValue = ObjetosGlobales.MiUsuarioGlobal.IDUsuario;

            CboxTipoFactura.SelectedIndex = -1;

            DtpFechaFactura.Value = DateTime.Now.Date;

            TxtNotas.Clear();

            LblSubTotal.Text = "0";
            LblDescuentos.Text = "0";
            LblImpuestos.Text = "0";
            LblTotal.Text = "0";

            FacturaLocal = new Logica.Models.Factura();

            //el datagridview espera tener de fondo un datatable para mostrar datos.
            //el formulario al iniciar no muestra datos y debería tener de fondo el dt 
            //con la estructura necesaria y datos en blanco para luego poder agregar lineas. 

            ListaDetallesLocal = new DataTable();
            ListaDetallesLocal = FacturaLocal.AsignarEsquemaDetalle();

            DgvListaItems.DataSource = ListaDetallesLocal;

            TxtIdCliente.Clear();
            LblNombreCliente.Text = "";
        }

        private void CargarComboUsuarios()
        {
            CboxUsuario.DisplayMember = "Nombre";
            CboxUsuario.ValueMember = "IDUsuario";
            CboxUsuario.DataSource = FacturaLocal.MiUsuario.ListarActivos();
            CboxUsuario.SelectedIndex = -1;
        }

        private void CargarComboEmpresas()
        {
            CboxEmpresa.DisplayMember = "desc";
            CboxEmpresa.ValueMember = "id";
            CboxEmpresa.DataSource = FacturaLocal.MiEmpresa.Listar();
            CboxEmpresa.SelectedIndex = -1;
        }

        private void CargarComboFacturaTipos()
        {
            CboxTipoFactura.DisplayMember = "desc";
            CboxTipoFactura.ValueMember = "id";
            CboxTipoFactura.DataSource = FacturaLocal.MiTipo.Listar();
            CboxTipoFactura.SelectedIndex = -1;
        }

        private void TxtIdCliente_DoubleClick(object sender, EventArgs e)
        {
            //al dar doble clic en el cuadro de texto se abre la ventana de búsqueda de clientes

            Form MiFormBuscarCliente = new Formularios.FrmClienteSeleccionar();

            DialogResult respuesta = MiFormBuscarCliente.ShowDialog();

            if (respuesta == DialogResult.OK)
            {
                LblNombreCliente.Text = FacturaLocal.MiCliente.Nombre;
                TxtIdCliente.Text = FacturaLocal.MiCliente.IDCliente.ToString();
            }
            else { LblNombreCliente.Text = ""; }
        }
    }
}
