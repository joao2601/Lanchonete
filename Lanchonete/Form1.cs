using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lanchonete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                conexao connection = new conexao();
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Connection = connection.ReturnConnection();
                sqlCommand.CommandText = @"INSERT INTO Cadastro VALUES(@Nome, @Email, @Senha, @Telefone, @Cpf)";

                sqlCommand.Parameters.AddWithValue("@Nome", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@Email", email.Text);
                sqlCommand.Parameters.AddWithValue("@Senha", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@Telefone", maskedTextBox1.Text);
                sqlCommand.Parameters.AddWithValue("@Cpf", maskedTextBox2.Text);

                sqlCommand.ExecuteNonQuery();






                MessageBox.Show ("Cadastrado com sucesso",
                    
                             "CADASTRADO, BB.",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                textBox1.Clear();
                email.Clear();   
                textBox3.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear(); 


            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
