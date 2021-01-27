using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VPN.EntidadesNegocio;
using VPN.ReglasNegocio;
namespace VPN
{
    public partial class wfRegistroMiembros : System.Web.UI.Page
    {
        clsBERegistroMiembros objMiembros = new clsBERegistroMiembros();
        private readonly clsBRRegistroMiembros clsBRRegistroMiembros = new clsBRRegistroMiembros();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//Cuando refresque haga algo
            {
                LlenarMaestro();
                buscarDisponibilidad();
                //ddltipoMiembro.DataTextField = "Sí";
                //ddltipoMiembro.DataTextField = "No";
            }

        }

        private void LlenarMaestro()
        {
            DataTable dtCelebracion = clsBRRegistroMiembros.LlenarMaestro();
            ddlCelebracion.DataSource = dtCelebracion;
            ddlCelebracion.DataTextField = "Celebracion";
            ddlCelebracion.DataValueField = "CelebracionID";
            ddlCelebracion.DataBind();


        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (lblDisponible.Text == "0")
            {
                MsgBox("El servicio seleccionado no tiene puestos disponibles", this.Page, this);
                //alert("Hello world!");
            }
            else {
            LlenarEntidad();
            clsBRRegistroMiembros.Guardar(objMiembros);
            MsgBox("Su reserva ha sido guardada", this.Page, this);
            }

        }

        private void LlenarEntidad()
        {
            objMiembros.Celebracion = int.Parse(ddlCelebracion.SelectedValue);
            objMiembros.Cedula = txtCedula.Text;
            objMiembros.Nombre = txtNombre.Text;
            objMiembros.Edad = txtEdad.Text;
            objMiembros.Edad = txtCelular.Text;
            objMiembros.Edad = txtCorreo.Text;

            //objMiembros.Fiebre = int.Parse(rbFiebre.SelectedValue);
            objMiembros.TipoMiembro = int.Parse(rbTipoMiembro.SelectedValue);
            objMiembros.SintomasCovid = int.Parse(rbSintomasCovid.SelectedValue);
            objMiembros.Consentimiento = chkConsentimiento.Checked ? 1 : 0;
            objMiembros.Fecha = System.DateTime.Today;
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {
            string x = txtCedula.Text;
        }

        protected void ddlCelebracion_Change(object sender, EventArgs e)
        {
            buscarDisponibilidad();
        }

        private void buscarDisponibilidad()
        {
            int disponibilidad = clsBRRegistroMiembros.ConsultarDisponibilidadxCelebracionId(int.Parse(ddlCelebracion.SelectedValue));
            lblDisponible.Text = disponibilidad.ToString();
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        private void alert(string message)
        {
            Response.Write("<script>alert('" + message + "')</script>");
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}