using System;
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
    public partial class Form2 : Form
    {
        Samochod _samochod;
        public Form2(Samochod samochod)
        {
            _samochod = samochod;
            InitializeComponent(_samochod);
            addButtons();
        }

        private void addButtons()
        {
            int height = 37;
            int width = 110;
            int margin = 20;
            Button wsteczButton = new Button();
            wsteczButton.Height = height;
            wsteczButton.Width = width;
            wsteczButton.Location = new Point( margin, ClientSize.Height - height - margin);
            wsteczButton.Text = "Wstecz";
            wsteczButton.Name = "WsteczButton";
            wsteczButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            wsteczButton.UseVisualStyleBackColor = true;

            wsteczButton.Click += new EventHandler(wsteczButton_OnClick);
            Controls.Add(wsteczButton);

            Button zatwierdzButton = new Button();
            zatwierdzButton.Height = height;
            zatwierdzButton.Width = width;
            zatwierdzButton.Location = new Point(ClientSize.Width - width - margin, ClientSize.Height - height - margin);
            zatwierdzButton.Text = "Zatwierdz!";
            zatwierdzButton.Name = "ZatwierdzButton";
            zatwierdzButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            zatwierdzButton.UseVisualStyleBackColor = true;

            zatwierdzButton.Click += new EventHandler(zatwierdzButton_OnClick);
            Controls.Add(zatwierdzButton);

        }

        private void wsteczButton_OnClick(object sender, EventArgs e)
        {
            Form1 myForm = new Form1();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void zatwierdzButton_OnClick(object sender, EventArgs e)
        {
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
