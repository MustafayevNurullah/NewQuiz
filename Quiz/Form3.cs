using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        #region List
        string Path;
        List<int> Ansvercounter = new List<int>();
        List<string> RadiobuttunList = new List<string>();
        List<string> Asci = new List<string>() {
"A",
"B",
"C",
"D",
"E",
"F",
"G",
"H",
"I",
"J",
"K",
"L",
"M",
"N",
"O",
"P",
"Q",
"R",
"S",
"T",
"U",
"V",
"W",
"X",
"Y",
"Z" };
        List<QuestionBlock> questionBlock = new List<QuestionBlock>();
        List<QuestionBlock> questionBlocks = new List<QuestionBlock>();
        List<Class1Q> questionBlocks_ = new List<Class1Q>();
        List<int> vsQuestion = new List<int>();
        List<int> vsAnswer = new List<int>();
        List<int> RandomQuestion = new List<int>();
        List<int> RandomAnswer = new List<int>();
        int createQuestionCounter = -1;
        int a = 0;
        int AsciCounter = 0;
        int counter;
        Point point = new Point();
        List<string> List = new List<string>();
        int radiobuttonconter = 0;
        #endregion List
        void ReadList()
        {
            string CorrectName = ControlRadioButton();
            if (createQuestionCounter == questionBlock.Count)
            {

                QuestionBlock questionBloc = new QuestionBlock();
                questionBloc.id = questionBlock.Count;
                questionBloc.Text = WriteTextBox("Test");
                questionBloc.Answers = new List<Answer>();
                for (int i = 0; i < AsciCounter; i++)
                {
                    Answer answer = new Answer();
                    answer.id = i;
                    answer.Text = WriteTextBoxAnswer($"{i}");
                    questionBloc.Answers.Add(answer);
                  if(CorrectName==i.ToString())
                    {
                        answer.IsCorrect = "Yes";
                    }
                    else
                    {
                        answer.IsCorrect = "No";

                    }
                }
                questionBlock.Add(questionBloc);
            }
            else
            {
               
             //   if (questionBlock[createQuestionCounter].Answers.Count < AsciCounter)
              //  {
                    QuestionBlock questionBloc = new QuestionBlock();
                    questionBloc.id = questionBlock.Count;
                    questionBloc.Text = WriteTextBox("Test");
                    questionBloc.Answers = new List<Answer>();
                    for (int i = 0; i < AsciCounter; i++)
                    {
                        Answer answer = new Answer();
                        answer.id = i;
                        answer.Text = WriteTextBoxAnswer($"{i}");
                        questionBloc.Answers.Add(answer);
                        if (CorrectName == i.ToString())
                        {
                            answer.IsCorrect = "Yes";
                        }
                        else
                        {
                            answer.IsCorrect = "No";

                        }
                    }
                questionBlock[createQuestionCounter] = questionBloc;
          //      }
                //if (questionBlock[createQuestionCounter].Answers.Count > AsciCounter)
                //{
                //    QuestionBlock questionBloc = new QuestionBlock();
                //    questionBloc.id = questionBlock.Count;
                //    questionBloc.Text = WriteTextBox("Test");
                //    questionBloc.Answers = new List<Answer>();
                //    for (int i = 0; i < AsciCounter; i++)
                //    {
                //        Answer answer = new Answer();
                //        answer.id = i;
                //        answer.Text = WriteTextBoxAnswer($"{i}");
                //        questionBloc.Answers.Add(answer);
                //        if (CorrectName == i.ToString())
                //        {
                //            answer.IsCorrect = "Yes";
                //        }
                //        else
                //        {
                //            answer.IsCorrect = "No";

                //        }
                //    }
                //    questionBlock[createQuestionCounter] = questionBloc;
                //}
            }
            //foreach (var item in questionBlock[createQuestionCounter].Answers)
            //{
            //    MessageBox.Show(item.Text);
            //}

        }
            string WriteTextBox(string number)
        {
            for (int i = 0; i < Controls.Count * 6; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is TextBox textBox)
                    {
                        if (textBox.Name == number)
                        {
                            return textBox.Text;
                        }

                    }
                }
            }
            return string.Empty;

        }
        string WriteTextBoxAnswer(string number)
        {
            //MessageBox.Show("Number"+number);
            for (int i = 0; i < Controls.Count * 6; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is TextBox textBox)
                    {
                        // MessageBox.Show("Texbox NAme"+textBox.Name);
                        if (textBox.Name == number && textBox.Location.Y > 70)
                        {
                            return textBox.Text;
                        }

                    }
                }
            }
            return string.Empty;

        }
        #region CreateControls
        void PictureBox(string text)
        {
            PictureBox radioButton = new PictureBox();
            radioButton.Size = new Size(20, 20);
            radioButton.Location = new Point(180, point.Y - 13);
            radioButton.Name = Name;
            if (text == "Yes")
            {
                radioButton.Image = System.Drawing.Image.FromFile("Correct.png");
            }
            if (text == "No")
            {
                radioButton.Image = System.Drawing.Image.FromFile("Wrong.png");
            }
            if (text == "")
            {
                radioButton.Location = new Point(180, point.Y - 30);

                radioButton.Image = System.Drawing.Image.FromFile("Answer.png");

            }

            this.Controls.Add(radioButton);
           // radioButton.Click += RadioButton_Click;
        }
        void ResetRadiButton()
        {
            for (int i = 0; i < Controls.Count * 6; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is RadioButton label)
                    {
                        //  MessageBox.Show(AsciCounter.ToString());
                        if (label.Name == AsciCounter.ToString())
                        {
                            label.Dispose();
                            //  AsciCounter--;
                        }
                    }

                }
            }

        }
        void ResetAnswerTextBox()
        {
            for (int i = 0; i < Controls.Count * 6; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is TextBox label)
                    {

                        //MessageBox.Show(AsciCounter.ToString());
                        if (point.Y == 36)
                        {
                            label.Dispose();
                        }
                        if (label.Location.Y > 100 && label.Name == AsciCounter.ToString())
                        {
                            label.Dispose();
                            ResetRadiButton();
                            //AsciCounter--;
                        }
                    }
                    if (item is Label _label)
                    {

                        //MessageBox.Show(AsciCounter.ToString());
                        
                        if (_label.Location.Y > 100 && _label.Name == AsciCounter.ToString())
                        {
                            _label.Dispose();
                            //AsciCounter--;
                        }
                    }
                }
            }

        }
        void ResetForm()
        {
            AsciCounter = 0;
            for (int i = 0; i < Controls.Count * 10; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is ListView listView)
                    {
                        listView.Dispose();
                    }
                    if (item is TextBox label)
                    {
                        label.Dispose();
                    }
                    if (item is Button button)
                    {
                        button.Dispose();
                    }
                    if (item is RadioButton radioButton)
                    {
                        radioButton.Dispose();
                    }
                    if(item is Label label_ )
                    {
                        label_.Dispose();
                    }
                }
            }
        }
        void CreateTextLabel(string Text, string Name, bool bool_)
        {
            TextBox label = new TextBox();
            label.Size = new Size(571, 81);
            label.Location = new Point(197, point.Y);
            label.Name = "Test";
            label.Enabled = bool_;
            label.Text = Text;
            label.ScrollBars = ScrollBars.Horizontal;
            this.Controls.Add(label);
        }
        void CreateAnswerLabel(string Text, bool bool_)
        {
            TextBox label = new TextBox();
            label.Size = new Size(464, 44);
            label.Location = new Point(200, point.Y);
            //  MessageBox.Show(AsciCounter.ToString());
            label.Enabled = bool_;
            label.Name = AsciCounter.ToString();
            label.Text =  Text;
            this.Controls.Add(label);
        }
        void _CreateanswerLabel(string Name)
        {
            Label label = new Label();
            label.Size = new Size(15, 15);
            label.Text = Asci[AsciCounter];
            label.Name = AsciCounter.ToString();
            label.Location = new Point(180, point.Y - 13);

            this.Controls.Add(label);
        }
        void _CreateTextLabel(string Name)
        {
            
            Label label = new Label();
            label.Size = new Size(40, 25);
            label.Text = counter.ToString();
            label.Name = AsciCounter.ToString();
            label.Location = new Point(180, point.Y+2);
            this.Controls.Add(label);
        }
        void createButton(string Text, bool enable)
        {
            Button button = new Button();
            button.Size = new Size(75, 23);
            button.Location = new Point(point.X, point.Y);
            button.Text = Text;
            button.Enabled = enable;
            this.Controls.Add(button);
            button.Click += Button_Click;
        }
        void createRadioButton(string Name)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.Size = new Size(15, 15);
            radioButton.Location = new Point(160, point.Y - 13);
            radioButton.Name = Name;
            this.Controls.Add(radioButton);
           radioButton.Click += RadioButton_Click;
            if(createQuestionCounter<questionBlock.Count)
            {
                if(questionBlock[createQuestionCounter].Answers[Convert.ToInt32(Name)].IsCorrect=="Yes")
                {
                    radioButton.Checked = true;
                }
            }
        }
        void createTextBoxSum(string Text)
        {
            TextBox label = new TextBox();
            label.Size = new Size(464, 44);
            label.Location = new Point(200, point.Y);
            label.Text = Text;
            this.Controls.Add(label);
        }
        #endregion Create
        #region ControlsClick
        void ButonEnableTrue()
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                   
                    if (item is Button Button)
                    {
                        if (Button.Text == "Remove")
                        {
                            if (ControlRadioButton() != string.Empty)
                            {
                                Button.Enabled = true;
                            }
                        }
                        if (AsciCounter >= 2 && Button.Text == "Save")
                        {
                            if (ControlRadioButton()!=string.Empty)
                            {
                                Button.Enabled = true;
                            }
                        }
                        if (point.Y == 36 && Button.Text == "Add")
                        {
                            Button.Enabled = true;
                        }
                        if (AsciCounter >= 2 && Button.Text == "AddPage")
                        {
                            if (ControlRadioButton() != string.Empty)
                            {
                                Button.Enabled = true;
                            }
                        }
                        if (AsciCounter >= 2 && Button.Text == "Next")
                        {
                            if (ControlRadioButton() != string.Empty)
                            {
                                if (createQuestionCounter != questionBlock.Count)
                                {
                                    Button.Enabled = true;
                                }
                            }
                        }
                        if (AsciCounter >= 2 && Button.Text == "Back")
                        {

                            if (ControlRadioButton() != string.Empty)
                            {
                                if (questionBlock.Count != 0)
                                {
                                    Button.Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        void ButtonEnable()
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is Button Button)
                    {
                        if (AsciCounter <= 2 && Button.Text == "Save")
                        {
                            Button.Enabled = false;
                        }
                        if (AsciCounter <= 2 && Button.Text == "AddPage")
                        {
                            Button.Enabled = false;
                        }

                        if (AsciCounter==0  &&   Button.Text == "Remove")
                        {
                            Button.Enabled = false;
                        }


                    }
                }
            }
        }
        string ControlRadioButton()
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is RadioButton radioButton)
                    {
                        if (radioButton.Checked == true)
                        {
                            return radioButton.Name;
                        }
                    }
                }
            }
            return string.Empty;
        }
        bool ControlButton(string Text)
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is Button radioButton)
                    {
                        if (radioButton.Text == Text)
                        {
                            return true;
                        }
                    }
                }

            }
            return false;

        }
        void RadioButtonEnable()
        {
            for (int i = 0; i < Controls.Count * 5; i++)
            {
                foreach (var item in Controls)
                {
                    if (item is RadioButton radioButton)
                    {
                        radioButton.Enabled = false;
                    }
                }
            }
        }
        private void RadioButton_Click(object sender, EventArgs e)
        {
            //bool y = false;
            //for (int i = 0; i < Controls.Count; i++)
            //{
            //    foreach (var item in Controls)
            //    {
            //        if (item is RadioButton radioButton)
            //        {
            //            if ( !y && radioButton.Checked && createQuestionCounter == questionBlock.Count)
            //            {
            //                y = true;
            //                RadiobuttunList.Add(radioButton.Name);
            //            }
            //            //else if(!y  &&  radioButton.Checked)
            //            //{
            //            //    y = true;
                      
            //            //    RadiobuttunList[createQuestionCounter] = radioButton.Name;
            //            //}
            //        }


            //    }
            //}
            //MessageBox.Show(createQuestionCounter.ToString());
            //MessageBox.Show(RadiobuttunList[createQuestionCounter]);
            ButonEnableTrue();
        }
        
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(button.Text=="Delete Page")
            {
               if(questionBlock.Count!=0)
                {
                    int pointy_ = 0;
                    
                        questionBlock.RemoveAt(createQuestionCounter);
                    counter++;
                    createQuestionCounter++;
                    ResetForm();
                    point.Y = 36;
                    MessageBox.Show(questionBlock.Count.ToString());
                    CreateTextLabel(questionBlock[createQuestionCounter].Text, string.Empty, true);
                    _CreateTextLabel(string.Empty);
                    AsciCounter = 0;
                    for (int i = 0; i < questionBlock[createQuestionCounter].Answers.Count; i++)
                    {
                        point.Y += 70;
                        CreateAnswerLabel(questionBlock[createQuestionCounter].Answers[i].Text, true);
                        _CreateanswerLabel(radiobuttonconter.ToString());
                        createRadioButton(AsciCounter.ToString());
                        AsciCounter++;
                    }
                    AsciCounter = questionBlock[createQuestionCounter].Answers.Count;
                    pointy_ = point.Y;
                    point.X = 803;
                    point.Y = 297;
                    createButton("Add", true);
                    point.Y = 197;
                    createButton("Remove", false);
                    point.Y = 97;
                    createButton("Delete Page", true);
                    point.Y = 120;
                    createButton("AddPage", true);
                    point.X = 36;
                    point.Y = 36;
                    createButton("Save", false);
                    point.Y = 477;
                    if (createQuestionCounter == questionBlock.Count - 1)
                    {
                        point.X = 800;
                        createButton("Next", false);
                        point.X = 700;
                        createButton("Back", true);
                    }
                    else
                    {
                        point.X = 800;
                        createButton("Next", true);
                        point.X = 700;
                        createButton("Back", true);
                    }

                    point.X = 803;
                    point.Y = 297;
                    createButton("Add", true);
                    point.Y = 197;
                    point.X = 36;
                    point.Y = 36;
                    createButton("Save", true);
                    point.Y = pointy_ + 70;
                }
                else
                {
                    int pointy;
                    
                        questionBlock.RemoveAt(createQuestionCounter-1);
                    counter--;
                    createQuestionCounter--;
                    ResetForm();
                    point.Y = 36;
                    CreateTextLabel(questionBlock[createQuestionCounter].Text, string.Empty, true);
                    _CreateTextLabel(string.Empty);
                    AsciCounter = 0;
                    for (int i = 0; i < questionBlock[createQuestionCounter].Answers.Count; i++)
                    {
                        point.Y += 70;
                        CreateAnswerLabel(questionBlock[createQuestionCounter].Answers[i].Text, true);
                        _CreateanswerLabel(radiobuttonconter.ToString());
                        createRadioButton(AsciCounter.ToString());
                        AsciCounter++;
                    }
                    pointy = point.Y;
                    AsciCounter = 0;
                    point.X = 803;
                    point.Y = 297;
                    createButton("Add", true);
                    point.Y = 197;
                    createButton("Remove", false);
                    point.Y = 97;
                    createButton("Delete Page", true);
                    point.Y = 120;
                    createButton("AddPage", true);
                    point.X = 36;
                    point.Y = 36;
                    createButton("Save", false);
                    point.Y = 477;
                    if (createQuestionCounter == 0)
                    {
                        point.X = 800;
                        createButton("Next", true);
                        point.X = 700;
                        createButton("Back", false);
                    }
                    if (questionBlock.Count != 0 && createQuestionCounter <= questionBlock.Count)
                    {
                        point.X =800;
                        createButton("Next", true);
                        point.X = 700;
                        createButton("Back", true);
                    }
                    point.Y = pointy + 70;
                    AsciCounter = questionBlock[createQuestionCounter].Answers.Count;
                }


            }
            if (button.Text == "AddPage")
            {
                if (createQuestionCounter != -1)
                ReadList();
                AsciCounter = 0;
                ResetForm();
                point.Y = 36;
                counter++;
                CreateTextLabel(string.Empty, string.Empty, true);
                _CreateTextLabel(string.Empty);
                point.X = 803;
                point.Y = 297;
                createButton("Add", true);
                point.Y = 197;
                createButton("Remove", false);
                point.Y = 97;
               // createButton("Delete Page", true);
                point.Y = 120;
                createButton("AddPage", false);
                point.X = 36;
                point.Y = 36;
                createButton("Save", false);
                TextBox label = new TextBox();
                label.Size = new Size(100, 81);
                label.Location = new Point(point.X, point.Y-20);
                label.Name = "Save";
                this.Controls.Add(label);
                point.Y = 477;
                point.X = 800;
                createButton("Next", false);
                point.X = 700;
                createButton("Back", false);
                ButonEnableTrue();
                createQuestionCounter++;
            }
            if (button.Text == "Remove")
            {
                if (point.Y == 36)
                {
                    ResetAnswerTextBox();
                    ButtonEnable();
                }
                else
                {
                    AsciCounter--;
                    ResetRadiButton();
                    ResetAnswerTextBox();
                    ButtonEnable();
                   // counter--;
                }
                point.Y -= 70;
            }
            if (button.Text == "Save")
            {
                ReadList();
                bool q = true;

                        XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionBlock>));
                //using (SaveFileDialog sdf = new SaveFileDialog() { Filter = "PDf file|*.pdf", ValidateNames = true })
                //{
                //    if (sdf.ShowDialog() == DialogResult.OK)
                //    {
                //        iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                //        PdfWriter.GetInstance(doc, new FileStream(sdf.FileName, FileMode.Create));
                //        doc.Open();
                //        doc.Add(new iTextSharp.text.Paragraph(questionBlock[0].Text));

                //    }
                    
                    
                //}
                for (int i = 0; i < Controls.Count*4; i++)
                {
                    foreach (var item in Controls)
                    {
                        if(q &&  item is TextBox textBox)
                        {
                            q = false;
                            if(Directory.Exists("Quiz") && textBox.Text!=string.Empty)
                            {
                                StreamWriter sw = new StreamWriter($"Quiz\\{textBox.Text}.xml");
                                serializer.Serialize(sw, questionBlock);
                            }
                            else if( textBox.Text != string.Empty)
                            {
                                Directory.CreateDirectory("Quiz");
                               StreamWriter sw = new StreamWriter($"Quiz\\{textBox.Text}.xml");
                                serializer.Serialize(sw, questionBlock);
                            }
                        }
                    }
                }
            }
            if (button.Text == "Add")
            {
                if (AsciCounter == 0)
                    point.Y = 197;
                if (point.Y > 110)
                {
                    ButonEnableTrue();
                }
                if (point.Y > 40)
                {
                 
                    CreateAnswerLabel(string.Empty, true);
                    createRadioButton(AsciCounter.ToString());
                    _CreateanswerLabel(AsciCounter.ToString());
                    AsciCounter++;
                    radiobuttonconter++;
                    ButonEnableTrue();
                }
                point.Y += 70;
            }
            if (button.Text == "Next")
            {
                int pointy_=0;
                    ReadList();
                    counter++;
                    createQuestionCounter++;
                    ResetForm();
                    point.Y = 36;
                    CreateTextLabel(questionBlock[createQuestionCounter].Text, string.Empty, true);
                    _CreateTextLabel(string.Empty);
                    AsciCounter = 0;
                    for (int i = 0; i < questionBlock[createQuestionCounter].Answers.Count; i++)
                    {
                        point.Y += 70;
                        CreateAnswerLabel(questionBlock[createQuestionCounter].Answers[i].Text, true);
                        _CreateanswerLabel(radiobuttonconter.ToString());
                        createRadioButton(AsciCounter.ToString());
                        AsciCounter++;
                    }
                    AsciCounter = questionBlock[createQuestionCounter ].Answers.Count;
                    pointy_ = point.Y;
                    point.X = 803;
                    point.Y = 297;
                    createButton("Add", true);
                    point.Y = 197;
                    createButton("Remove", false);
                    point.Y = 97;
              //  createButton("Delete Page", true);
                point.Y = 120;
                createButton("AddPage", true);
                    point.X = 36;
                    point.Y = 36;
                    createButton("Save", false);
                    point.Y = 477;
                    if (createQuestionCounter == questionBlock.Count-1  )
                    {
                        point.X = 800;
                        createButton("Next", false);
                        point.X = 700;
                        createButton("Back", true);
                    }
                    else
                    {
                        point.X = 800;
                        createButton("Next", true);
                        point.X = 700;
                        createButton("Back", true);
                    }

                    point.X = 803;
                    point.Y = 297;
                    createButton("Add", true);
                    point.Y = 197;
                    point.X = 36;
                    point.Y = 36;
                    createButton("Save", true);
                    point.Y = pointy_+70;
            }
            if (button.Text == "Back")
            {
                int pointy;
                    ReadList();
                    counter--;
                    createQuestionCounter--;
                    ResetForm();
                    point.Y = 36;
                    CreateTextLabel(questionBlock[createQuestionCounter].Text, string.Empty, true);
                    _CreateTextLabel(string.Empty);
                    AsciCounter = 0;
                    for (int i = 0; i < questionBlock[createQuestionCounter].Answers.Count; i++)
                    {
                        point.Y += 70;
                        CreateAnswerLabel(questionBlock[createQuestionCounter].Answers[i].Text, true);
                        _CreateanswerLabel(radiobuttonconter.ToString());
                        createRadioButton(AsciCounter.ToString());
                        AsciCounter++;
                    }
                    pointy = point.Y;
                    AsciCounter = 0;
                    point.X = 803;
                    point.Y = 297;
                    createButton("Add", true);
                    point.Y = 197;
                    createButton("Remove", false);
                    point.Y = 97;
               // createButton("Delete Page", true);
                point.Y = 120;
                createButton("AddPage", true);
                    point.X = 36;
                    point.Y = 36;
                    createButton("Save", false);
                    point.Y = 477;
                    if (createQuestionCounter == 0)
                    {
                        point.X = 200;
                        createButton("Next", true);
                        point.X = 100;
                        createButton("Back", false);
                    }
                    if (questionBlock.Count != 0 && createQuestionCounter <= questionBlock.Count)
                {
                        point.X = 800;
                        createButton("Next", true);
                    point.X = 700;
                    createButton("Back", true);
                }
                    point.Y = pointy+70;
                AsciCounter = questionBlock[createQuestionCounter].Answers.Count;
               
            }
        }
        #endregion ControlsClick
        void FormLoad(string Text)
        {
            if (a == 0)
            {








                //QuestionBlock questionBloc = new QuestionBlock();
                //questionBloc.id = 100;
                //questionBloc.Text = "Salam Kele";
                //questionBloc.Answers = new List<Answer>();
                //Answer answer = new Answer();
                //answer.id = 101;
                //answer.IsCorrect = "Kele";
                //answer.Text = "Civi";
                //questionBloc.Answers.Add(answer);
                //questionBlock.Add(questionBloc);

                StreamReader streamReader = new StreamReader(Path);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<QuestionBlock>));
                var obj = (List<QuestionBlock>)xmlSerializer.Deserialize(streamReader);
                a++;
                questionBlock = obj;

                questionBlocks = obj;
                do
                {
                    bool q = false;
                    Random random = new Random();
                    counter = random.Next(0, questionBlocks.Count);
                    foreach (var item in RandomQuestion)
                    {
                        if (item == counter)
                        {
                            q = true;
                        }
                    }
                    if (!q)
                    {
                        Class1Q class1Q = new Class1Q();
                        class1Q.Answers = new List<Class1A>();
                        class1Q.id = questionBlock[counter].id;
                        class1Q.Text = questionBlock[counter].Text;
                        RandomQuestion.Add(counter);
                        do
                        {
                            bool qw = false;
                            Class1A class1A = new Class1A();
                            int answercounter;
                            answercounter = random.Next(0, questionBlocks[counter].Answers.Count);
                            foreach (var item in RandomAnswer)
                            {
                                if (item == answercounter)
                                {
                                    qw = true;
                                }
                            }
                            if (!qw)
                            {
                                class1A.id = questionBlock[counter].Answers[answercounter].id;
                                class1A.Text = questionBlock[counter].Answers[answercounter].Text;
                                class1A.IsCorrect = questionBlock[counter].Answers[answercounter].IsCorrect;
                                class1Q.Answers.Add(class1A);
                                RandomAnswer.Add(answercounter);
                            }
                        } while (questionBlocks[counter].Answers.Count != RandomAnswer.Count);
                        RandomAnswer.Clear();
                        questionBlocks_.Add(class1Q);
                    }
                } while (questionBlocks.Count != RandomQuestion.Count);
                ListBox listBox = new ListBox();
                listBox.Location = new Point(140, 200);
                listBox.Size = new Size(100, 100);
                for (int i = 0; i < questionBlocks.Count; i++)
                {
                    questionBlocks[i].id = questionBlocks_[i].id;
                    questionBlocks[i].Text = questionBlocks_[i].Text;
                    for (int j = 0; j < questionBlocks[i].Answers.Count; j++)
                    {
                        questionBlocks[i].Answers[j].id = questionBlocks_[i].Answers[j].id;
                        questionBlocks[i].Answers[j].IsCorrect = questionBlocks_[i].Answers[j].IsCorrect;
                        questionBlocks[i].Answers[j].Text = questionBlocks_[i].Answers[j].Text;
                    }

                }
                counter = 0;
            }
            switch (Text)
            {
                case "Next":
                    counter++;
                    break;
                case "Back":
                    counter--;
                    break;
                case "":
                    counter = 0;
                    break;
            }
            point.Y = 97;
            CreateTextLabel(questionBlocks[counter].Text, counter.ToString(), false);
            point.Y = 197;
            foreach (var item in questionBlocks[counter].Answers)
            {
                CreateAnswerLabel(item.Text, false);
                createRadioButton(item.id.ToString());
                AsciCounter++;
                point.Y += 70;
            }
            point.X = 300;
            createButton("Sub", true);
            point.X = 00;
            if (counter == questionBlocks.Count - 1)
            {
                createButton("Next", false);
            }
            else
            {
                createButton("Next", true);
            }
            point.X = 0;
            if (counter == 0)
            {
                createButton("Back", false);
            }
            else
            {
                createButton("Back", true);
            }
            point.X = 100;
            createButton("Accept", true);
        }
        public void Form3_Load(object sender, EventArgs e)
        {
            point.X = 803;
            point.Y = 97;
            createButton("AddPage", true);
          
        }

        private void Form3_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var item in files)
            {
                MessageBox.Show(item);
            }
        }

        private void Form3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
           
        }
    }
}