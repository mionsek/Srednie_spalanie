using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Srednie_spalanie
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Klasa_opisowa klasa_Opisowa = new Klasa_opisowa();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(klasa_Opisowa.liczba_samochodow, klasa_Opisowa.samochody));
        }
    }
}
