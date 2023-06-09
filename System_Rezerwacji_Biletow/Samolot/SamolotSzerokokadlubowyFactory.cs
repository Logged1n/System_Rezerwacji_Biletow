namespace System_Rezerwacji_Biletow;

public class SamolotSzerokokadlubowyFactory : ISamolotFactory
{
    public Samolot CreateSamolot(Lotnisko poczatkoweLotnisko)
    {
        return new SamolotWaskokadlubowy(poczatkoweLotnisko);
    }
}