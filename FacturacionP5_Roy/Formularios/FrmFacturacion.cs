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

        private void CargarDetalleDeFactura()
        {
            //cargar en la composición los detalles a partir del datatable de detalles local 
            foreach (DataRow item in ListaDetallesLocal.Rows)
            {
                Logica.Models.FacturaDetalle detalle = new Logica.Models.FacturaDetalle();

                detalle.CantidadFactura = Convert.ToDecimal(item["CantidadFacturada"]);
                detalle.DescripcionItem = Convert.ToString(item["DescripcionItem"]);
                detalle.ImpuestosLinea = Convert.ToDecimal(item["ImpuestosLinea"]);
                detalle.MiProducto.IDProducto = Convert.ToInt32(item["IDProducto"]);
                detalle.PorcentajeDescuento = Convert.ToDecimal(item["PorcentajeDescuento"]);
                detalle.PrecioUnitario = Convert.ToDecimal(item["PrecioUnitario"]);
                detalle.SubTotalLinea = Convert.ToDecimal(item["SubTotalLinea"]);
                detalle.TotalLinea = Convert.ToDecimal(item["TotalLinea"]);

                FacturaLocal.DetalleItems.Add(detalle);
            }
        }


        private void BtnFacturar_Click(object sender, EventArgs e)
        {

            // Efectuar las validaciones correspondientes
            // EJ que la fecha no sea mayor a la actual, y que 
            //se hayan seleccionado datos mínimos como cliente, usuario etc 
            if (ListaDetallesLocal != null && ListaDetallesLocal.Rows.Count > 0)
            {
                //datos de encabezado
                FacturaLocal.MiCliente.IDCliente = Convert.ToInt32(TxtIdCliente.Text.Trim());
                FacturaLocal.MiTipo.IDFacturaTipo = Convert.ToInt32(CboxTipoFactura.SelectedValue);
                FacturaLocal.MiUsuario.IDUsuario = Convert.ToInt32(CboxUsuario.SelectedValue);
                FacturaLocal.MiEmpresa.IDEmpresa = Convert.ToInt32(CboxEmpresa.SelectedValue);
                FacturaLocal.Fecha = DtpFechaFactura.Value.Date;
                FacturaLocal.Anotaciones = TxtNotas.Text.Trim();

                //datos del detalle
                CargarDetalleDeFactura();

                if (FacturaLocal.Agregar())
                {

                    MessageBox.Show("Factura guardada correctamente", ":)", MessageBoxButtons.OK);

                    // llamado a reporte

                    Limpiar();

                }



            }
        }

        private void Totalizar()
        {
            //semana 14
            if (ListaDetallesLocal != null && ListaDetallesLocal.Rows.Count > 0)
            {
                //se recorre cada linea del detalle y se sumarizan los montos correspondientes 
                decimal Subt = 0;
                decimal Descuentos = 0;
                decimal Impuestos = 0;
                decimal Total = 0;

                foreach (DataRow item in ListaDetallesLocal.Rows)
                {
                    //se acumulan los datos en las variables de totalización 
                    Subt += Convert.ToDecimal(item["CantidadFacturada"]) * Convert.ToDecimal(item["PrecioUnitario"]);

                    Descuentos += Subt * Convert.ToDecimal(item["PorcentajeDescuento"]) / 100;

                    Impuestos += Convert.ToDecimal(item["ImpuestosLinea"]);

                    Total += Convert.ToDecimal(item["TotalLinea"]);
                }
                //semana 14
                //una vez tenemos las sumas se presentan en los txt correspondiente usando un formato fácil de leer para el 
                //usuario 

                LblSubTotal.Text = string.Format("{0:N2}", Subt);
                LblDescuentos.Text = string.Format("{0:N2}", Descuentos);
                LblImpuestos.Text = string.Format("{0:N2}", Impuestos);
                LblTotal.Text = string.Format("{0:N2}", Total);

            }


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

        private void BtnItemAgregar_Click(object sender, EventArgs e)
        {

            Form FormSeleccionDeItem = new FrmFacturacionItemGestion();

            DialogResult resp = FormSeleccionDeItem.ShowDialog();

            if (resp == DialogResult.OK)
            {
                //se ha seleccionado correctamente un item 

                DgvListaItems.DataSource = ListaDetallesLocal;

                Totalizar();

                //semana14
            }
        }

    }
}
