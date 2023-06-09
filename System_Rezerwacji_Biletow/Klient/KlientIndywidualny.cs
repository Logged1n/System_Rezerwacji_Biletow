namespace System_Rezerwacji_Biletow;

public class KlientIndywidualny : Klient
{
    public string Imie { get;}
    public string Nazwisko { get; }

    public KlientIndywidualny(string id, string numerTelefonu, string email) : base(id, numerTelefonu, email) // zrob co brakuje, przy okazji zrozumiesz schemat
    {
        
    }
}