using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Quiz
{
    class User
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }
    public partial class Form1 : Form
    {
        List<User> Users = new List<User>();
        Point point;
        public Form1()
        {
            InitializeComponent();
        }
        void ResetForm()
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {


                foreach (var item in Controls)
                {
                    if (item is Button button)
                    {
                        button.Dispose();
                    }
                    if (item is TextBox textBox)
                    {
                        textBox.Dispose();
                    }

                }
            }
        }
        void createButton(string Text,bool  enable)
        {
            Button button = new Button();
            button.Size = new Size(75,23);
            button.Location = new Point(point.X, point.Y);
            button.Text = Text;
            button.Enabled = enable;
            button.Click += Button_Click;

            this.Controls.Add(button);
            
        }


        void Registr()
        {

        }
        private void Button_Click(object sender, EventArgs e)
        {
            
            Button button = sender as Button;
            if(button.Text=="Ok")
            {
                User user_ = new User();
                bool a = true;
                bool b = true;
                foreach (var item in Controls)
                {
                    if (item is TextBox textBox)
                    {
                        if (textBox.Text != string.Empty && textBox.Name == "Mail")
                        {
                            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                            string q = Users.FindAll(x => x.Mail == textBox.Text).ToString();

                            if (Regex.IsMatch(textBox.Text, pattern) && q!="0")
                            {
                                user_.Mail = textBox.Text;
                                a = false;

                            }
                        }
                        if (textBox.Text != string.Empty && textBox.Name == "Password")
                        {
                            user_.Password = textBox.Text;

                            b = false;

                        }
                    }
                }
                if (!a && !b)
                {
                    Users.Add(user_);
                    string json = JsonConvert.SerializeObject(Users);
                    if (Directory.Exists("User") )
                    {
                    System.IO.File.WriteAllText("User.json", json);
                  
                    }
                    else 
                    {

                        System.IO.File.WriteAllText("User.json", json);

                    }
                    ResetForm();
                    Login();
                }
            }
            if(button.Text== "Registr")
            {
                ResetForm();
                TextBox textBox = new TextBox();
                textBox.Location = new Point(400, 87);
                textBox.Size = new Size(400, 20);
                textBox.MouseClick += TextBox_MouseClick;
                textBox.MouseLeave += TextBox_MouseLeave;
                textBox.Text = "Enter Mail";
                textBox.Name = "Mail";
                this.Controls.Add(textBox);
                textBox.Location = new Point(400, 141);
                textBox.Size = new Size(400, 20);
                textBox.MouseClick += TextBox_MouseClick;
                textBox.MouseLeave += TextBox_MouseLeave;
                textBox.Text = "Enter Password";
                textBox.Name = "Password";
                this.Controls.Add(textBox);
                point.X = 100;
                point.Y = 60;
                createButton("Ok", true);
            }
            if (button.Text=="Sign in")
            {
                bool a = true;
                bool b = true;
                if (File.Exists("User.json"))
                {
                    string user = File.ReadAllText("User.json");
                    Users = JsonConvert.DeserializeObject<List<User>>(user);
                    foreach (var item in Controls)
                    {
                        if (item is TextBox textBox)
                        {
                            if (textBox.Text != string.Empty  )
                            {
                                string q = Users.FindAll(x => x.Mail == textBox.Text).ToString();
                                if (q!="0")
                                {
                                    a = false;

                                }
                            }
                            string t = Users.FindAll(x => x.Password == textBox.Text).ToString();
                            if (t != "0")
                            {
                                b = false;

                            }
                        }
                    }
                    if (!a && !b)
                    {
                        ResetForm();
                        ProgramLoad();
                    }
                }
            }
            if(button.Text=="Quiz")
            {
                ResetForm();
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            if (button.Text== "Create Test")
            {
                ResetForm();
                Form3 form3 = new Form3();
                form3.ShowDialog();
            }
        }
        void Login()
        {
            TextBox textBox = new TextBox();
            textBox.Location = new Point(400, 87);
            textBox.Size = new Size(400,20);
            textBox.MouseLeave += TextBox_MouseLeave;
            textBox.MouseClick += TextBox_MouseClick;

            textBox.Text = "Enter Mail";
            textBox.Name = "Mail";
            this.Controls.Add(textBox);
            TextBox textBox1 = new TextBox();
            textBox1.Location = new Point(400, 141);
            textBox1.Size = new Size(400, 20);
            textBox1.MouseClick += TextBox1_MouseClick;
            textBox1.MouseLeave += TextBox1_MouseLeave;
            textBox1.Text = "Enter Password";
            textBox1.Name = "Password";
            this.Controls.Add(textBox1);
            point.X=100;
            point.Y = 30;
            createButton("Sign in", true);
            point.X = 200;
            point.Y = 60;
            createButton("Registr", true);
        }

        private void TextBox1_MouseLeave(object sender, EventArgs e)
        {
            foreach (var item in Controls)
            {
                if (item is TextBox textBox)
                {
                   
                    if (textBox.Text == string.Empty && textBox.Name == "Password")
                    {
                        textBox.Text = "Enter Password";
                    }
                }
            }
        }

        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var item in Controls)
            {
                if (item is TextBox textBox)
                {
                    if(textBox.Name=="Password")
                    textBox.Text = string.Empty;
                }
            }
        }

        private void TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var item in Controls)
            {
                if (item is TextBox textBox)
                    if(textBox.Name=="Mail")
                    {
                        textBox.Text = string.Empty;
                }
            }
        }


        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            foreach (var item in Controls)
            {
                if (item is TextBox textBox)
                {
                   if( textBox.Text == string.Empty && textBox.Name=="Mail")
                    {
                        textBox.Text = "Enter Mail";
                    }
                   }
            }
        }
        void ProgramLoad()
        {
            point.X = 142;
            point.Y = 49;
            createButton("Create Test", true);
            point.X = 442;
            createButton("Quiz", true);

        }
        public void Form1_Load(object sender, EventArgs e)
        {
            Login();
            //ProgramLoad();
        }
        //private void Form1_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Copy;
        //}
        //private void Form1_DragDrop(object sender, DragEventArgs e)
        //{
        //    string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
        //    foreach (var item in droppedFiles)
        //    {
        //        Path = item;
        //    }
        //    FormLoad("");
        //}
    }
}