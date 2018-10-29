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
using System.Xml.Linq;

namespace Srednie_spalanie
{
    public partial class Form1 : Form
    {
        public int _liczba_samochodow;
        public Samochod[] _samochody;
        public Samochod wybrany_samochod;
        public List<string> _kierowcy;
        Dystrybutor _dystrybutor;

        public Form1()
        {
            InitializeComponent(_liczba_samochodow, _samochody);
        }

        public Form1(int liczba_samochodow, Samochod[] samochody, List<string> kierowcy)
        {
            this._liczba_samochodow = samochody.Length;
            this._samochody = samochody;
            this._kierowcy = kierowcy;
            _dystrybutor = new Dystrybutor();
            InitializeComponent(_liczba_samochodow, _samochody);
            //CreateDynamicButtons();
            CreateDropDownCarList();
            CreateDropDownDriverList();
            CreateDateTimePicker();
            CreateTextBoxes();
            CreateInfoButtons();
            CreateLabels();

            wybrany_samochod = new Samochod();
        }
        /*
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
        */
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
            raportButton.TabIndex = 7;
            raportButton.Click += new EventHandler(raportButton_OnClick);
            Controls.Add(raportButton);

            Button opcjeButton = new Button();
            opcjeButton.Height = height;
            opcjeButton.Width = width;
            opcjeButton.Location = new Point((ClientSize.Width - (width + margin) * 2), ClientSize.Height - height - margin);
            opcjeButton.Text = "Opcje...";
            opcjeButton.Name = "opcjeButton";
            opcjeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            opcjeButton.UseVisualStyleBackColor = true;
            opcjeButton.TabIndex = 6;
            opcjeButton.Click += new EventHandler(opcjeButton_OnClick);
            Controls.Add(opcjeButton);

            Button zatwierdzButton = new Button();
            zatwierdzButton.Height = height;
            zatwierdzButton.Width = width;
            zatwierdzButton.Location = new Point((ClientSize.Width - width) / 2 , ClientSize.Height - 150);
            zatwierdzButton.Text = "Zatwierdz!";
            zatwierdzButton.Name = "ZatwierdzButton";
            zatwierdzButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            zatwierdzButton.UseVisualStyleBackColor = true;
            zatwierdzButton.TabIndex = 5;
            zatwierdzButton.Click += new EventHandler(zatwierdzButton_OnClick);
            Controls.Add(zatwierdzButton);

        }

        private void CreateDropDownCarList()
        {
            List<string> auta = new List<string>();
            foreach(Samochod sa in _samochody)
            {
                auta.Add(sa.Nr_rej + " - " + sa.Nazwa);
            }

            int height = 37;
            int width = 400;
            carsComboBox = new ComboBox();
            carsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            carsComboBox.FormattingEnabled = true;
            carsComboBox.Font = new Font("Microsoft Sans Serif", 13.25F);
            carsComboBox.Items.AddRange(auta.ToArray());
            carsComboBox.Height = 37;
            carsComboBox.Size = new Size(width, height);
            carsComboBox.Location = new Point((ClientSize.Width - width) / 2, 80);
            carsComboBox.Name = "comboBox1";
            carsComboBox.TabIndex = 1;
            carsComboBox.SelectedIndexChanged += new System.EventHandler(carsComboBox_SelectedIndexChanged);

            Controls.Add(carsComboBox);
        }


        private void CreateDropDownDriverList()
        {
            int height = 37;
            int width = 400;
            driverComboBox = new ComboBox();
            driverComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            driverComboBox.FormattingEnabled = true;
            driverComboBox.Font = new Font("Microsoft Sans Serif", 13.25F);
            driverComboBox.Items.AddRange(_kierowcy.ToArray());
            driverComboBox.Height = 37;
            driverComboBox.Size = new Size(width, height);
            driverComboBox.Location = new Point((ClientSize.Width - width) / 2, 180);
            driverComboBox.Name = "comboBox1";
            driverComboBox.TabIndex = 2;
            driverComboBox.SelectedIndexChanged += new System.EventHandler(driverComboBox_SelectedIndexChanged);

            Controls.Add(driverComboBox);
        }

        /*
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
        */
        

