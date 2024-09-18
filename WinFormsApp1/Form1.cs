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
        bool dot = true;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (e.KeyChar == ' ') || (e.KeyChar == '-'))
                if (textBox1.SelectionStart == 0)
                    if (e.KeyChar == ' ' || e.KeyChar == '-') e.Handled = true;
                    else e.KeyChar = Char.ToUpper(e.KeyChar);

                else if (e.KeyChar == ' ')
                {
                    dashInsertionFlag = -1;
                    if (space == 0) space = 1;
                    else e.Handled = true;
                }
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
                space = 0;
            }
            if (space == 2 && dot)
            {
                textBox1.AppendText(".");
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
                dot = false;
            }
            if (space == 3)
            {
                textBox1.AppendText(".");
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = textBox1.Text.Length;
                dashInsertionFlag = 0;
                space = -1;
            };
        }
    }
}
