using System;

public class Samochod
{
//    public string Nazwa;
//   public string Nr_rej;
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
}
