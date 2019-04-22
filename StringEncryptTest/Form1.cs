using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace StringEncryptTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.rtbSource.Text))
                return;
            this.rtbResult.Text= StringEncrypt.StringEncrypt.Encode(this.rtbSource.Text);
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.rtbSource.Text))
                return;
            this.rtbResult.Text = StringEncrypt.StringEncrypt.Decode(this.rtbSource.Text);
        }
    }
}
