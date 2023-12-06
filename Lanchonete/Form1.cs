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
        public Form1(int op)
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

            usuarioDao usuarioDao = new usuarioDao();
            List<Usuario> usuarios = usuarioDao.SelectUsuario();
            try
            {
                foreach (Usuario usuario in usuarios)
                {
                    ListViewItem lv = new ListViewItem(usuario.Id.ToString());
                    lv.SubItems.Add(usuario.Nome);
                    lv.SubItems.Add(usuario.Email);
                    lv.SubItems.Add(usuario.Senha);
                    lv.SubItems.Add(usuario.Telefone);
                    lv.SubItems.Add(usuario.Cpf);

                    listView1.Items.Add(lv);

                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                try
                {
                    string telefone = maskedTextBox1.Text;
                    string cpf = maskedTextBox2.Text;
                    if (new CPFValidator().IsValid(cpf) && new Validador().ValidarTelefone(telefone))
                    {
                        MessageBox.Show("CPF válido!");
                        MessageBox.Show("telefone válido!");


                        Usuario usuario = new Usuario("nome", "email", "senha", "telefone", "cpf");
                        usuario.Nome = textBox1.Text;
                        usuario.Email = textBox2.Text;
                        usuario.Telefone = maskedTextBox1.Text;
                        usuario.Senha = Criptografia.CriptografarSenha(textBox3.Text);
                        usuario.Cpf = maskedTextBox2.Text;

                        usuarioDao usuarioDao = new usuarioDao();
                        usuarioDao.InsertUsuario(usuario);

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        maskedTextBox1.Clear();
                        maskedTextBox2.Clear();

                        UpdateListView();
                    }
                    else
                    {
                        MessageBox.Show("CPF inválido ou Telefone inválido");

                    }
                }

                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("Aceite os termos e condições");
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
            if (checkBox1.Checked)
            {
                try
                {
                    string telefone = maskedTextBox1.Text;
                    string cpf = maskedTextBox2.Text;
                    if (new CPFValidator().IsValid(cpf))
                    {
                        MessageBox.Show("CPF válido!");
                    }
                    else if (new Validador().ValidarTelefone(telefone))
                    {
                        MessageBox.Show("Telefone válido!");


                        Usuario usuario = new Usuario("nome", "email", "senha", "telefone", "cpf");
                        usuario.Nome = textBox1.Text;
                        usuario.Email = textBox2.Text;
                        usuario.Telefone = maskedTextBox1.Text;
                        usuario.Senha = Criptografia.CriptografarSenha(textBox3.Text);
                        usuario.Cpf = maskedTextBox2.Text;

                        usuarioDao usuarioDao = new usuarioDao();
                        usuarioDao.editarUsuario(usuario);

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        maskedTextBox1.Clear();
                        maskedTextBox2.Clear();

                        UpdateListView();
                    }
                    else
                    {
                        MessageBox.Show("CPF inválido ou Telefone inválido");

                    }
                }

                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("Aceite os termos e condições");
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index;
            index = listView1.FocusedItem.Index;
            Id = int.Parse(listView1.Items[index].SubItems[0].Text);
            textBox1.Text = (listView1.Items[index].SubItems[1].Text);
            textBox2.Text = listView1.Items[index].SubItems[2].Text;
            textBox3.Text = listView1.Items[index].SubItems[3].Text;
            maskedTextBox1.Text = listView1.Items[index].SubItems[4].Text;
            maskedTextBox2.Text = listView1.Items[index].SubItems[5].Text;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            usuarioDao usuarioDao = new usuarioDao();
            usuarioDao.excluirUsuario(Id);

            UpdateListView();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }
    }
}


