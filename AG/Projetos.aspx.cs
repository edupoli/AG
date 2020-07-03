using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AG
{
    public partial class Projetos : System.Web.UI.Page
    {
        string projetoID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetProjetos();
            }
        }

        private void GetProjetos()
        {
            agEntities ctx = new agEntities();
            var resultado = (from a in ctx.projetoes
                             orderby a.nome
                             select new
                             {
                                 a.id,
                                 a.nome,

                             });
            GridView1.DataSource = resultado.ToList();
            GridView1.DataBind();
        }

        protected void btnVisualizar_Click(object sender, EventArgs e)
        {
            projetoID = ((sender as LinkButton).CommandArgument);
            Response.Redirect("ViewProjetos.aspx?projetoID=" + projetoID);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (Session["perfil"].ToString() != "Administrador")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "acessoNegado();", true);
            }
            else
            {
                projetoID = ((sender as LinkButton).CommandArgument);
                Response.Redirect("EditProjetos.aspx?projetoID=" + projetoID);
            }

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Session["perfil"].ToString() != "Administrador")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "acessoNegado();", true);
            }
            else
            {
                try
                {
                    int cod = Convert.ToInt32((sender as LinkButton).CommandArgument);
                    agEntities ctx = new agEntities();
                    projeto gu = ctx.projetoes.First(p => p.id == cod);
                    ctx.projetoes.Remove(gu);
                    ctx.SaveChanges();
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
                    GetProjetos();
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "erro();", true);
                    //throw;
                }
            }
        }
    }
}