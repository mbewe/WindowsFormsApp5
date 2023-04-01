using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //obsługa plików
using System.Security.Cryptography;
using System.Configuration;



namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //read file button
        {
            //https://docs.microsoft.com/pl-pl/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-6.0
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                label3.Text = openFileDialog1.FileName; 

                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //koduj algorytmem 1
        {
            textBox2.Text = algorytm1(textBox1, 'a', '@');
            textBox2.Text = algorytm1(textBox2, 'l', '$');
            textBox2.Text = algorytm1(textBox2, 'o', '#');
            textBox2.Text = algorytm1(textBox2, 'r', '*');
            textBox2.Text = algorytm1(textBox2, 'l', '^');
            textBox2.Text = algorytm1(textBox2, 's', '&');
            textBox2.Text = algorytm1(textBox2, 'm', '!');
        }

        private void button3_Click(object sender, EventArgs e) //zapisz do pilku
        {
            //https://docs.microsoft.com/pl-pl/dotnet/api/system.windows.forms.savefiledialog?view=windowsdesktop-6.0
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);
                label4.Text = saveFileDialog1.FileName;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//koduj algorytmem 2
        {
            textBox2.Text = textBox1.Text;
            byte[] bajty = Encoding.UTF8.GetBytes(textBox2.Text);
            textBox2.Text = Convert.ToBase64String(bajty);


        }

        private void button5_Click(object sender, EventArgs e)//dekoduj algorytm 1 
        {
            textBox2.Text = algorytm1(textBox1, '@', 'a');
            textBox2.Text = algorytm1(textBox2, '$', 'l');
            textBox2.Text = algorytm1(textBox2, '#', 'o');
            textBox2.Text = algorytm1(textBox2, '*', 'r');
            textBox2.Text = algorytm1(textBox2, '^', 'l');
            textBox2.Text = algorytm1(textBox2, '&', 's');
            textBox2.Text = algorytm1(textBox2, '!', 'm');

        }

        private void button6_Click(object sender, EventArgs e)//dekoduj algorytm 2 
        {
            textBox2.Text = textBox1.Text;
            byte[] bajty = Convert.FromBase64String(textBox2.Text);
            textBox2.Text = Encoding.UTF8.GetString(bajty);

        }

       

        static string algorytm1(TextBox textBox1, char encodedCharacter, char codeSign)
        {
            string content = textBox1.Text;
            char[] signs = content.ToCharArray();
            for (int i = 0; i < signs.Length; i++)
            {
                if (signs[i] == encodedCharacter)
                {
                    signs[i] = codeSign;
                }
            }
            return new string(signs);

        }
       
    }
}
