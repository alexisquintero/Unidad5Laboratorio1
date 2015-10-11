using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace LabABM
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.cargarDiasCalendario();
        }
        private void cargarDiasCalendario()
        {
		    if (!Page.IsPostBack)
	        {
		        for (int i = 1; i < 32; i++)
                {
                    this.ddlDiaFechaNacimiento.Items.Insert(i - 1, new ListItem(i.ToString()));
                }   
	        }
            if (this.PaginaEnEstadoEdicion())
            {
                this.lblAccion.Text = "Editar Usuario <idUsuario>";
            }
            else{
                this.lblAccion.Text = "Agregar Nuevo Usuario";
            }  
        }
        private bool PaginaEnEstadoEdicion()
        {
            if (Request.QueryString["id"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CargarDatosUsuario(int idUsuario)
        {
            // 1 - Obtener los datos del usuario en cuestión
            ManagerUsuarios managerUsuario = new ManagerUsuarios();
            Usuario usuario = managerUsuario.GetUsuario(idUsuario);
            // 2 - Cargar en los controles de la tabla los datos del usuario obtenido

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Celular = txtCelular.Text;
            usuario.Clave = txtClave.Text;
            usuario.Direccion = txtDirección.Text;
            usuario.Email = txtEmail.Text;
//            usuario.FechaNac = ;
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.NroDoc = int.Parse(txtNroDocumento.Text);
            usuario.Telefono = txtTelefono.Text;
//            usuario.TipoDoc = ;
            ManagerUsuarios managerUsuario = new ManagerUsuarios();
            if (this.PaginaEnEstadoEdicion())
            {
                managerUsuario.ActualizarUsuario(usuario);
            }
            else
            {
                managerUsuario.AgregarUsuario(usuario);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //??? 
        }
    }
}