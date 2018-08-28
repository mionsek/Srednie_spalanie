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
        public Samochod wybrany_samochod;

        public Form1()
        {
            InitializeComponent(_liczba_samochodow, _samochody);
        }

        public Form1(int liczba_samochodow, Samochod[] samochody)
        {
            this._liczba_samochodow = samochody.Length;
            this._samochody = samochody;

            InitializeComponent(_liczba_samochodow, _samochody);
            CreateDynamicButtons();
            CreateInfoButtons();
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
                dynamicButton.Name = i.ToString();
                dynamicButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
                dynamicButton.UseVisualStyleBackColor = true;

                //dynamicButton.Click += new EventHandler(DynamicButton_OnClick);
                dynamicButton.Click += (sender, e) => DynamicButton_OnClick(sender, e);


                Controls.Add(dynamicButton);
                tmp_cnt += 1;
            }
        }

        private void CreateInfoButtons()
        {
            int height = 37;
            int width = 110;
            int margin = 20;
            Button raportButton = new Button();
            raportButton.Height = height;
            raportButton.Width = width;
            raportButton.Location = new Point(ClientSize.Width - width - margin, ClientSize.Height - height - margin);
            raportButton.Text = "Raporty";
            raportButton.Name = "raportButton";
            raportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            raportButton.UseVisualStyleBackColor = true;

            raportButton.Click += new EventHandler(raportButton_OnClick);
            Controls.Add(raportButton);
        }

        private void DynamicButton_OnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            string a = btn.Name;
            int nr = Int32.Parse(a);

            Form2 myForm = new Form2(_samochody[nr],_liczba_samochodow, _samochody);
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void raportButton_OnClick(object sender, EventArgs e)
        {
            Form4 myForm = new Form4();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
    }
}
