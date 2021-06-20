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
    public partial class editar : System.Web.UI.Page
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
                cmd.CommandText = @"select * from usuario
                                   where id = @IDCliente";

                cmd.Parameters.AddWithValue("@IDCliente", IdCliente);

                Conexao.Conectar();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtNome.Text = reader["nome"].ToString();
                    txtLogin.Text = reader["login"].ToString();
                    txtSenha.Text = reader[""].ToString();
                    ddlNivel.Text = reader["nivel"].ToString();
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
                cmd.CommandText = @"update usuario
                                    set nome        =@nome,
                                        login       =@login,
                                        senha       =@senha,
                                        nivel       =@nivel
                                    where id   =@id";

                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@login", txtLogin.Text);
                cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                cmd.Parameters.AddWithValue("@nivel", ddlNivel.Text);

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