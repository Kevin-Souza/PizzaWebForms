using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWebForms
{
    public partial class AdicionarPro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"insert into pizza
                                    (sabor, bordas, tamanho)
                                    values
                                    (@sabor, @bordas, @tamanho)";

                cmd.Parameters.AddWithValue("@sabor", txtSabor.Text);
                cmd.Parameters.AddWithValue("@bordas", txtBordas.Text);
                cmd.Parameters.AddWithValue("@tamanho", ddlTamanho.Text);

                Conexao.Conectar();
                cmd.ExecuteNonQuery();
                Response.Redirect("Produto.aspx");
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Erro: {ex.Message}";
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produto.aspx");
        }
    }
}