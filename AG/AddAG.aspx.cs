using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AG
{
    public partial class AddAG : System.Web.UI.Page
    {
        public string mensagem = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logado"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            if (Session["perfil"].ToString() != "administrador")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "acessoNegado();", true);
                Response.Redirect("login.aspx");
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (numeroAG.Text == "")
            {
                mensagem = "Campo Nnumero é obrigatorio";
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroGeral();", true);
                numeroAG.Focus();
            }
            else
            {
                try
                {
                    agEntities ctx = new agEntities();
                    ag gtronco = new ag();
                    gtronco.numero = numeroAG.Text.Trim();
                    gtronco.projetoID = int.Parse(cboxProjeto.SelectedValue);
                    ctx.ags.Add(gtronco);
                    ctx.SaveChanges();
                    numeroAG.Text = "";
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "erro();", true);

                }
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AGs.aspx");
        }
    }
}