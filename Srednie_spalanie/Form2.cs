using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Srednie_spalanie
{
    public partial class Form2 : Form
    {
        Samochod[] _samochody;
        int _liczba_samochodow;
        Samochod _samochod;
        Dystrybutor _dystrybutor;

        public Form2(Samochod samochod, int liczba_samochodow, Samochod[] samochody)
        {
            _dystrybutor = new Dystrybutor();
            _samochod = samochod;
            _samochody = samochody;
            _liczba_samochodow = liczba_samochodow;
            InitializeComponent(_samochod);
            addFBButtons();
            addDystButtonLabel();
        }

        private void addFBButtons()
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

        private void addDystButtonLabel()
        {
            int height = 37;
            int width = 110;
            int margin = 20;
            Button opcjeButton = new Button();
            opcjeButton.Height = height;
            opcjeButton.Width = width;
            opcjeButton.Location = new Point((ClientSize.Width - width - margin), 55);
            opcjeButton.Text = "Opcje...";
            opcjeButton.Name = "opcjeButton";
            opcjeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            opcjeButton.UseVisualStyleBackColor = true;
            opcjeButton.Click += new EventHandler(opcjeButton_OnClick);
            Controls.Add(opcjeButton);

            Label infoLabel = new Label();
            infoLabel.AutoSize = false;
            infoLabel.Width = 320;
            infoLabel.Text = "Ilość litrów w dystrybutorze: " + _dystrybutor.IloscLitrow;
            infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            infoLabel.TextAlign = ContentAlignment.MiddleCenter;
            infoLabel.Location = new Point((ClientSize.Width - infoLabel.Width) / 2, 60);
            infoLabel.Name = "infoLabel";
            Controls.Add(infoLabel);
        }

        private void wsteczButton_OnClick(object sender, EventArgs e)
        {
            Form1 myForm = new Form1(_liczba_samochodow, _samochody);
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void opcjeButton_OnClick(object sender, EventArgs e)
        {
            Form3 myForm = new Form3(_liczba_samochodow, _samochody, _dystrybutor);
            //this.Hide();
            myForm.ShowDialog();
            //this.Close();

        }

        private void zatwierdzButton_OnClick(object sender, EventArgs e)
        {
            if (_samochod.Kierowca != null && _samochod.IloscLitrow != 0 && _samochod.StanLicznika != 0)
            {
                string day = dateTimePicker1.Value.Day.ToString();
                string msc = dateTimePicker1.Value.Month.ToString();
                string year = dateTimePicker1.Value.Year.ToString();
                string path = "../../doc/" + year + "_" + msc + ".xml";

                if (_dystrybutor.IloscLitrow - _samochod.IloscLitrow > 0)
                {
                    _dystrybutor.odejmijLitry(_samochod.IloscLitrow);
                    if (!File.Exists(path))
                    {
                        new XDocument(
                            new XElement("root",
                                new XElement("auto",
                                    new XElement("nazwa", _samochod.Nr_rej),
                                    new XElement("dzien", day),
                                    new XElement("kierowca", _samochod.Kierowca),
                                    new XElement("przebieg", _samochod.StanLicznika),
                                    new XElement("litry", _samochod.IloscLitrow)
                                    )
                                )
                           )
                        .Save(path);
                    }
                    else
                    {
                        var xdoc = new XDocument();
                        xdoc = XDocument.Load(path);
                        var element = new XElement("auto");
                        element.Add(new XElement("nazwa", _samochod.Nr_rej), new XElement("dzien", day), new XElement("kierowca", _samochod.Kierowca), new XElement("przebieg", _samochod.StanLicznika), new XElement("litry", _samochod.IloscLitrow));
                        xdoc.Root.Add(element);
                        xdoc.Save(path);
                    }
                    ok_komunikat();
                }
                else
                {
                    err_fuel_komunikat();
                }
            }
            else
            {
                err_komunikat();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this._samochod.Kierowca = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this._samochod.StanLicznika = Int32.Parse(textBox2.Text);
            }
            catch (Exception)
            {
                this._samochod.StanLicznika = 0;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this._samochod.IloscLitrow = Int32.Parse(textBox3.Text);
            }
            catch (Exception)
            {
                this._samochod.IloscLitrow = 0;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ok_komunikat()
        {
            const string message = "Dane zostały zapisane!";
            const string caption = "Informacja";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void err_komunikat()
        {
            const string message = "Jedno z pol jest nieuzupelnione!";
            const string caption = "Błąd";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void err_fuel_komunikat()
        {
            const string message = "Teoretycznie nie ma tyle litrow w dystrybutorze";
            const string caption = "Błąd przy dystrybutorze";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
