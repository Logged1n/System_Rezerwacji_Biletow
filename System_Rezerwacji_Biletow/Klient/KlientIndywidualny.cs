namespace System_Rezerwacji_Biletow;

public class KlientIndywidualny : Klient
{
    public string Imie { get;}
    public string Nazwisko { get; }

    public KlientIndywidualny(string numerTelefonu, string Email, string Imie, string Nazwisko) : base(numerTelefonu, Email)
    {
        
    }

    public override string ToString()
    {
        return $"{Id};{NumerTelefonu};{Email};{Imie};{Nazwisko}";
    }
    
}