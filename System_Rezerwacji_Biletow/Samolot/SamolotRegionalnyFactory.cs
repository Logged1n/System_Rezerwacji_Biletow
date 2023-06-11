namespace System_Rezerwacji_Biletow.Samolot;
using Interfaces;

public class SamolotRegionalnyFactory : ISamolotFactory
{
    public Samolot CreateSamolot(Lotnisko poczatkoweLotnisko)
    {
        return new SamolotRegionalny(poczatkoweLotnisko);
    }
}