using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Srednie_spalanie
{
    public partial class Form4 : Form
    {
        List<Samochod> autoList, autoList2;
        string _month;
        string _year;
        public Form4()
        {
            InitializeComponent();
            autoList = new List<Samochod>();
            autoList2 = new List<Samochod>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _month = dateTimePicker1.Value.Month.ToString();
            _year = dateTimePicker1.Value.Year.ToString();
            string path = "../../doc/" + _year + "_" + _month + ".xml";
            readFile(path);
        }

        private void readFile(string path)
        {
            bool ok = true;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlNodeList xmlNL = doc.GetElementsByTagName("auto");
                int count = xmlNL.Count;


                foreach (XmlNode node in doc.DocumentElement)
                {
                    string name = node.Name;
                    if (name == "auto")
                    {
                        Samochod tmp_auto = new Samochod();
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name == "nazwa")
                                tmp_auto.Nazwa = child.InnerText;
                            if (child.Name == "dzien")
                                tmp_auto.Dzien = Int32.Parse(child.InnerText);
                            if (child.Name == "kierowca")
                                tmp_auto.Kierowca = child.InnerText;
                            if (child.Name == "przebieg")
                                tmp_auto.Przebieg = Int32.Parse(child.InnerText);
                            if (child.Name == "litry")
                                tmp_auto.IloscLitrow = Int32.Parse(child.InnerText);
                        }
                        autoList.Add(tmp_auto);
                        autoList2.Add(tmp_auto);
                    }
                }

                policzSpalanie();
            }
            catch (Exception)
            {
                errorMessage();
                ok = false;
            }
            if (ok)
            {
                okMessage();
            }
        }

        public void errorMessage()
        {
            string msg = "Błąd. Prawdopodobnie raport z tego miesiąca nie został stworzony.";
            string caption = "Błąd otwarcia pliku";
            DialogResult dialogResult = MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void okMessage()
        {
            string msg = "Raport został stworzony.";
            string caption = "Raport";
            DialogResult dialogResult = MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void policzSpalanie()
        {
            /*
            autoList = autoList.OrderBy(Samochod => Samochod.Nazwa).ThenBy(Samochod => Samochod.Przebieg).ThenBy(Samochod => Samochod.Dzien).ToList();
            for (int i = 0; i < autoList.Count - 1; i++)
            {
                if (autoList[i].Nazwa.Equals(autoList[i + 1].Nazwa))
                {
                    autoList[i].Km_przejechane = autoList[i + 1].Przebieg - autoList[i].Przebieg;
                    autoList[i].Sr_spalanie = (Convert.ToDouble(autoList[i].IloscLitrow) / Convert.ToDouble(autoList[i].Km_przejechane)) * 100.0;
                }
            }
            */

            CreatePDF pdf = new CreatePDF(autoList, autoList2, _month, _year);
        }
    }
}
