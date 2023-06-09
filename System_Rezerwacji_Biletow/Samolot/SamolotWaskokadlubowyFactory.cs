namespace System_Rezerwacji_Biletow;

public class SamolotWaskokadlubowyFactory : ISamolotFactory
{
    public Samolot CreateSamolot(Lotnisko poczatkoweLotnisko)
    {
        return new SamolotWaskokadlubowy(poczatkoweLotnisko);
    }
}