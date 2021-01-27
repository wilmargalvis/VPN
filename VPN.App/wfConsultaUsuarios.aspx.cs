using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VPN.ReglasNegocio;

namespace VPN.App
{
    public partial class wfConsultaUsuarios : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtCedula.Text))
            {
                MsgBox("No ha ingresado los datos del miembro que desea buscar", this.Page, this);
                return;
            }

            clsBRRegistroMiembros objBR = new clsBRRegistroMiembros();
            DataTable dt = objBR.Buscar(txtCedula.Text, txtNombre.Text);

            gvTablaUno.DataSource = dt;
            gvTablaUno.DataBind();
            gvTablaUno.ForeColor= System.Drawing.Color.White;
            txtTemperatura.Visible = true;
            lbltemperatura.Visible = true;
            btnGuardarTemperatura.Visible = true;

            if(gvTablaUno.Rows.Count ==0){
                txtTemperatura.Visible = false;
                lbltemperatura.Visible = false;
                btnGuardarTemperatura.Visible = false;
            }
        }

        protected void linkBuscarMiembro_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("~/wfRegistroMiembros.aspx");
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void btnGuardarTemperatura_Click(object sender, EventArgs e)
        {
            string IDMiembro = hfMiembroId.Value;
            clsBRRegistroMiembros objGuardarTemperatura = new clsBRRegistroMiembros();
            objGuardarTemperatura.GuadarTemperatura(IDMiembro,txtTemperatura.Text);
            MsgBox("Miembro actualizado correctamente", this.Page, this);
        }

        protected void btnEditar_Command(object sender, CommandEventArgs e)
        {
            //int MiembroId = int.Parse(e.CommandArgument.ToString());
            hfMiembroId.Value = e.CommandArgument.ToString();
            lblNombre.Text = e.CommandName;
        }
    }
}