namespace System_Rezerwacji_Biletow.Klient;
using Managements;

public class KlientIndywidualny : Klient
{
    public string Imie { get;}
    public string Nazwisko { get; }

    public KlientIndywidualny(string numerTelefonu, string Email, string Imie, string Nazwisko) : base(numerTelefonu, Email)
    {
        Id = "I" + Convert.ToString(KlientManagment.GetInstance().GetList().Count);
        this.Imie = Imie;
        this.Nazwisko = Nazwisko;
    }

    public override string ToString()
    {
        return $"{Id};{NumerTelefonu};{Email};{Imie};{Nazwisko}";
    }
    
}