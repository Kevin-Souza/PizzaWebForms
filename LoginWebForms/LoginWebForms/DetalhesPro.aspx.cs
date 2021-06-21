using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWebForms
{
    public partial class DetalhesPro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CapturaID())
            {
                DadosConsulta();
            }
        }

        private bool CapturaID()
        {
            return Request.QueryString.AllKeys.Contains("id");
        }

        private void DadosConsulta()
        {
            int IDPizza = ObterIDCliente();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"Select * from pizza where id_pizza = @IDPizza";

                cmd.Parameters.AddWithValue("@IDpizza", IDPizza);

                Conexao.Conectar();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtSabor.Text = reader["sabor"].ToString();
                    txtBordas.Text = reader["bordas"].ToString();
                    ddlTamanho.Text = reader["tamanho"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        #region

        private int ObterIDCliente()
        {
            int id = 0;
            var idURL = Request.QueryString["id"];
            if (!int.TryParse(idURL, out id))
            {
                throw new Exception("ID Inválido");
            }
            if (id <= 0)
            {
                throw new Exception("ID Inválido");
            }
            return id;
        }
        #endregion
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produto.aspx");
        }
    }
}