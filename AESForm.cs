using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace _2_Praktinis
{
    public partial class AESForm : Form

    {
        public AESForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            var key = textBox_slaptasis.Text;
            var str = textBox_encrypt.Text;

            if (textBox_encrypt.Text != "")
            {
                if (comboBox_modes.SelectedItem != null)
                {
                    if (textBox_slaptasis.Text != "")
                    {
                        var selection = comboBox_modes.SelectedItem.ToString();
                        var encryptedString = AES.EncryptString(key, str, selection);
                        textBox_decrypt.Text = encryptedString.ToString();
                    }
                    else
                        MessageBox.Show("Neįvestas slaptasis raktas");
                }
                else
                    MessageBox.Show("Nepasirinktas modas");
            }
            else
                MessageBox.Show("Neįvestas tekstas.");

        }
         
        private void button2_Click(object sender, EventArgs e)
        {
            var key = textBox_slaptasis.Text;
            var str = textBox_encrypt.Text;

            if (textBox_encrypt.Text != "")
            {
                if (comboBox_modes.SelectedItem != null)
                {
                    if (textBox_slaptasis.Text != "")
                    {
                        var selection = comboBox_modes.SelectedItem.ToString();
                        var decryptedString = AES.DecryptString(key, str, selection);
                        textBox_decrypt.Text = decryptedString.ToString();
                    }
                    else
                        MessageBox.Show("Neįvestas slaptasis raktas");
                }
                else
                    MessageBox.Show("Nepasirinktas modas");
            }
            else
                MessageBox.Show("Neįvestas tekstas.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save1 = new SaveFileDialog();
            if(save1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(save1.FileName, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(textBox_decrypt.Text);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(dlg.FileName, Encoding.Default);
                textBox_encrypt.Text = reader.ReadToEnd();
                reader.Close();
            }
            dlg.Dispose();

        }
    }

}
