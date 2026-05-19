using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 验车帝
{
    public partial class Form2 : Form
    {

        public TextBox textbox_1 { get => textBox1; }
        public TextBox textbox_2 { get => textBox2; }
        public string aaa;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo file = new FileInfo(textBox2.Text);
                // 重命名文件
                Console.WriteLine(file.DirectoryName + "\\" + textBox1.Text);
                File.Move(textBox2.Text, file.DirectoryName+"\\"+textBox1.Text);
                this.Close(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("文件重命名失败：" + ex.Message);
            }
        }
    }
}
