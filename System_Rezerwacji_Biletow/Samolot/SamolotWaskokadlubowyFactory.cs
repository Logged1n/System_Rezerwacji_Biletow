namespace System_Rezerwacji_Biletow.Samolot;

using Interfaces;

public class SamolotWaskokadlubowyFactory : ISamolotFactory
{
    public Samolot CreateSamolot(Lotnisko poczatkoweLotnisko)
    {
        return new SamolotWaskokadlubowy(poczatkoweLotnisko);
    }
}