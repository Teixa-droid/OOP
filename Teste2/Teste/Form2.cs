using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste
{
    public partial class Form2 : Form
    {
        Form1 f;
        public Form2(Form1 f)
        {
            InitializeComponent();

            textBox1.Text = f.g.GetNome();
            textBox2.Text = f.g.GetEmail();
            textBox3.Text = f.g.GetNib();

            this.f = f;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f.g.SetNome(textBox1.Text);
            f.g.SetEmail(textBox2.Text);
            f.g.SetNib(textBox3.Text);
            f.label2.Text = f.g.ToString();
            this.Close();
        }
    }
}
