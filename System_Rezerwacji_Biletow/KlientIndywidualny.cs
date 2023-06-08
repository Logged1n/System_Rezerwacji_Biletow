namespace System_Rezerwacji_Biletow;

public class KlientIndywidualny : Klient
{
    public string Imie { get;}
    public string Nazwisko { get; }

    public KlientIndywidualny(string Id, string NrTel, string Email, string Imie, string Nazwisko) : base(Id, NrTel,
        Email)
    {
        
    }
    
}