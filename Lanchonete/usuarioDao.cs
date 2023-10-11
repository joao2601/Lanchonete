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
        public List<Usuario> SelectUsuario()
        {
            conexao conn = new conexao();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Cadastro";

            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    Usuario objeto = new Usuario(
                    (int)   dr["id"],
                    (string)dr["Nome"],
                    (string)dr["Email"],
                    (string)dr["Senha"],
                    (string)dr["Telefone"],
                    (string)dr["Cpf"]
                    );

                }
                dr.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
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
               Nome = @textBox1.Text,
               Email = @email.Text,
               Senha = @textBox3.Text,
               Telefone = @maskedTextBox1.Text,
               Cpf = @maskedTextBox2.Text
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

        public void excluirUsuario(Usuario usuario)
        {
            conexao connection = new conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM Cadastro SET 
            
               Nome = @textBox1.Text,
               Email = @email.Text,
               Senha = @textBox3.Text,
               Telefone = @maskedTextBox1.Text,
               Cpf = @maskedTextBox2.Text
               WHERE Id = @Id";

            sqlCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@Email", usuario.Email);
            sqlCommand.Parameters.AddWithValue("@Senha", usuario.Senha);
            sqlCommand.Parameters.AddWithValue("@Telefone", usuario.Telefone);
            sqlCommand.Parameters.AddWithValue("@Cpf", usuario.Cpf);
            sqlCommand.Parameters.AddWithValue("@Id", usuario.Id);

            sqlCommand.ExecuteNonQuery();

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
