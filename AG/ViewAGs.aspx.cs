using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AG
{
    public partial class ViewAGs : System.Web.UI.Page
    {
        string agID;
        public string mensagem = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            agID = Request.QueryString["agID"];
            if (!Page.IsPostBack)
            {
                buscaAG(int.Parse(agID));
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AGs.aspx"); 
        }
        private void buscaAG(int cod)
        {
            agEntities ctx = new agEntities();
            ag gr = ctx.ags.First(p => p.id == cod);
            numeroAG.Text = gr.numero;
            string op = Convert.ToString(gr.projetoID);
            int pr = int.Parse(op);
            projeto oo = ctx.projetoes.First(p => p.id == pr);
            string du = oo.nome;
            cboxProjeto.Items.Insert(0, new ListItem(du, "1"));
        }
    }
}