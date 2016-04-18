using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;


namespace OCR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string testImagePath = "Capture.bmp";
            string txt = string.Empty;
            using (var engine = new TesseractEngine("tessdata", "chi_sim", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(testImagePath))
                {
                    var i = 1;
                    using (var page = engine.Process(img))
                    {
                        txt = page.GetText();
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(txt))
                this.label1.Text = txt;
        }
    }
}
