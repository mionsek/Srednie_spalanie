using System;

public class Samochod
{
    public Samochod(string nazwa, string nr_rej)
    {
        Nazwa = nazwa;
        Nr_rej = nr_rej;
    }

    public string Nazwa { get; set; }
    public string Nr_rej { get; set; }

    public string Kierowca { get; set; }
}
