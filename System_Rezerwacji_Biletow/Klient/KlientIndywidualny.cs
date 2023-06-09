namespace System_Rezerwacji_Biletow;

public class KlientIndywidualny : Klient
{
    public string Imie { get;}
    public string Nazwisko { get; }

    public KlientIndywidualny(string Id, string numerTelefonu, string Email, string Imie, string Nazwisko) : base(Id, numerTelefonu,
        Email)
    {
        
    }

    public override string ToString()
    {
        return $"{Id};{NumerTelefonu};{Email};{Imie};{Nazwisko}";
    }
    
}