        private void CreateLabels()
        {
            Label wybierzAutoLabel = new Label();
            wybierzAutoLabel.Font = new System.Drawing.Font("Verdana", 13F);
            wybierzAutoLabel.Size = new System.Drawing.Size(1008, 44);
            wybierzAutoLabel.Location = new System.Drawing.Point((ClientSize.Width - wybierzAutoLabel.Width) / 2, 40);
            wybierzAutoLabel.Name = "label1";
            wybierzAutoLabel.Text = "Wybierz rodzaj samochodu";
            wybierzAutoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            Label wybierzKierowceLabel = new Label();
            wybierzKierowceLabel.Font = new System.Drawing.Font("Verdana", 13F);
            wybierzKierowceLabel.Size = new System.Drawing.Size(1008, 44);
            wybierzKierowceLabel.Location = new System.Drawing.Point((ClientSize.Width - wybierzKierowceLabel.Width) / 2, 140);
            wybierzKierowceLabel.Name = "label2";
            wybierzKierowceLabel.Text = "Wybierz kierowce";
            wybierzKierowceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            Label wybierzDateLabel = new Label();
            wybierzDateLabel.Font = new System.Drawing.Font("Verdana", 13F);
            wybierzDateLabel.Size = new System.Drawing.Size(1008, 44);
            wybierzDateLabel.Location = new System.Drawing.Point((ClientSize.Width - wybierzDateLabel.Width) / 2, 240);
            wybierzDateLabel.Name = "label3";
            wybierzDateLabel.Text = "Wybierz date";
            wybierzDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            Label wybierzLitryLabel = new Label();
            wybierzLitryLabel.Font = new System.Drawing.Font("Verdana", 13F);
            wybierzLitryLabel.Size = new System.Drawing.Size(1008, 44);
            wybierzLitryLabel.Location = new System.Drawing.Point((ClientSize.Width - wybierzLitryLabel.Width) / 2, 340);
            wybierzLitryLabel.Name = "label4";
            wybierzLitryLabel.Text = "Wpisz ilosc litrow wlanych";
            wybierzLitryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            Label wybierzPrzebiegLabel = new Label();
            wybierzPrzebiegLabel.Font = new System.Drawing.Font("Verdana", 13F);
            wybierzPrzebiegLabel.Size = new System.Drawing.Size(1008, 44);
            wybierzPrzebiegLabel.Location = new System.Drawing.Point((ClientSize.Width - wybierzDateLabel.Width) / 2, 440);
            wybierzPrzebiegLabel.Name = "label5";
            wybierzPrzebiegLabel.Text = "Wpisz przebieg";
            wybierzPrzebiegLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            Label infoLabel = new Label();
            infoLabel.AutoSize = false;
            infoLabel.Width = 320;
            //infoLabel.Text = "Text";
            infoLabel.Text = "Ilość litrów w dystrybutorze: " + _dystrybutor.IloscLitrow;
            infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            infoLabel.TextAlign = ContentAlignment.MiddleCenter;
            infoLabel.Location = new Point((ClientSize.Width - infoLabel.Width) / 2, ClientSize.Height - 60);
            infoLabel.Name = "infoLabel";


            Controls.Add(wybierzAutoLabel);
            Controls.Add(wybierzKierowceLabel);
            Controls.Add(wybierzDateLabel);
            Controls.Add(wybierzLitryLabel);
            Controls.Add(wybierzPrzebiegLabel);
            Controls.Add(infoLabel);

        }

        private void CreateDateTimePicker()
        {
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker1.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDownGrid;
            dateTimePicker1.Font = new Font("Microsoft Sans Serif", 13.25F);
            dateTimePicker1.Size = new Size(400, 37);
            dateTimePicker1.Location = new Point((ClientSize.Width - dateTimePicker1.Width) / 2, 280);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ValueChanged += new System.EventHandler(dateTimePicker1_ValueChanged);

            Controls.Add(dateTimePicker1);
        }

