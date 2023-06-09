using System_Rezerwacji_Biletow.Managements;

namespace System_Rezerwacji_Biletow;

public class SamolotRegionalnyFactory : ISamolotFactory
{
    //przyklad dobrze zrobionej fabryki samolotu
    public Samolot CreateSamolot(Lotnisko poczatkoweLotnisko)
    {
        return new SamolotRegionalny(poczatkoweLotnisko);
    }
}