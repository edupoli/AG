using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AG
{
    public partial class AGs : System.Web.UI.Page
    {
        int agID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getAGs();
            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (Session["perfil"].ToString() != "administrador")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "acessoNegado();", true);
            }
            else
            {
                try
                {
                    agID = Convert.ToInt32((sender as LinkButton).CommandArgument);
                    Response.Redirect("EditAG.aspx?agID=" + agID);
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Session["perfil"].ToString() != "administrador")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "acessoNegado();", true);
            }
            else
            {
                try
                {
                    agID = Convert.ToInt32((sender as LinkButton).CommandArgument);
                    agEntities ctx = new agEntities();
                    ag gr = ctx.ags.First(p => p.id == agID);
                    ctx.ags.Remove(gr);
                    ctx.SaveChanges();
                    getAGs();
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "erro();", true);
                    //throw;
                }
            }

        }
        private void getAGs()
        {
            agEntities ctx = new agEntities();
            var resultado = (from a in ctx.ags
                             join b in ctx.projetoes on a.projetoID equals b.id
                             select new
                             {
                                 a.id,
                                 a.numero,
                                 b.nome,
                             });
            GridView1.DataSource = resultado.ToList();
            GridView1.DataBind();
        }

        protected void btnVisualizar_Click(object sender, EventArgs e)
        {
            agID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Response.Redirect("ViewAGs.aspx?agID=" + agID);
        }
    }
}