﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Srednie_spalanie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rej1_button_Click(object sender, EventArgs e)
        {
            Form2 myForm = new Form2();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
    }
}
