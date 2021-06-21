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
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");

            if (!Page.IsPostBack)
            {
                if (CapturaID())
                {
                    DadosConsulta();
                }
            }
        }

        #region CapturaID

        private bool CapturaID()
        {
            return Request.QueryString.AllKeys.Contains("id");
        }

        #endregion

        #region Dados Consulta

        private void DadosConsulta()
        {
            var IdCliente = ObterIDCliente();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select * from pizza
                                    where id_pizza = @IDCliente";

                cmd.Parameters.AddWithValue("@IDCliente", IdCliente);

                Conexao.Conectar();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtSabor.Text = reader["sabor"].ToString();
                    txtBordas.Text = reader["bordas"].ToString();
                    ddlTamanho.Text = reader["tamanho"].ToString();
                    txtPreco.Text = reader["preco"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
        # endregion

        #region Obter ID Cliente

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
            Response.Redirect("Listar.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"update pizza
                                    set sabor       =@sabor,
                                        tamanho     =@tamanho,
                                        bordas      =@bordas,
                                        preco       =@preco,
                                    where id_pizza  =@id_pizza";

                cmd.Parameters.AddWithValue("@sabor", txtSabor.Text);
                cmd.Parameters.AddWithValue("@tamanho", txtBordas.Text);
                cmd.Parameters.AddWithValue("@bordas", ddlTamanho.Text);
                cmd.Parameters.AddWithValue("@preco", txtPreco.Text);

                Conexao.Conectar();
                cmd.ExecuteNonQuery();
                Response.Redirect("Listar.aspx");
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