using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AG
{
    public partial class AddGruposUsuarios : System.Web.UI.Page
    {
        public string mensagem = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logado"] == null)
            {
               // Response.Redirect("login.aspx");
            }
            else
            if (Session["perfil"].ToString() != "administrador")
            {
               // ClientScript.RegisterStartupScript(GetType(), "Popup", "acessoNegado();", true);
               // Response.Redirect("login.aspx");
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (nome.Text == "")
            {
                mensagem = "Campo Nome é obrigatorio";
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroGeral();", true);
                nome.Focus();
            }
            else
            {
                try
                {
                    agEntities ctx = new agEntities();
                    projeto gu = new projeto();
                    gu.nome = nome.Text.Trim();
                    ctx.projetoes.Add(gu);
                    ctx.SaveChanges();
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
                }
                catch (Exception ex)
                {
                    mensagem = "Ocorreu o seguinte erro ao tentar gravar: "+ ex.Message;
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "erroGeral();", true);
                }
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Projetos.aspx");
        }
    }
}