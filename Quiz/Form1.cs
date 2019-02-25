using Newtonsoft.Json;
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
using System.Xml.Serialization;

namespace Quiz
{
    public partial class Form1 : Form
    {
        Point point;
        public Form1()
        {
            InitializeComponent();
        }
        void ResetForm()
        {
                foreach (var item in Controls)
                {
                    if (item is Button button)
                    {
                        button.Dispose();
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
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
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
            ProgramLoad();
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