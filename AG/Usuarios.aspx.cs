using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AG
{
    public partial class Usuarios : System.Web.UI.Page
    {
        int usuarioID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getUsuarios();
            }
        }

        protected void btnVisualizar_Click(object sender, EventArgs e)
        {
            usuarioID = int.Parse((sender as LinkButton).CommandArgument);
            Response.Redirect("ViewUsuarios.aspx?usuarioID=" + usuarioID);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (Session["perfil"].ToString() == "Operador")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "acessoNegado();", true);
            }
            if (Session["perfil"].ToString() == "Administrador")
            {
                usuarioID = int.Parse((sender as LinkButton).CommandArgument);
                Response.Redirect("EditUsuarios.aspx?usuarioID=" + usuarioID);
            }
            if (Session["perfil"].ToString() == "Supervisor")
            {
                usuarioID = int.Parse((sender as LinkButton).CommandArgument);
                Response.Redirect("EditUsuariosSup.aspx?usuarioID=" + usuarioID);
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
                    usuarioID = int.Parse((sender as LinkButton).CommandArgument);
                    agEntities ctx = new agEntities();
                    usuario user = ctx.usuarios.First(p => p.id == usuarioID);
                    ctx.usuarios.Remove(user);
                    ctx.SaveChanges();
                    getUsuarios();
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "erro();", true);
                    //throw;
                }
            }


        }
        private void getUsuarios()
        {
            agEntities ctx = new agEntities();
            var resultado = (from a in ctx.usuarios orderby a.nome ascending
                             join b in ctx.projetoes on a.projetoID equals b.id
                             select new
                             {
                                 a.id,
                                 a.nome,
                                 a.emaill,
                                 a.login,
                                 a.senha,
                                 a.perfil,
                                 projeto = b.nome,
                                 a.img,

                             });
            GridView1.DataSource = resultado.ToList();
            GridView1.DataBind();
        }
    }
}