        private void CreateTextBoxes()
        {
            paliwoTextBox = new TextBox();
            paliwoTextBox.Font = new Font("Microsoft Sans Serif", 13.25F);
            paliwoTextBox.Size = new Size(400, 31);
            paliwoTextBox.Location = new Point((ClientSize.Width - paliwoTextBox.Width) / 2, 384);
            paliwoTextBox.Name = "paliwoTextBox";
            paliwoTextBox.TabIndex = 3;
            paliwoTextBox.TextChanged += new System.EventHandler(paliwoTextBox_TextChanged);
            paliwoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(paliwoTextBox_keyDown);


            przebiegTextBox = new TextBox();
            przebiegTextBox.Font = new Font("Microsoft Sans Serif", 13.25F);
            przebiegTextBox.Size = new Size(400, 31);
            przebiegTextBox.Location = new Point((ClientSize.Width - paliwoTextBox.Width) / 2, 484);
            przebiegTextBox.Name = "przebiegTextBox";
            przebiegTextBox.TabIndex = 3;
            przebiegTextBox.TextChanged += new System.EventHandler(przebiegTextBox_TextChanged);
            przebiegTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(przebiegTextBox_keyDown);

            Controls.Add(paliwoTextBox);
            Controls.Add(przebiegTextBox);
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
            question_confirm();
            //SaveToFile();
        }

        private void SaveToFile()
        {
            if (wybrany_samochod.Nazwa == null ||
                wybrany_samochod.Kierowca == null ||
                wybrany_samochod.IloscLitrow == 0 ||
                wybrany_samochod.StanLicznika == 0)
            {
                err_komunikat();
            }
            else
            {
                string day = dateTimePicker1.Value.Day.ToString();
                string msc = dateTimePicker1.Value.Month.ToString();
                string year = dateTimePicker1.Value.Year.ToString();
                string path = "../../doc/" + year + "_" + msc + ".xml";

                if (_dystrybutor.IloscLitrow - wybrany_samochod.IloscLitrow > 0)
                {
                    _dystrybutor.odejmijLitry(wybrany_samochod.IloscLitrow);
                    if (!File.Exists(path))
                    {
                        new XDocument(
                            new XElement("root",
                                new XElement("auto",
                                    new XElement("nazwa", wybrany_samochod.Nr_rej),
                                    new XElement("dzien", day),
                                    new XElement("kierowca", wybrany_samochod.Kierowca),
                                    new XElement("przebieg", wybrany_samochod.StanLicznika),
                                    new XElement("litry", wybrany_samochod.IloscLitrow)
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
                        element.Add(
                            new XElement("nazwa", wybrany_samochod.Nr_rej),
                            new XElement("dzien", day),
                            new XElement("kierowca", wybrany_samochod.Kierowca),
                            new XElement("przebieg", wybrany_samochod.StanLicznika),
                            new XElement("litry", wybrany_samochod.IloscLitrow));
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
        }

        private void paliwoTextBox_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = przebiegTextBox;
            }
        }

        private void przebiegTextBox_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                question_confirm();
            }
        }


        private void raportButton_OnClick(object sender, EventArgs e)
        {
            Form4 myForm = new Form4();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void carsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            string s = carsComboBox.SelectedItem.ToString();
            string rejestr = s.Split(' ').First();

            foreach (Samochod sa in _samochody)
            {
                if (sa.Nr_rej.Equals(rejestr))
                {
                    wybrany_samochod = sa;
                    break;
                }
            }
        }

        private void driverComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            wybrany_samochod.Kierowca = driverComboBox.SelectedItem.ToString();
        }

        private void przebiegTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.wybrany_samochod.StanLicznika = Int32.Parse(przebiegTextBox.Text);
            }
            catch (Exception)
            {
                this.wybrany_samochod.StanLicznika = 0;
            }
        }

        private void paliwoTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.wybrany_samochod.IloscLitrow = Int32.Parse(paliwoTextBox.Text);
            }
            catch (Exception)
            {
                this.wybrany_samochod.IloscLitrow = 0;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            wybrany_samochod.Clear();
            Utilities.ResetAllControls(this);
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

        private void question_confirm()
        {
            const string caption = "Potwierdzenie wpisywania danych";
            const string message = "Czy na pewno chcesz wpisać te dane?";

            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SaveToFile();
                ClearForm();
            }
            else
            {
                ;
            }
       }
    }
}
