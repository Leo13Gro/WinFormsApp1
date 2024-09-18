namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Boolean dotFlag = false;
        string template = ""; // ����� ��������� ���� ����� �� �������� ������: U1l U1.U1.
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
            if (template.Equals(""))
            {
                return;
            }
            if (i >= template.Length)
            {
                e.Handled = true;
                return;
            }
            if (template[i] == 'U')
            {
                if (num < (int)Char.GetNumericValue(template[i + 1]))
                {
                    if (Char.IsLetter(e.KeyChar))
                    {
                        num++;
                        e.KeyChar = Char.ToUpper(e.KeyChar);
                        if (num == (int)Char.GetNumericValue(template[i + 1]))
                        {
                            if (i+2 < template.Length && template[i + 2] == '.')
                            {
                                dotFlag = true;
                                i += 3;
                            }
                            else i += 2;
                            num = 0;
                        }
                        return;
                    }
                    else e.Handled = true;
                }
            }
            if (template[i] == 'l' && Char.IsLetter(e.KeyChar))
            {
                if (i+1 < template.Length && e.KeyChar == template[i + 1])
                {
                    i += 2;
                    return;
                }
                else return;
            }
            if (template[i] == ' ')
            {
                i++;
                return;
            }

            e.Handled = true;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (template.Equals("") && e.KeyCode == Keys.Enter)
            {
                template = textBox1.Text;
                textBox1.Text = string.Empty;
            }
            if (dotFlag)
            {
                textBox1.AppendText(".");
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
                dotFlag = false;
            }
            if (i+1 == template.Length && template[i] == 'l' && e.KeyCode == Keys.Enter)
            {
                textBox2.Text += textBox1.Text + Environment.NewLine;
                textBox1.Text = string.Empty;
                i = 0;
            }
            if (i >= template.Length && e.KeyCode == Keys.Enter)
            {
                textBox2.Text += textBox1.Text + Environment.NewLine;
                textBox1.Text = string.Empty;
                i = 0;
            }
            //if (space == -1 && e.KeyCode == Keys.Enter)
            //{
            //    textBox2.Text += textBox1.Text + Environment.NewLine;
            //    textBox1.Text = string.Empty;
            //    dashInsertionFlag = 0;
            //    space = 0;
            //}
            //if (space == 2)
            //{
            //    textBox1.AppendText(".");
            //    textBox1.SelectionStart = textBox1.Text.Length;
            //    textBox1.SelectionLength = 0;
            //}
            //if (space == 3)
            //{
            //    textBox1.AppendText(".");
            //    textBox1.SelectionStart = 0;
            //    textBox1.SelectionLength = textBox1.Text.Length;
            //    space = -1;
            //};
        }
    }
}
