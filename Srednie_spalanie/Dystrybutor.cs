using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Srednie_spalanie
{
    public class Dystrybutor
    {
        public Dystrybutor()
        {
            loadFromFile();
        }

        public int IloscLitrow { get; set; }


        public void wyzeruj()
        {
            IloscLitrow = 0;
            saveToFile();
        }

        public void dodajLitry(int x)
        {
            IloscLitrow += x;
            saveToFile();
        }

        public void odejmijLitry(int x)
        {
            IloscLitrow -= x;
            saveToFile();
        }

        private void loadFromFile()
        {
            var xml = new XmlDocument();
            xml.Load("../../doc/dystrybutor.xml");
            string tmp = xml.DocumentElement.SelectSingleNode("/dystrybutor/paliwo").InnerText.ToString();
            IloscLitrow = Int32.Parse(tmp);
        }

        public void saveToFile()
        {
            new XDocument(
                new XElement("dystrybutor",
                    new XElement("paliwo", IloscLitrow)
                    )
                ).Save("../../doc/dystrybutor.xml");
        }
    }
}
