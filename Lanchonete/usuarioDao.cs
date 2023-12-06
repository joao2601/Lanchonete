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
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;

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
                    (string)dr["CPF"]
                    );
                    usuarios.Add(objeto);

                }
                dr.Close();
            }
            catch (Exception err)
            {
                throw new Exception("Erro na leitura dos dados\n"
                    + err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return usuarios;
        }
        public List<Usuario> SelectUsuario1()
        {
            conexao conn = new conexao();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Endereco";
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    Usuario objeto = new Usuario(
                    (int)dr["id"],
                    (string)dr["Rua"],
                    (string)dr["Bairro"],
                    (string)dr["Numero"],
                    (string)dr["CEP"]
                    );
                    usuarios.Add(objeto);

                }
                dr.Close();
            }
            catch (Exception err)
            {
                throw new Exception("Erro na leitura dos dados\n"
                    + err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return usuarios;
        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        public void InsertUsuario(Usuario usuario)
        {
            string email = usuario.Email;
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

            if (IsValidEmail(email) == true)
            {
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Criado Com Sucesso Seu Cadastro",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Email invalido",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }

        }
        public void InsertUsuario1(Usuario usuario)
        {
            conexao connection = new conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Endereco VALUES(@Rua, @Bairro, @Numero, @CEP)";

            sqlCommand.Parameters.AddWithValue("@Rua", usuario.rua);
            sqlCommand.Parameters.AddWithValue("@Bairro", usuario.Bairro);
            sqlCommand.Parameters.AddWithValue("@Numero", usuario.Numero);
            sqlCommand.Parameters.AddWithValue("@CEP", usuario.cep);
            sqlCommand.Parameters.AddWithValue("@Id", usuario.Id);

            sqlCommand.ExecuteNonQuery();

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
               WHERE Id = @Id";
            sqlCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@Email", usuario.Email);
            sqlCommand.Parameters.AddWithValue("@Senha", usuario.Senha);
            sqlCommand.Parameters.AddWithValue("@Telefone", usuario.Telefone);
            sqlCommand.Parameters.AddWithValue("@Cpf", usuario.Cpf);
            sqlCommand.Parameters.AddWithValue("@Id", usuario.Id);


            sqlCommand.ExecuteNonQuery();

        }
        public void editarUsuario1(Usuario usuario)
        {
            conexao connection = new conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE Endereco SET
               Rua = @Rua,
               Bairro = @Bairro,
               Numero = @Numero,
               CEP = @CEP
               WHERE Id = @Id";
            sqlCommand.Parameters.AddWithValue("@Rua", usuario.rua);
            sqlCommand.Parameters.AddWithValue("@Bairro", usuario.Bairro);
            sqlCommand.Parameters.AddWithValue("@Numero", usuario.Numero);
            sqlCommand.Parameters.AddWithValue("@CEP", usuario.cep);
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

            sqlCommand.Parameters.AddWithValue("@Id", Id);


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
        public void excluirUsuario1(int Id)
        {
            conexao connection = new conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM Endereco 
               WHERE Id = @Id";

            sqlCommand.Parameters.AddWithValue("@Id", Id);


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
        public void loginUsuario(Usuario usuario)
        {


            // Conexão com o banco de dados
           conexao connect = new conexao();
            SqlConnection connection = connect.ReturnConnection();

            // Consulta SQL para verificar se o usuário existe
            string query = "SELECT ID FROM Cadastro WHERE Email=@email AND Senha=@Senha";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", usuario.Email);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            int userId = Convert.ToInt32(command.ExecuteScalar());

            if (userId > 0)
            {
                MessageBox.Show("Login feito com sucesso");
                principal principal = new principal(userId);
                principal.Show();
            }
            else
            {
                MessageBox.Show("Erro ao fazer login");
            }

            connect.CloseConnection();
        }
    }
}

