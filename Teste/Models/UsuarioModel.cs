using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Teste.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login, string senha)
        {

            var ret = false;
            
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = @"Data Source=DESKTOP-7SVS4U8\SQLEXPRESS; Initial Catalog=login; User Id=admin; Passaword=123";
                conexao.Open();
                using (var comando = new SqlConnection())
                {
                    comando.Connection = conexao;
                    comando.ComandText = string.Format(
                        "select count(*) from usuario where login= '{0}' and senha'{1}'", login, senha);
                    ret = ((int)comando.ExecuteScalar() > 0);
                }
            }
            return ret;
        }
    }
}