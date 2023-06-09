namespace System_Rezerwacji_Biletow.Klient;
using Managements;

public class KlientIndywidualny : Klient
{
    public string Imie { get;}
    public string Nazwisko { get; }

    internal KlientIndywidualny(string numerTelefonu, string Email, string Imie, string Nazwisko) : base(numerTelefonu, Email) // patrz KlientFirma
    {
        Id = "I" + Convert.ToString(KlientManagement.GetInstance().GetList().Count);
        this.Imie = Imie;
        this.Nazwisko = Nazwisko;
    }

    public override string ToString()
    {
        return $"{Id};{NumerTelefonu};{Email};{Imie};{Nazwisko}";
    }
    
}