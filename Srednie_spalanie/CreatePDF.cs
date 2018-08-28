using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Srednie_spalanie
{
    public class CreatePDF
    {
        List<Samochod> _auta;
        string _month;
        string _year;
        public CreatePDF(List<Samochod> autaList, string miesiac, string year)
        {
            this._auta = autaList;
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

            PdfPTable table = new PdfPTable(5);

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
                    var tmp = String.Format("{0:0.00}", (_auta[i].Sr_spalanie));
                    table.AddCell(tmp);
                }
            }
            doc.Add(table);
            doc.Add(Chunk.NEWLINE);

            int total_liter = _auta.Sum(Samochod => Samochod.IloscLitrow);
            string zdanie2 = "Litrow paliwa wlanych do samochodow: " + total_liter;

            doc.Add(new Paragraph(zdanie2));

            doc.Close();
            //System.Diagnostics.Process.Start(path + "/" + filename);
        }
    }
}
