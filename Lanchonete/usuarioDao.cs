using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Lanchonete.Lanchonete;
using System.Security.Cryptography.X509Certificates;

namespace Lanchonete
{
    internal class usuarioDao
    {
        public bool Login (string usuario, string senha)
        {
            conexao conn = new conexao();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Cadastro";
        
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                if  (dr.HasRows)
                    {
                       dr.Close();
                    return true;
                    }
              
                dr.Close();
              
            }
            catch (Exception err)
            {
                throw new Exception("Erro na leitura dos dados\n"
                    + err.Message);
                // MessageBox.Show(err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return false;
        }
        public List<Usuario> SelectUsuario()
        {
            conexao conn = new conexao();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Cadastro";
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    Usuario objeto = new Usuario(
                    (int)dr["id"],
                    (string)dr["Nome"],
                    (string)dr["Email"],
                    (string)dr["Senha"],
                    (string)dr["Telefone"],
                    (string)dr["Cpf"]
                    );
                    usuarios.Add(objeto);

                }
                dr.Close();
            }
            catch (Exception err)
            {
                throw new Exception("Erro na leitura dos dados\n"
                    + err.Message);
                // MessageBox.Show(err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return usuarios;
        }
        public void InsertUsuario(Usuario usuario)
        {
            conexao connection = new conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Cadastro VALUES(@Nome, @Email, @Senha, @Telefone, @Cpf)";

            sqlCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@Email", usuario.Email);
            sqlCommand.Parameters.AddWithValue("@Senha", usuario.Senha);
            sqlCommand.Parameters.AddWithValue("@Telefone", usuario.Telefone);
            sqlCommand.Parameters.AddWithValue("@Cpf", usuario.Cpf);
            sqlCommand.Parameters.AddWithValue("@Id", usuario.Id);

            sqlCommand.ExecuteNonQuery();

        }

        private void UpdateListView()
        {
            throw new NotImplementedException();
        }

        public void editarUsuario(Usuario usuario)
        {
            conexao connection = new conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE  Cadastro SET
               Nome = @Nome,
               Email = @Email,
               Senha = @Senha,
               Telefone = @Telefone,
               Cpf = @Cpf
               WHERE Id = @Id"
            ;


            sqlCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@Email", usuario.Email);
            sqlCommand.Parameters.AddWithValue("@Senha", usuario.Senha);
            sqlCommand.Parameters.AddWithValue("@Telefone", usuario.Telefone);
            sqlCommand.Parameters.AddWithValue("@Cpf", usuario.Cpf);
            sqlCommand.Parameters.AddWithValue("@Id", usuario.Id);


            sqlCommand.ExecuteNonQuery();

        }

        public void excluirUsuario(int Id)
        {
            conexao connection = new conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM Cadastro 
               WHERE Id = @Id";

            sqlCommand.Parameters.AddWithValue("@Id",Id);


            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir usuário no banco.\n" + err.Message);
            }
            finally
            {
                connection.CloseConnection();

            }


        }
    }
}
