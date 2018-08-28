using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Srednie_spalanie
{
    public partial class Form3 : Form
    {
        private int _litry;
        private int _liczba_samochodow;
        private Samochod[] _samochody;
        private Dystrybutor _dystrybutor;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(int liczba_samochodow, Samochod[] samochody, Dystrybutor dystrybutor)
        {
            _liczba_samochodow = liczba_samochodow;
            _samochody = samochody;
            _dystrybutor = dystrybutor;
            InitializeComponent();
        }


        // dystrybutor - dodaj litry
        private void button2_Click(object sender, EventArgs e)
        {
            _dystrybutor.dodajLitry(_litry);
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _litry = Int32.Parse(textBox1.Text.ToString());
        }

        //dystrybutor - wyzeruj litry
        private void button3_Click(object sender, EventArgs e)
        {
            _dystrybutor.wyzeruj();
            Close();
        }

        private void close()
        {
            this.Close();
        }
    }
}
