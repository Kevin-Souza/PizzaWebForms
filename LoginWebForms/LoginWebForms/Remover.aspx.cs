﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWebForms
{
    public partial class Remover : System.Web.UI.Page
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
            int IDUsuario = ObterIDCliente();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"Select * from usuario where id_usu = @IDUsuario";

                cmd.Parameters.AddWithValue("@IDUsuario", IDUsuario);

                Conexao.Conectar();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtNome.Text = reader["nome"].ToString();
                    txtLogin.Text = reader["login"].ToString();
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
            Response.Redirect("Listar.aspx");
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            int idUsuario = ObterIDCliente();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"delete from usuario where id_usu = @id";

                cmd.Parameters.AddWithValue("@id", idUsuario);

                Conexao.Conectar();
                cmd.ExecuteNonQuery();

                Response.Redirect("Listar.aspx");
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
    }
}