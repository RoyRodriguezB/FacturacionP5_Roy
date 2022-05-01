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
    public partial class FrmUsuariosGestion : Form
    {

        // se pueden escribir atributos para el form
        public Logica.Models.Usuario MiUsuarioLocal { get; set; }

        public FrmUsuariosGestion()
        {
            InitializeComponent();
            // 1.1 y 1.2
            MiUsuarioLocal = new Logica.Models.Usuario();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmUsuariosGestion_Load(object sender, EventArgs e)
        {
            MdiParent = ObjetosGlobales.MiFormularioPrincipal;

            ListarUsuariosActivos();

            CargarRolesDeUsuarioEnCombo();

            LimpiarForm();

            ActivarAgregar();
        }

        private void ActivarAgregar()
        {
            //activa  botón de agregar 
            BtnAgregar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnEliminar.Enabled = false;
        }

        private void ActivarEditarYEliminar()
        {
            //activa  botón de editarr 
            BtnAgregar.Enabled = false;
            BtnEditar.Enabled = true;
            BtnEliminar.Enabled = true;
        }

        private void LimpiarForm()
        {
            // elimina   datos de los controles del formulario 
            TxtCodigo.Clear();
            TxtNombre.Clear();
            TxtEmail.Clear();
            TxtCedula.Clear();
            TxtTelefono.Clear();
            TxtEmailRespaldo.Clear();
            TxtPassword.Clear();

            CboxTipoUsuario.SelectedIndex = -1;
        }

        private void CargarRolesDeUsuarioEnCombo()
        {
            //crear  objeto de tipo usuario
            Logica.Models.UsuarioRol ObjRolDeUsuario = new Logica.Models.UsuarioRol();

            DataTable ListaRoles = new DataTable();

            ListaRoles = ObjRolDeUsuario.Listar();

            CboxTipoUsuario.ValueMember = "id";
            CboxTipoUsuario.DisplayMember = "d";

            CboxTipoUsuario.DataSource = ListaRoles;

            CboxTipoUsuario.SelectedIndex = -1;
        }

        private void ListarUsuariosActivos()
        {
            // encapsular código que
            //tienda a ser reutilizable 

            // 1 y 1.1 de SdUsuariosListarActivos
            Logica.Models.Usuario MiUsuario = new Logica.Models.Usuario();

            // 2 y 2.5
            DataTable dt = MiUsuario.ListarActivos();

            // datos en el dgv
            DgvListaUsuarios.DataSource = dt;

            DgvListaUsuarios.ClearSelection();
        }

        private void ListarUsuariosDesactivados()
        {
            // encapsular código que
            //tienda a ser reutilizable 

            // 
            Logica.Models.Usuario MiUsuario = new Logica.Models.Usuario();

            // 
            DataTable dt = MiUsuario.ListarInactivos();

            // datos en el dgv
            DgvListaUsuarios.DataSource = dt;

            DgvListaUsuarios.ClearSelection();
        }

        private bool ValidarDatosRequeridos()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtTelefono.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtEmailRespaldo.Text.Trim()) &&
                CboxTipoUsuario.SelectedIndex > -1)
            {
                if (BtnEditar.Enabled)
                {
                    //si estamos en modo de edicón el password es opcional 
                    //y poder retornar True en este punto 
                    R = true;
                }
                else
                {
                    //Si el botón de Editar está "apagado" la única otra opción 
                    // es que estemos en modo de Agregación y acá si debemos validar 
                    
                    if (!string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                    {
                        R = true;
                    }

                }
            }
            else
            {

                //retroalimentar al usuario  
                //


                if (string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    MessageBox.Show("El Nombre del Usuario es requerido", "Error de Validación", MessageBoxButtons.OK);
                    TxtNombre.Focus();
                    return false;
                }


                if (string.IsNullOrEmpty(TxtEmail.Text.Trim()))
                {
                    MessageBox.Show("El Email del Usuario es requerido", "Error de Validación", MessageBoxButtons.OK);
                    TxtEmail.Focus();
                    return false;
                }


                if (string.IsNullOrEmpty(TxtCedula.Text.Trim()))
                {
                    MessageBox.Show("La Cédula del Usuario es requerida", "Error de Validación", MessageBoxButtons.OK);
                    TxtCedula.Focus();
                    return false;
                }


                if (string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
                {
                    MessageBox.Show("El Número de Teléfono del Usuario es requerido", "Error de Validación", MessageBoxButtons.OK);
                    TxtTelefono.Focus();
                    return false;
                }


                if (string.IsNullOrEmpty(TxtEmailRespaldo.Text.Trim()))
                {
                    MessageBox.Show("El Correo de Respaldo del Usuario es requerido", "Error de Validación", MessageBoxButtons.OK);
                    TxtEmailRespaldo.Focus();
                    return false;
                }


                if (string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                {
                    MessageBox.Show("La Contraseña del Usuario es requerida", "Error de Validación", MessageBoxButtons.OK);
                    TxtPassword.Focus();
                    return false;
                }

                if (CboxTipoUsuario.SelectedIndex == -1)
                {
                    MessageBox.Show("El Tipo De Usuario es requerido", "Error de Validación", MessageBoxButtons.OK);
                    CboxTipoUsuario.Focus();
                    return false;
                }

            }

            return R;

        }



        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            
            if (ValidarDatosRequeridos())
            {

                string Pregunta = string.Format("¿Está seguro de agregar al Usuario {0}?", TxtNombre.Text.Trim());

                DialogResult RespuestaDelUsuario = MessageBox.Show(Pregunta, "???", MessageBoxButtons.YesNo);

                if (RespuestaDelUsuario == DialogResult.Yes)
                {

                    //TEMPORAL: se agregan los valores de los atributos del objeto local
                    MiUsuarioLocal.Nombre = TxtNombre.Text.Trim();
                    MiUsuarioLocal.NombreUsuario = TxtEmail.Text.Trim();
                    MiUsuarioLocal.Cedula = TxtCedula.Text.Trim();
                    MiUsuarioLocal.Telefono = TxtTelefono.Text.Trim();
                    MiUsuarioLocal.Contrasennia = TxtPassword.Text.Trim();
                    MiUsuarioLocal.CorreoDeRespaldo = TxtEmailRespaldo.Text.Trim();
                    MiUsuarioLocal.MiRol.IDUsuarioRol = Convert.ToInt32(CboxTipoUsuario.SelectedValue);

                    //vamos con "SeqUsuarioAgregar"

                    //1.1 y 1.2  en el constructor 

                    // 1.3 y 1.3.6 
                    bool A = MiUsuarioLocal.ConsultarPorCedula();

                    // 1.4 y 1.4.6
                    bool B = MiUsuarioLocal.ConsultarPorEmail();

                    // 1.5
                    if (!A && !B)
                    {
                        // 1.6, 1.6.6 y 1.7
                        if (MiUsuarioLocal.Agregar())
                        {
                            // 1.8
                            MessageBox.Show("Usuario agregado correctamente!", ":)", MessageBoxButtons.OK);
                        }
                        else
                        {
                            // 1.8
                            MessageBox.Show("Ha ocurrido un error y el usuario no se guardó ", ":(", MessageBoxButtons.OK);
                        }

                        ListarUsuariosActivos();


                       LimpiarForm();

                    }
                    else
                    {
                        //indicar al usuario qué validación falló 
                        if (A)
                        {
                            MessageBox.Show("Ya existe un usuario con la Cédula digitada", "Error de Validación", MessageBoxButtons.OK);
                            TxtCedula.Focus();
                            TxtCedula.SelectAll();
                        }
                        if (B)
                        {
                            MessageBox.Show("Ya existe un usuario con el Email digitado", "Error de Validación", MessageBoxButtons.OK);
                            TxtEmail.Focus();
                            TxtEmail.SelectAll();
                        }
                    }
                }

            }
        }

        private void DgvListaUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgvListaUsuarios.ClearSelection();
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validacion.CaracteresTexto(e, true);
        }

        private void TxtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validacion.CaracteresTexto(e, false, true);
        }

        private void TxtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validacion.CaracteresNumeros(e);
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validacion.CaracteresTexto(e, true);
        }

        private void TxtEmailRespaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validacion.CaracteresTexto(e, false, true);
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validacion.CaracteresTexto(e);
        }

        private void BtnLimpiarForm_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            ActivarAgregar();
        }

        private void DgvListaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaUsuarios.SelectedRows.Count == 1)
            {
                DataGridViewRow Fila = DgvListaUsuarios.SelectedRows[0];
                //semana 8 mostrar datos al seleccionar los datos

                int IdUsuarioSeleccionado = Convert.ToInt32(Fila.Cells["CIDUsuario"].Value);

                MiUsuarioLocal = new Logica.Models.Usuario();
                MiUsuarioLocal = MiUsuarioLocal.ConsultarPorID(IdUsuarioSeleccionado);

                if (MiUsuarioLocal.IDUsuario > 0)
                {
                    //se representa la info en los controles respectivos usando el obj MiUsuarioLocal como
                    //fuente de datos 

                    LimpiarForm();

                    TxtCodigo.Text = MiUsuarioLocal.IDUsuario.ToString();
                    TxtNombre.Text = MiUsuarioLocal.Nombre;
                    TxtEmail.Text = MiUsuarioLocal.NombreUsuario;
                    TxtCedula.Text = MiUsuarioLocal.Cedula;
                    TxtTelefono.Text = MiUsuarioLocal.Telefono;
                    TxtEmailRespaldo.Text = MiUsuarioLocal.CorreoDeRespaldo;

                    CboxTipoUsuario.SelectedValue = MiUsuarioLocal.MiRol.IDUsuarioRol;

                    ActivarEditarYEliminar();

                    //debemos considerar si la lista que se está visualizando es la de usuario 
                    //activos o inactivos. en caso que sean los inactivos, se debe desactivar la 
                    //edición de los campos y la utilización del botón Editar
                    if (CbVerActivos.Checked)
                    {
                        GbDetalles.Enabled = true;
                        BtnEditar.Enabled = true;
                    }
                    else
                    {
                        GbDetalles.Enabled = false;
                        BtnEditar.Enabled = false;
                    }

                }
            } 
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            //código es muy SIMILAR al de agregar

            if (ValidarDatosRequeridos())
            {
                string Mensaje = string.Format("¿Desea continuar con la modificación del usuario {0}", TxtNombre.Text.Trim());

                DialogResult respuesta = MessageBox.Show(Mensaje, "???", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    MiUsuarioLocal.Nombre = TxtNombre.Text.Trim();
                    MiUsuarioLocal.NombreUsuario = TxtEmail.Text.Trim();
                    MiUsuarioLocal.Cedula = TxtCedula.Text.Trim();
                    MiUsuarioLocal.Telefono = TxtTelefono.Text.Trim();
                    MiUsuarioLocal.CorreoDeRespaldo = TxtEmailRespaldo.Text.Trim();
                    MiUsuarioLocal.Contrasennia = TxtPassword.Text.Trim();
                    MiUsuarioLocal.MiRol.IDUsuarioRol = Convert.ToInt32(CboxTipoUsuario.SelectedValue);

                    if (MiUsuarioLocal.Editar())
                    {
                        string MensajeExito = string.Format("El usuario {0} se ha modificado correctamente", MiUsuarioLocal.Nombre);

                        MessageBox.Show(MensajeExito, ":)", MessageBoxButtons.OK);

                        ListarUsuariosActivos();
                        LimpiarForm();
                        ActivarAgregar();
                    }
                    else
                    {
                        string MensajeFracaso = string.Format("El usuario {0} No se ha modificado correctamente", MiUsuarioLocal.Nombre);

                        MessageBox.Show(MensajeFracaso, ":(", MessageBoxButtons.OK);

                        //TODO: determinar si es buena idea limpiar el form 
                    }
                }
            }
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            //salir del cuadro text validamos tiempo real formato email sea correcto
            if (!string.IsNullOrEmpty(TxtEmail.Text.Trim()) && !Validacion.ValidarEmail(TxtEmail.Text.Trim()))
            {
                MessageBox.Show("El formato del email es incorrecto!", "Error de Validación", MessageBoxButtons.OK);
                TxtEmail.Focus();
                TxtEmail.SelectAll();
            }
        }

        private void TxtEmailRespaldo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtEmailRespaldo.Text.Trim()) && !Validacion.ValidarEmail(TxtEmailRespaldo.Text.Trim()))
            {
                MessageBox.Show("El formato del email de respaldo es incorrecto!", "Error de Validación", MessageBoxButtons.OK);
                TxtEmailRespaldo.Focus();
                TxtEmailRespaldo.SelectAll();
            }
        }

        private void BtnVerPassword_MouseDown(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = false;
        }

        private void BtnVerPassword_MouseUp(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = true;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            //En la funcionalidad de Editar la consulta por el ID se ejecuta directamente en la 
            //función Editar(), acá lo voy a consultar previamente 

            if (MiUsuarioLocal.IDUsuario > 0)
            {
                Logica.Models.Usuario UsuarioConsulta = new Logica.Models.Usuario();

                UsuarioConsulta = MiUsuarioLocal.ConsultarPorID(MiUsuarioLocal.IDUsuario);

                if (UsuarioConsulta.IDUsuario > 0)
                {
                    string Mensaje = "";

                    if (CbVerActivos.Checked)
                    {
                        Mensaje = string.Format("¿Desea continuar con la Eliminación del usuario {0}", MiUsuarioLocal.Nombre);
                    }
                    else
                    {
                        Mensaje = string.Format("¿Desea continuar con la Activación del usuario {0}", MiUsuarioLocal.Nombre);
                    }

                    DialogResult resp = MessageBox.Show(Mensaje, "???", MessageBoxButtons.YesNo);

                    if (resp == DialogResult.Yes)
                    {

                        if (CbVerActivos.Checked)
                        {
                            if (MiUsuarioLocal.Eliminar())
                            {
                                MessageBox.Show("Usuario Eliminado Correctamente", ":/", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            if (MiUsuarioLocal.Activar())
                            {
                                MessageBox.Show("Usuario Activado Correctamente", ":)", MessageBoxButtons.OK);
                            }
                        }

                        CbVerActivos.Checked = true;
                        ListarUsuariosActivos();
                        LimpiarForm();
                        ActivarAgregar();

                    }
                }
            }
        }

        private void CbVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (CbVerActivos.Checked)
            {
                BtnEliminar.Text = "ELIMINAR";
                ListarUsuariosActivos();
                LimpiarForm();
                ActivarAgregar();
            }
            else
            {
                BtnEliminar.Text = "ACTIVAR";
                ListarUsuariosDesactivados();
                LimpiarForm();
                ActivarEditarYEliminar();
            }
        }
    }
}
