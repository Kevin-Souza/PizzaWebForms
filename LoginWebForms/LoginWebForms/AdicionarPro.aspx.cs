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
            {
                var mensagem = string.Empty;
                if (this.uplImg. HasFile)
                {
                    this.uplImg.SaveAs(Server.MapPath("ImgPizzas/" + uplImg.FileName));
                    mensagem = "Imagem gravada com sucesso!";
                }
                else
                    mensagem = "Selecione uma imagem!";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert(' " + mensagem + "')", true);
            }

            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"insert into pizza
                                    (sabor, bordas, tamanho, preco)
                                    values
                                    (@sabor, @bordas, @tamanho, @preco)";

                cmd.Parameters.AddWithValue("@sabor", txtSabor.Text);
                cmd.Parameters.AddWithValue("@bordas", txtBordas.Text);
                cmd.Parameters.AddWithValue("@tamanho", ddlTamanho.Text);
                cmd.Parameters.AddWithValue("@preco", txtPreco.Text);

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