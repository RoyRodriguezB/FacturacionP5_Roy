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

        //al igual que con cualquier otra clase se pueden escribir atributos para el form
        public Logica.Models.Usuario MiUsuarioLocal { get; set; }

        public FrmUsuariosGestion()
        {
            InitializeComponent();
            //Paso 1.1 y 1.2
            MiUsuarioLocal = new Logica.Models.Usuario();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmUsuariosGestion_Load(object sender, EventArgs e)
        {
            ListarUsuariosActivos();

            CargarRolesDeUsuarioEnCombo();

            LimpiarForm();
        }

        private void LimpiarForm()
        {
            // elimina  los datos de los controles del formulario 
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
            //crear un objeto de tipo usuario
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
                    
                    R = true;
                }
                else
                {
                    //Si el botón de Editar está "apagado" la única otra opción es que estemos en modo de
                    //  agregación y acá si debemos validar el password

                    if (!string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                    {
                        R = true;
                    }

                }

            }
            else
            {

                //retroalimentar al usuario  
                //debemos reevaluar cada cuadro de texto  
        

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
        }

        private void DgvListaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaUsuarios.SelectedRows.Count == 1)
            {
                DataGridViewRow Fila = DgvListaUsuarios.SelectedRows[0];





            }
        }
    }
  }

