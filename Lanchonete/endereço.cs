using Lanchonete.Lanchonete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;

namespace Lanchonete
{
    public partial class endereço : Form
    {
        public endereço()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            listView1.Items.Clear();

            usuarioDao usuarioDao = new usuarioDao();
            List<Usuario> usuarios = usuarioDao.SelectUsuario1();

            try
            {
                foreach (Usuario usuario in usuarios)
                {
                    ListViewItem lv = new ListViewItem(usuario.Id.ToString());
                    lv.SubItems.Add(usuario.rua);
                    lv.SubItems.Add(usuario.Bairro);
                    lv.SubItems.Add(usuario.Numero);
                    lv.SubItems.Add(usuario.cep);

                    listView1.Items.Add(lv);

                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void endereço_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 5)
            {
                MessageBox.Show("O campo Rua deve ter pelo menos 5 caracteres.");
            }
            else if (textBox3.Text.Length < 5)
            {
                MessageBox.Show("O campo Bairro deve ter pelo menos 5 caracteres.");
            }
           else  if (textBox4.Text.Length < 3)
            {
                MessageBox.Show("O campo Rua deve ter pelo menos 3 caracteres.");
            }
            string cep = maskedTextBox1.Text;
            string url = "https://viacep.com.br/ws/" + cep + "/json/";

            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);
                dynamic result = JsonConvert.DeserializeObject(json);

                if (result.erro != null)
                {
                    MessageBox.Show("CEP não encontrado.");
                    return;
                }
            }
            try
            {
                Usuario usuario = new Usuario(
                     textBox2.Text,
                     textBox3.Text,
                     textBox4.Text,
                     maskedTextBox1.Text);

                usuarioDao usuarioDao = new usuarioDao();
                usuarioDao.InsertUsuario1(usuario);
                MessageBox.Show("Cadastrado com sucesso",

                             "CADASTRADO, BB.",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                maskedTextBox1.Clear();

                UpdateListView();

            }

            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Rua", "Bairro", "Numero","CEP");
            usuario.Id =int.Parse( textBox1.Text);
            usuario.rua = textBox2.Text;
            usuario.Bairro = textBox3.Text;
            usuario.Numero = textBox4.Text;
            usuario.cep = maskedTextBox1.Text;

            string cep = maskedTextBox1.Text;
            string url = "https://viacep.com.br/ws/" + cep + "/json/";

            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);
                dynamic result = JsonConvert.DeserializeObject(json);

                if (result.erro != null)
                {
                    MessageBox.Show("CEP não encontrado.");
                    return;
                }
            }

            usuarioDao usuarioDAO = new usuarioDao();
            usuarioDAO.editarUsuario1(usuario);
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            UpdateListView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Rua", "Bairro", "Numero", "CEP");
            usuario.Id = int.Parse(textBox1.Text);
  
            usuarioDao usuarioDAO = new usuarioDao();
            usuarioDAO.excluirUsuario1(usuario.Id);
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            UpdateListView();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int index;
            index = listView1.FocusedItem.Index;
            textBox1.Text = (listView1.Items[index].SubItems[0].Text);
            textBox2.Text = (listView1.Items[index].SubItems[1].Text);
            textBox3.Text = listView1.Items[index].SubItems[2].Text;
            textBox4.Text = listView1.Items[index].SubItems[3].Text;
            maskedTextBox1.Text = listView1.Items[index].SubItems[4].Text;
        }
    }
}
