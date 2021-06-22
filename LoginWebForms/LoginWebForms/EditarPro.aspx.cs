using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWebForms
{
    public partial class EditarPro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (CapturaID())
                {
                    DadosConsulta();
                }
            }
        }

        private bool CapturaID()
        {
            return Request.QueryString.AllKeys.Contains("id");
        }

        private void DadosConsulta()
        {
            int IDCliente = ObterIDCliente();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"Select * from pizza 
                                    where id_pizza = @IDCliente";

                cmd.Parameters.AddWithValue("@IDCliente", IDCliente);

                Conexao.Conectar();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtID.Text = reader["id_pizza"].ToString();
                    txtSabor.Text = reader["sabor"].ToString();
                    txtBordas.Text = reader["bordas"].ToString();
                    ddlTamanho.Text = reader["tamanho"].ToString();
                    txtPreco.Text = reader["preco"].ToString();
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"update pizza
                                        set sabor       = @sabor,
                                            tamanho     = @tamanho,
                                            bordas      = @bordas,
                                            preco       = @preco
                                        where id_pizza    = @id";

                cmd.Parameters.AddWithValue("@id", txtID.Text);
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
                lblResultado.Text = $"Error: {ex.Message}";
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}