using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWebForms
{
    public partial class Produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            string query = @"select id_pizza, sabor, tamanho, bordas from pizza";
            DataTable dtp = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                MySqlDataAdapter da = new MySqlDataAdapter(query, Conexao.Connection);
                da.Fill(dtp);

                rptProdutos.DataSource = dtp;
                rptProdutos.DataBind();
            }
            catch (Exception ex)
            {
                lblMsg.Text = $"Erro: {ex.Message}";
            }
            finally
            {

            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdicionarPro.aspx");
        }

        protected void rptProdutos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        //protected void rptUsuarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    string nivel = Session["Perfil"].ToString();

        //    var lnkEditar = (LinkButton)e.Item.FindControl("lnkEditar");
        //    var lnkRemover = (LinkButton)e.Item.FindControl("lnkRemover");

        //    if (lnkEditar != null && lnkRemover != null && nivel == "O")
        //    {
        //        lnkEditar.Visible = false;
        //        lnkRemover.Visible = false;
        //    }
        //}
    }
}