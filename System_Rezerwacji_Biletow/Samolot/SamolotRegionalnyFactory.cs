namespace System_Rezerwacji_Biletow.Samolot;
using Interfaces;

public class SamolotRegionalnyFactory : ISamolotFactory
{
    //przyklad dobrze zrobionej fabryki samolotu
    public Samolot CreateSamolot(Lotnisko poczatkoweLotnisko)
    {
        return new SamolotRegionalny(poczatkoweLotnisko);
    }
}