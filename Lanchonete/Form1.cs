using Lanchonete.Lanchonete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
        private int Id;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void UpdateListView()
        {
            listView1.Items.Clear();

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
                    int id = (int)dr["id"];
                    string name = (string)dr["Nome"];
                    string email = (string)dr["email"];
                    string senha = (string)dr["senha"];
                    string telefone = (string)dr["telefone"];
                    string cpf = (string)dr["cpf"];

                    ListViewItem lv = new ListViewItem(id.ToString());
                    lv.SubItems.Add(name);
                    lv.SubItems.Add(email);
                    lv.SubItems.Add(senha);
                    lv.SubItems.Add(telefone);
                    lv.SubItems.Add(cpf);
                   
                    listView1.Items.Add(lv);

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
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // criar objeto da classe usuario
                Usuario usuario = new Usuario(
                     textBox1.Text,
                     email.Text,
                     textBox3.Text,
                     maskedTextBox1.Text,
                     maskedTextBox2.Text);

                usuarioDao usuarioDao = new usuarioDao();
                usuarioDao.InsertUsuario(usuario);
                MessageBox.Show("Cadastrado com sucesso",

                             "CADASTRADO, BB.",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                textBox1.Clear();
                email.Clear();
                textBox3.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();

                UpdateListView();

            }

            catch (Exception error)
            {
                MessageBox.Show(error.Message);
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

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateListView();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index;
            index = listView1.FocusedItem.Index;
            Id = int.Parse(listView1.Items[index].SubItems[0].Text);
            textBox1.Text = (listView1.Items[index].SubItems[1].Text);
            email.Text = listView1.Items[index].SubItems[2].Text;
            textBox3.Text = listView1.Items[index].SubItems[3].Text;
            maskedTextBox1.Text = listView1.Items[index].SubItems[4].Text;
            maskedTextBox2.Text = listView1.Items[index].SubItems[5].Text;

            UpdateListView();


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Código para excluir
            {
                UpdateListView();
            }

        }
    }
}


