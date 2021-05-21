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
namespace Password
{
    public partial class Login : Form
    {
       

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:\\Users\\Lukas\\source\\repos\\Password\\Password\\bin\\Debug\\temp.txt", String.Empty);
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            using (StreamReader file = new StreamReader("C:\\Users\\Lukas\\source\\repos\\Password\\Password\\bin\\Debug\\text.txt"))
            {
                int counter = 0;
                string ln;
                while ((ln = file.ReadLine()) != null)
                {

                    using (var writer = File.AppendText("temp.txt"))
                    {

                        writer.WriteLine(Form1.AesOperation.DecryptString(key, ln));

                    }
                    counter++;
                }
            }


            using (StreamReader sr = File.OpenText("C:\\Users\\Lukas\\source\\repos\\Password\\Password\\bin\\Debug\\temp.txt"))
            {
                string[] lines = File.ReadAllLines("C:\\Users\\Lukas\\source\\repos\\Password\\Password\\bin\\Debug\\temp.txt");
                bool isMatch = false;
                for (int x = 0; x < lines.Length - 1; x++)
                {
                    if (textBox1.Text == lines[x])
                    {

                        
                        this.Hide();
                        Form1 frm = new Form1();
                        frm.Show();
                        isMatch = true;
                    }
                }
                if (!isMatch)
                {
                    
                    sr.Close();
                    MessageBox.Show("No match");
                }
            }




            /* if (File.ReadAllLines("C:\\Users\\Lukas\\source\\repos\\Password\\Password\\bin\\Debug\\temp.txt").Contains(textBox1.Text))
             {
                 File.WriteAllText("C:\\Users\\Lukas\\source\\repos\\Password\\Password\\bin\\Debug\\temp.txt", String.Empty);
                 this.Hide();
                 Form1 frm = new Form1();
                 frm.Show();
             }*/


        }
    }
}
