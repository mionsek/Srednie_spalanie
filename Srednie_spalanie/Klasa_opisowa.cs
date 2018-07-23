using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Srednie_spalanie
{
    class Klasa_opisowa
    {
        public int liczba_samochodow;
        public Samochod[] samochody;
        
        public void zaladuj_auta_XML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../doc/auta.xml");

            XmlNodeList xmlNL = doc.GetElementsByTagName("auto");
            int count = xmlNL.Count;
            samochody = new Samochod[count];
            for (int i = 0; i != count; i++)
                samochody[i] = new Samochod();

            liczba_samochodow = count;

            int tmp_cnt = 0;

            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node.Name;
                if (name == "auto")
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name == "nr_rej")
                        {
                            samochody[tmp_cnt].Nr_rej = child.InnerText;
                        }
                        if (child.Name == "nazwa")
                        {
                            samochody[tmp_cnt].Nazwa = child.InnerText;
                            tmp_cnt += 1;
                        }
                    }
                }
            }
        }
        public Klasa_opisowa()
        {
            zaladuj_auta_XML();
        }

    }
}
