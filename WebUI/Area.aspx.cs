using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using System.Runtime.Serialization.Json;
using System.Net;
using BusinessLogic;
using Helper;
namespace WebUI
{
    public partial class Area : System.Web.UI.Page
    {
        ConfiguracionBL configuracionBL = ConfiguracionBL.getConfiguracionBL;
        // List<InmuebleBE> inmuebles = new List<InmuebleBE>();
        public List<InmuebleBE> inmuebles
        {
            get
            {
                return (List<InmuebleBE>)Session["inmuebles"];
            }
            set {
                        Session["inmuebles"] = value;
                }
            }

        #region Eventos
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenarInmueblesServicio();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Initializate();
            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            AreaBE AreaBE = new AreaBE();
            AreaBE.NOMBRE = txtNombre.Text;

            AreaBE.INMUEBLE_CODIGO = ddlInmueble.SelectedItem.Value;

            configuracionBL.InsertArea(AreaBE);
            llenarTabla();
            txtNombre.Text = string.Empty;
            ddlInmueble.ClearSelection();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (hdnId.Value != null) {
                AreaBE areaBE =new  AreaBE();
                areaBE.ID = Convert.ToInt32(hdnId.Value);
                configuracionBL.DeleteArea(areaBE);
               // ScriptManager.RegisterClientScriptBlock(this.Page,this.Page.GetType(), "prue2", "ShowMessage('Operación efectuada satisfactoriamente','success');", false);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
               "esconder",
               "closeDeteleModal('Operación efectuada satisfactoriamente','success');",
               true);

                llenarTabla();
            }
        }

        #endregion


        #region Funciones
        private void llenarInmueblesServicio()
        {

            if (inmuebles == null)
            {
                /*
                inmuebles = new List<InmuebleBE>();
                inmuebles.Add(new InmuebleBE() { CODIGO = "IN1", NOMBRE = "LIMA" });
                inmuebles.Add(new InmuebleBE() { CODIGO = "IN2", NOMBRE = "CENTRO" });
                inmuebles.Add(new InmuebleBE() { CODIGO = "IN3", NOMBRE = "SALAVERRY" });
                */
                HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://petloverapp-001-site1.htempurl.com/Servicio.svc/Inmuebles/");
                req2.Method = "GET";

                HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string AlmacenesJson = reader2.ReadToEnd();
                List<InmuebleBE> lst2 = AlmacenesJson.DeserializarJsonTo<List<InmuebleBE>>();
                inmuebles = lst2;
            }

        }

        private void Initializate()
        {
            try
            {
                cargaInicial();
            }
            catch (Exception ex)
            {
            }
        }

        private void cargaInicial()
        {
            llenarTabla();
            llenarComboInmuebles();
        }

        public string GetInmueble(String codigoInmueble)
        {
            InmuebleBE inmuebleBE = inmuebles.FirstOrDefault(t => t.CODIGO.Equals(codigoInmueble));
            string salida = "";

            if (inmuebleBE != null)
                salida = inmuebleBE.NOMBRE;

            return salida;
        }

        private void llenarComboInmuebles()
        {
            ddlInmueble.DataSource = inmuebles;
            ddlInmueble.DataValueField = "CODIGO";
            ddlInmueble.DataTextField = "NOMBRE";
            ddlInmueble.DataBind();

        }

        private void llenarTabla()
        {
            rpArea.DataSource = configuracionBL.GetArea(null);
            rpArea.DataBind();
        }


        #endregion

    }
}