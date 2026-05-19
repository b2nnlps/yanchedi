using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 验车帝
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int nowRand = 180;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            int index = Form1.form1.listView1.SelectedIndices[0];
            Console.WriteLine("刷新截图:" + Form1.form1.videoArr[index, 0]);

            /* Form3 form3 = new Form3();
             form3.Show();
             form3.pictureBox1.Image = Image.FromFile(videoArr[index, 1]);*/

            Random ran = new Random();
            int n = ran.Next(1200)+ nowRand;
            nowRand = nowRand + 180;

            pictureBox1.Image.Dispose();
            if (textBox1.Text.Length > 0)
                n = int.Parse(textBox1.Text);
            Form1.form1.ExtractSnapshot(Form1.form1.videoArr[index, 0], Form1.form1.videoArr[index, 1], TimeSpan.FromSeconds(n));// 重新截图

            Image img = Image.FromFile(Form1.form1.videoArr[index, 1]);
           
            pictureBox1.Image = img;
            button1.Enabled = true;

            /* Form1.form1.radioButton1_CheckedChanged(sender, EventArgs.Empty);
             Form1.form1.radioButton2_CheckedChanged(sender, EventArgs.Empty);
             Form1.form1.radioButton3_CheckedChanged(sender, EventArgs.Empty);*/
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int index = Form1.form1.listView1.SelectedIndices[0];
            Image img = Image.FromFile(Form1.form1.videoArr[index, 1]);
            pictureBox1.Image = img;
        }
    }
}
