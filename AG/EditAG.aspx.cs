using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AG
{
    public partial class EditAG : System.Web.UI.Page
    {
        int agID;
        public string mensagem = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            agID = Convert.ToInt32(Request.QueryString["agID"]);
            if (!Page.IsPostBack)
            {
                if (!Page.IsPostBack)
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
                    buscarAG(agID);
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (numeroAG.Text == "")
            {
                mensagem = "Campo Numero é obrigatorio";
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroGeral();", true);
                numeroAG.Focus();
            }
            else
            {
                try
                {
                    agEntities ctx = new agEntities();
                    ag gr = ctx.ags.First(g => g.id == agID);
                    gr.numero = numeroAG.Text.Trim();
                    gr.projetoID = Convert.ToInt32(cboxProjeto.SelectedValue);
                    ctx.SaveChanges();
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
        private void buscarAG(int cod)
        {
            try
            {
                agEntities ctx = new agEntities();
                ag gr = ctx.ags.First(g => g.id == cod);
                numeroAG.Text = gr.numero.ToString();
                cboxProjeto.SelectedValue = Convert.ToString(gr.projetoID);
            }
            catch (Exception ex)
            {
                mensagem = "Ocorreu o seguinte erro: " + ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroGeral();", true);
            }
        }

    }
}