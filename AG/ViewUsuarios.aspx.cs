using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AG
{
    public partial class ViewUsuarios : System.Web.UI.Page
    {
        int usuarioID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                usuarioID = Convert.ToInt32(Request.QueryString["usuarioID"]);
                getUsuarios(usuarioID);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }
        private void getUsuarios(int cod)
        {
            agEntities ctx = new agEntities();
            usuario user = ctx.usuarios.First(p => p.id == cod);
            nome.Text = user.nome;
            email.Text = user.emaill;
            login.Text = user.login;
            senha.Text = user.senha;
            cboxPerfil.SelectedValue = user.perfil;
            cargo.Text = user.cargo;
            projeto gr = ctx.projetoes.First(p => p.id == user.projetoID);
            string gru = gr.nome;
            cboxProjeto.Items.Insert(0, new ListItem(gru, "1"));
            imgSel.ImageUrl = "dist/img/users/" + user.img;
        }
    }
}