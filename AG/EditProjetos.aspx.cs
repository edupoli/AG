using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AG
{
    public partial class EditProjetos : System.Web.UI.Page
    {
        string projetoID;
        public string mensagem = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            projetoID = Request.QueryString["projetoID"];
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
                    getProjeto(int.Parse(projetoID));
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
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
                    int cod = int.Parse(projetoID);
                    agEntities ctx = new agEntities();
                    projeto gu = ctx.projetoes.First(p => p.id == cod);
                    gu.nome = nome.Text.Trim();
                    ctx.SaveChanges();
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "erro();", true);
                    throw;
                }
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Projetos.aspx");
        }
        private void getProjeto(int cod)
        {
            agEntities ctx = new agEntities();
            projeto gu = ctx.projetoes.First(p => p.id == cod);
            nome.Text = gu.nome;
        }
    }
}