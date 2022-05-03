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
   

    public partial class FrmFacturacionItemGestion : Form
    {
        //semana 14 primero
        DataTable ListaItems { get; set; }

        Logica.Models.Producto MiProducto { get; set; }

        public FrmFacturacionItemGestion()
        {
            InitializeComponent();
            //semana 14 segundo
            ListaItems = new DataTable();
            MiProducto = new Logica.Models.Producto();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {

            // se valida que no pase el item en cero 
            if (ValidarItem())
            {
                //procedemos con la carga del item en el detalle del formulario de facturación 

                //como el formulario de facturación es globaldel detalle, entonces vamos a crear una nueva fila de ese datatable
                // y la llenamos con información 
                //de la fila que seleccionamos 

                DataRow NuevaLineaDetalleEnFacturacion = ObjetosGlobales.MiFormFacturador.ListaDetallesLocal.NewRow();

                NuevaLineaDetalleEnFacturacion["IDProducto"] = MiProducto.IDProducto;

                NuevaLineaDetalleEnFacturacion["DescripcionItem"] = MiProducto.DescripcionProducto;

                NuevaLineaDetalleEnFacturacion["CantidadFacturada"] = TxtCantidad.Value;

                NuevaLineaDetalleEnFacturacion["PorcentajeDescuento"] = Convert.ToDecimal(TxtDescuento.Text.Trim());

                NuevaLineaDetalleEnFacturacion["PrecioUnitario"] = MiProducto.PrecioUnitario;

                //calculo del impuesto por línea

                decimal PorcentajeDescuento = Convert.ToDecimal(TxtDescuento.Text.Trim());

                decimal PrecioMenosDescuento = MiProducto.PrecioUnitario - ((MiProducto.PrecioUnitario * PorcentajeDescuento) / 100);
                decimal Impuestos = ((PrecioMenosDescuento * MiProducto.MiImpuesto.MontoImpuesto) / 100) * TxtCantidad.Value;
                NuevaLineaDetalleEnFacturacion["ImpuestosLinea"] = Impuestos;

                decimal TotalLinea = PrecioMenosDescuento * TxtCantidad.Value + Impuestos;

                NuevaLineaDetalleEnFacturacion["TotalLinea"] = TotalLinea;

                NuevaLineaDetalleEnFacturacion["SubTotalLinea"] = TxtCantidad.Value * PrecioMenosDescuento;

                //una vez que se han alimentado los datos base para la línea, se prodece a adjuntarla al datatable de detalles del form de facturación 


                ObjetosGlobales.MiFormFacturador.ListaDetallesLocal.Rows.Add(NuevaLineaDetalleEnFacturacion);

                //retornamos        OK como respuesta al form de facturación 
                DialogResult = DialogResult.OK;

            }


        }





        private bool ValidarItem()
        {
            bool R = false;

            if (DgvListaItems.SelectedRows.Count == 1 && TxtCantidad.Value > 0)
            {
                //validación correcta
                R = true;
            }
            else
            {
                if (DgvListaItems.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debeseleccionar un Item de la lista!", "Error de valición", MessageBoxButtons.OK);
                    return false;
                }

                if (TxtCantidad.Value == 0)
                {
                    MessageBox.Show("La cantidadno puede ser cero", "Error de valición", MessageBoxButtons.OK);
                    return false;
                }
            }

            return R;


        }

        private void DgvListaItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgvListaItems.ClearSelection();
        }

        private void FrmFacturacionItemGestion_Load(object sender, EventArgs e)
        {
            LlenarListaItems();
        }

        private void LlenarListaItems()
        {
            ListaItems = new DataTable();

            ListaItems = MiProducto.Listar();

            DgvListaItems.DataSource = ListaItems;

            DgvListaItems.ClearSelection();

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CalcularPrecioFinal(Logica.Models.Producto pProducto, decimal PorcentajeDescuento)
        {
            decimal PrecioConDescuento = pProducto.PrecioUnitario - ((pProducto.PrecioUnitario * PorcentajeDescuento) / 100);

            decimal PrecioConImpuesto = PrecioConDescuento + ((PrecioConDescuento * pProducto.MiImpuesto.MontoImpuesto) / 100);

            TxtPrecioFinal.Text = PrecioConImpuesto.ToString();
        }

        private void DgvListaItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaItems.SelectedRows.Count == 1)
            {
                DataGridViewRow FilaSelecciona = DgvListaItems.SelectedRows[0];

                int IdProductoSeleccionado = Convert.ToInt32(FilaSelecciona.Cells["CIDProducto"].Value);

                //usamos la funcion de consulta por el ID del producto para llamar a un objeto con todos los atributos necesarios 

                MiProducto = MiProducto.ConsultarPorID(IdProductoSeleccionado);

                if (MiProducto.IDProducto > 0)
                {
                    TxtIVA.Text = MiProducto.MiImpuesto.MontoImpuesto.ToString();
                    TxtPrecioUnitario.Text = MiProducto.PrecioUnitario.ToString();

                    //calcular el monto del precio final (tomando en cuenta el % de descuento) 
                    CalcularPrecioFinal(MiProducto, Convert.ToDecimal(TxtDescuento.Text.Trim()));
                }

            }
        }

        private void TxtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDescuento.Text.Trim()))
            {
                TxtDescuento.Text = "0";
                TxtDescuento.SelectAll();
            }
            else
            {
                CalcularPrecioFinal(MiProducto, Convert.ToDecimal(TxtDescuento.Text.Trim()));
            }
        }
    }
}
