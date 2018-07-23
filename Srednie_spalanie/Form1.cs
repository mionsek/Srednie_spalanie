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
        }

        private void rej1_button_Click(object sender, EventArgs e)
        {
            Form2 myForm = new Form2();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
    }
}
