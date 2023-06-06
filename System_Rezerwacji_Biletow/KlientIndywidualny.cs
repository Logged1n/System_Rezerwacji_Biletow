namespace System_Rezerwacji_Biletow;

public class KlientIndywidualny
{
    private string Imie { get; }
    private string Nazwisko { get; }

    public string GetImie()
    {
        return Imie;
    }

    public string GetNazwisko()
    {
        return Nazwisko;
    }
}