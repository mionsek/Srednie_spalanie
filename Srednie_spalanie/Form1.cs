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
    public partial class Form1 : Form
    {
        public int _liczba_samochodow;
        public Samochod[] _samochody;

        public Form1()
        {
            InitializeComponent(_liczba_samochodow, _samochody);
        }

        public Form1(int liczba_samochodow, Samochod[] samochody)
        {
            this._liczba_samochodow = liczba_samochodow;
            this._samochody = samochody;

            InitializeComponent(_liczba_samochodow, _samochody);
            CreateDynamicButtons();
        }

        private void rej1_button_Click(object sender, EventArgs e)
        {
            Form2 myForm = new Form2();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void CreateDynamicButtons()
        {
            int tmp_cnt = 0;
            for (int i = 0; i < this._liczba_samochodow; i++)
            {
                int margin = 6;
                int height = 37;
                int width = 350;
                Button dynamicButton = new Button();
                // Set Button properties
                dynamicButton.Height = height;
                dynamicButton.Width = width;
                if (tmp_cnt % 2 == 0)
                {
                    dynamicButton.Location = new Point(ClientSize.Width / 2 - (width + margin), 70 + (tmp_cnt / 2 * height) + margin * i);
                }
                else
                {
                    dynamicButton.Location = new Point(ClientSize.Width / 2 + margin, 70 + (tmp_cnt/2 * height) + margin*(i - 1));
                }
                dynamicButton.Text = this._samochody[i].Nr_rej + " - " + this._samochody[i].Nazwa;
                dynamicButton.Name = "SamochodButton" + i;
                dynamicButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
                dynamicButton.UseVisualStyleBackColor = true;

                Controls.Add(dynamicButton);
                tmp_cnt += 1;
            }
        }

    }
}
