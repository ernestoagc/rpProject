using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BusinessLogic;
namespace WebUI
{
    public partial class Usuario : System.Web.UI.Page
    {
        ConfiguracionBL configuracionBL = ConfiguracionBL.getConfiguracionBL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Initializate();
            }

        }
        private void Initializate()
        {
            try
            {
                cargarInicial();
            }
            catch (Exception ex)
            {
            }
        }

        private void cargarInicial() {
            llenarAreas();
            llenarTabla();
        }

        private void llenarAreas() {

            lbArea.DataSource = configuracionBL.GetArea(null);
            lbArea.DataTextField = "NOMBRE";
            lbArea.DataValueField = "ID";
            lbArea.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            UsuarioBE usuarioBE = new UsuarioBE();
            usuarioBE.NOMBRE = txtNombre.Text;
            usuarioBE.APELLIDO_PATERNO = txtApellidoPaterno.Text;
            usuarioBE.APELLIDO_MATERNO = txtApellidoMaterno.Text;
       
            List<AreaBE> areas = new List<AreaBE>();
            foreach (ListItem item in lbArea.Items)
            {
                if (item.Selected)
                {
                    AreaBE areaBE = new AreaBE();
                    areaBE.ID=Convert.ToInt32(item.Value);
                    areas.Add(areaBE);
                }
            }

            lbArea.ClearSelection();
            usuarioBE.AREAS = areas;
            configuracionBL.InsertUsuario(usuarioBE);


            llenarTabla();
        }

        private void llenarTabla() {
            List<UsuarioBE> usuarios = configuracionBL.GetUsuario(null);
            rpUsuario.DataSource = usuarios;
            rpUsuario.DataBind();
            limpiarCampos();
        }

        private void limpiarCampos() {
            txtNombre.Text = String.Empty;
            txtApellidoPaterno.Text = String.Empty;
            txtApellidoMaterno.Text = String.Empty;
        }
    }
}