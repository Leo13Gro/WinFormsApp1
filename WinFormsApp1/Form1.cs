using System.Globalization;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int space = 0;
        int dashInsertionFlag = 0;
        string template = "U+d U+.U+.";
        int i = 0;
        int num = 0;

        //private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsLetter(e.KeyChar) || e.KeyChar == '-')
        //    {
        //        textBox2.Text += e.KeyChar;
        //    }
        //}

        //private void textBox1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.K)
        //    {
        //        this.Text = "Tab";
        //        textBox1.SelectionStart = 0;
        //    }
        //}

        private void handleUpLetter(KeyPressEventArgs e) {
        }

        private void handleLowLetter(KeyPressEventArgs e) {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {   
            // if (template[i] == 'U'){
            //     num = 0;
            //     if (Char.IsLetter(e.KeyChar))
            //         if (num < template[i+1])
            //         {
            //             e.KeyChar = Char.ToUpper(e.KeyChar);
            //             num++;
            //         }
            //         else
            //         {

            //         }
            //     else e.Handled = true;
            //     if (template[i+1] == '+')
            //         i++;
            // }
            // else if (template[i] == 'l'){

            // }
            // else if (template[i] == ' '){
                
            // }
            // else if (template[i] == '.'){
                
            // }

            if (Char.IsLetter(e.KeyChar) || (e.KeyChar == ' ') || (e.KeyChar == '-'))
                if (textBox1.SelectionStart == 0)
                    if (e.KeyChar == ' ' || e.KeyChar == '-') e.Handled = true;
                    else e.KeyChar = Char.ToUpper(e.KeyChar);

                else if (e.KeyChar == ' ')
                    if (space == 0) space = 1;
                    else e.Handled = true;
                
                else if (e.KeyChar == '-')
                    if (dashInsertionFlag == 0)
                        dashInsertionFlag = 1;
                    else e.Handled = true;
                
                else if (dashInsertionFlag == 1)
                {
                    e.KeyChar = Char.ToUpper(e.KeyChar);
                    dashInsertionFlag = -1;
                }

                else if (space > 0)
                {
                    e.KeyChar = Char.ToUpper(e.KeyChar); space++;
                }
                else { }
            else e.Handled = true;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (space == -1 && e.KeyCode == Keys.Enter)
            {
                textBox2.Text += textBox1.Text + Environment.NewLine;
                textBox1.Text = string.Empty;
                dashInsertionFlag = 0;
                space = 0;
            }
            if (space == 2)
            {
                textBox1.AppendText(".");
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
            }
            if (space == 3)
            {
                textBox1.AppendText(".");
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = textBox1.Text.Length;
                space = -1;
            };
        }
    }
}
