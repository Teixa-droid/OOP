using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Teste
{
    public partial class Form1 : Form
    {
        internal Gestor g;
        Condomino c;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i<4;i++)
            {
                if(i==0)
                {
                    comboBox1.Items.Add("RC-esq");
                    comboBox1.Items.Add("RC-dto");
                }
                else
                {
                    comboBox1.Items.Add(i+"o-esq");
                    comboBox1.Items.Add(i+"o-dto");

                }
            }

            StreamReader sr = new StreamReader("dados.txt");

            string linha = sr.ReadLine();
            int l = 0;

            while(linha != null && linha != "")
            {
                string[] aux = linha.Split(';');

                if(l == 0)
                {
                    g = new Gestor(aux[0], aux[1], aux[2]);
                }
                else
                {
                    c = new Condomino(aux[0], aux[1], aux[2]);
                    listBox1.Items.Add(c);
                }

                linha = sr.ReadLine();
                l++;
            }
            sr.Close();

            label2.Text = g.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            c = listBox1.SelectedItem as Condomino;

            textBox1.Text = c.GetNome();
            textBox2.Text = c.GetEmail();
            comboBox1.SelectedItem = c.GetApartamento();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c = listBox1.SelectedItem as Condomino;

            Condomino c1 = new Condomino(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString());

            listBox1.Items.Remove(c);
            listBox1.Items.Add(c1);

            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Condomino c1 = new Condomino(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString());
            listBox1.Items.Add(c1);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("dados.txt");

            sw.WriteLine(g.Guardar());

            foreach(Condomino cx in listBox1.Items)
            {
                sw.WriteLine(cx.Guardar());
            }

            sw.Close();
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
        }
    }
}
