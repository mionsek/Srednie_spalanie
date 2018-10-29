using System;

public class Samochod : ICloneable
{

    public Samochod(string nazwa, string nr_rej)
    {
        Nazwa = nazwa;
        Nr_rej = nr_rej;
    }

    public Samochod()
    {

    }

    public string Nazwa { get; set; }
    public string Nr_rej { get; set; }
    public string Kierowca { get; set; }

    public int StanLicznika { get; set; }

    public int IloscLitrow { get; set; }

    public double Sr_spalanie { get; set; }
    public int Km_przejechane { get; set; }

    public int Dzien { get; set; }
    public int Przebieg { get; set; }
    public int IloscLitrowDoStat { get; set; }
    
    public object Clone()
    {
        return new Samochod();
    }

    public void Clear()
    {
        this.Dzien = 0;
        this.Kierowca = null;
        this.Km_przejechane = 0;
        this.Przebieg = 0;
        this.Sr_spalanie = 0;
        this.Nazwa = null;
        this.StanLicznika = 0;
        this.Nr_rej = null;
    }
}
