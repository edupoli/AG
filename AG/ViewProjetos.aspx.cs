using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AG
{
    public partial class ViewProjetos : System.Web.UI.Page
    {
        string projetoID;
        protected void Page_Load(object sender, EventArgs e)
        {
            projetoID = Request.QueryString["projetoID"];
            if (!Page.IsPostBack)
            {
                getProjetos(int.Parse(projetoID));
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Projetos.aspx");
        }
        private void getProjetos(int cod)
        {
            agEntities ctx = new agEntities();
            projeto gu = ctx.projetoes.First(p => p.id == cod);
            nome.Text = gu.nome;
        }
    }
}