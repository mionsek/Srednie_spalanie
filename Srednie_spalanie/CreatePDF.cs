using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.ComponentModel;

namespace Srednie_spalanie
{
    public class CreatePDF
    {
        List<Samochod> _auta, c_auta;
        string _month;
        string _year;
        public CreatePDF(List<Samochod> autaList1, List<Samochod> autaList2, string miesiac, string year)
        {
            _auta = new List<Samochod>(autaList1.ToArray());
            c_auta = new List<Samochod>(autaList2.ToArray());

            this._month = miesiac;
            this._year = year;
            CreateFile();
        }

        public void CreateFile()
        {
            var doc = new Document();
            //string path = Environment.CurrentDirectory;
            string path = "../../Raporty";
            string filename = _month + "_" + _year + "_" + "Raport_Stachtrans.pdf";
            PdfWriter.GetInstance(doc, new FileStream(path + "/" + filename, FileMode.Create));
            doc.Open();
            Paragraph par = new Paragraph("Stachtrans - Raport Sredniego Spalania");
            par.Alignment = Element.ALIGN_CENTER;
            doc.Add(par);
            doc.Add(Chunk.NEWLINE);

            //SpalanieKierowcow(doc);       // to raczej nie ma sensu
            SpalanieSamochodow(doc);
            IloscLitrowWlanych(doc);
            //Wlanych litrow do samochodow i ile wlali kierowcy litrow
            

            doc.Close();
        }

        private void SpalanieKierowcow(Document doc)
        {
            // część 1 - obliczanie spalania i redukcja listy

            _auta = _auta.OrderBy(Samochod => Samochod.Nazwa).ThenBy(Samochod => Samochod.Kierowca).ToList();
            for (int i = 0; i < _auta.Count - 1; i++)
            {
                if (_auta[i].Kierowca.Equals(_auta[i + 1].Kierowca) && _auta[i].Nazwa.Equals(_auta[i + 1].Nazwa))
                {
                    if (_auta[i + 1].Km_przejechane > 0)
                    {
                        _auta[i].IloscLitrow += _auta[i + 1].IloscLitrow;
                        _auta[i].Km_przejechane += _auta[i + 1].Km_przejechane;
                        _auta.RemoveAt(i + 1);
                        i -= 1;
                    }
                }
                else
                {   // srednie spalanie z kilku tras
                    _auta[i].Sr_spalanie = (Convert.ToDouble(_auta[i].IloscLitrow) / Convert.ToDouble(_auta[i].Km_przejechane)) * 100.0;
                }
            }

            // część 2 - wypisanie wszystkeigo do pdf
            WriteDriverConsumptionToPDF(doc);
        }

        private void WriteDriverConsumptionToPDF(Document doc)
        {
            PdfPTable table = new PdfPTable(5);

            var cell = new PdfPCell(new Phrase("Spalanie kierowcow w poszczegolnych samochodach"));
            cell.Colspan = 5;
            table.AddCell(cell);

            table.AddCell(" ");
            table.AddCell("Kierowca");
            table.AddCell("Ilosc Litrow");
            table.AddCell("KM Przejechane");
            table.AddCell("Srednie Spalanie");

            for (int i = 0; i < _auta.Count; i++)
            {
                string phrase = _auta[i].Nazwa;
                if (_auta[i].Km_przejechane > 0)
                {
                    table.AddCell(phrase);
                    table.AddCell(_auta[i].Kierowca);
                    table.AddCell(_auta[i].IloscLitrow.ToString());
                    table.AddCell(_auta[i].Km_przejechane.ToString());
                    var tmp = String.Format("{0:0.00}", (c_auta[i].Sr_spalanie));
                    table.AddCell(tmp);
                }
            }
            doc.Add(table);
            doc.Add(Chunk.NEWLINE);
        }

        public void SpalanieSamochodow(Document doc)
        {
            c_auta = c_auta.OrderBy(Samochod => Samochod.Nazwa).ThenBy(Samochod => Samochod.Przebieg).ThenBy(Samochod => Samochod.Dzien).ToList();
            for (int i = 0; i < c_auta.Count - 1; i++)
            {
                if (c_auta[i].Nazwa.Equals(c_auta[i + 1].Nazwa))
                {
                    c_auta[i].Km_przejechane = c_auta[i + 1].Przebieg - c_auta[i].Przebieg;
                    //c_auta[i].Km_przejechane += c_auta[i + 1].Km_przejechane;
                    c_auta[i].IloscLitrow += c_auta[i + 1].IloscLitrow;
                    c_auta[i].IloscLitrowDoStat = c_auta[i].IloscLitrow;
                    //                    if (i + 2 < c_auta.Count)
                    {
                        if (c_auta[i].Nazwa.Equals(c_auta[i + 1].Nazwa) && !c_auta[i + 1].Nazwa.Equals(c_auta[i + 2].Nazwa))
                        {
                            c_auta[i].IloscLitrowDoStat -= c_auta[i + 1].IloscLitrow;
                        }
                    }

                    c_auta.RemoveAt(i + 1);
                    i -= 1;
                }
                else
                {
                    c_auta[i].Sr_spalanie = (Convert.ToDouble(c_auta[i].IloscLitrowDoStat) / Convert.ToDouble(c_auta[i].Km_przejechane)) * 100.0;
                }
            }

            WriteCarConsumptionToPDF(doc);
        }

        private void WriteCarConsumptionToPDF(Document doc)
        {
            //doc.NewPage();
            PdfPTable table = new PdfPTable(4);

            var cell = new PdfPCell(new Phrase("Spalanie paliwa poszczegolnych samochodow"));
            cell.Colspan = 5;
            table.AddCell(cell);

            table.AddCell("Samochod");
            table.AddCell("Ilosc Litrow");
            table.AddCell("KM Przejechane");
            table.AddCell("Srednie Spalanie");


            for (int i = 0; i < c_auta.Count; i++)
            {
                string phrase = c_auta[i].Nazwa;
                if (c_auta[i].Km_przejechane > 0)
                {
                    table.AddCell(phrase);
                    table.AddCell(c_auta[i].IloscLitrow.ToString());
                    table.AddCell(c_auta[i].Km_przejechane.ToString());
                    var tmp = String.Format("{0:0.00}", (c_auta[i].Sr_spalanie));
                    table.AddCell(tmp);
                }
            }
            doc.Add(table);
            doc.Add(Chunk.NEWLINE);
        }

        public void IloscLitrowWlanych(Document doc)
        {
            int suma = 0;

            foreach (var auto in c_auta)
            {
                suma += auto.IloscLitrow;
            }

            Paragraph par = new Paragraph("Lacznie wlanych litrow do samochodow:  " + suma);
            doc.Add(par);
        }
    }
}
