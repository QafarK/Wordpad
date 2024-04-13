namespace Wordpad
{
    public partial class Form1 : Form
    {
        int size = 9;
        string name;
        public Form1()
        {

            InitializeComponent();
            foreach (var item in FontFamily.Families)
                comboBox1.Items.Add(item.Name);
            comboBox1.Items.RemoveAt(0);
            string data = "AliceBlue\r\nAntiqueWhite\r\nAqua\r\nAquamarine\r\nAzure\r\nBeige\r\nBisque\r\nBlack\r\nBlanchedAlmond\r\nBlue\r\nBlueViolet\r\nBrown\r\nBurlyWood\r\nCadetBlue\r\nChartreuse\r\nChocolate\r\nCoral\r\nCornflowerBlue\r\nCornsilk\r\nCrimson\r\nCyan\r\nDarkBlue\r\nDarkCyan\r\nDarkGoldenrod\r\nDarkGray\r\nDarkGreen\r\nDarkKhaki\r\nDarkMagenta\r\nDarkOliveGreen\r\nDarkOrange\r\nDarkOrchid\r\nDarkRed\r\nDarkSalmon\r\nDarkSeaGreen\r\nDarkSlateBlue\r\nDarkSlateGray\r\nDarkTurquoise\r\nDarkViolet\r\nDeepPink\r\nDeepSkyBlue\r\nDimGray\r\nDodgerBlue\r\nFirebrick\r\nFloralWhite\r\nForestGreen\r\nFuchsia\r\nGainsboro\r\nGhostWhite\r\nGold\r\nGoldenrod";
            string[] datas = data.Split("\r\n");
            for (int i = 0; i < datas.Length; i++)
                comboBox3.Items.Add(datas[i]);

            int num = 8;
            do
            {
                if (num < 36)
                {
                    comboBox2.Items.Add(num);
                    num += 2;
                }
                else
                {
                    comboBox2.Items.Add(num);
                    num += 4;
                }
            } while (num != 72);
            comboBox2.Items.Add(num);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new(comboBox1.SelectedItem.ToString(), size);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = Int32.Parse(comboBox2.SelectedItem.ToString());
            if (comboBox1.SelectedItem is not null)
                richTextBox1.Font = new(comboBox1.SelectedItem.ToString(), size);
            else
                richTextBox1.Font = new("Segoe UI", size);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem is not null)
                richTextBox1.ForeColor = Color.FromName(comboBox3.SelectedItem.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new(richTextBox1.Font, FontStyle.Bold);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new(richTextBox1.Font, FontStyle.Underline);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new(richTextBox1.Font, FontStyle.Italic);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            File.WriteAllText(openFileDialog1.FileName, richTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (name.Length > 0)
            {
                string path = Path.Combine("..\\", "..\\", "..\\", name + ".rtf");
                File.WriteAllText(path, richTextBox1.Text);
            }
        }
    }
}
