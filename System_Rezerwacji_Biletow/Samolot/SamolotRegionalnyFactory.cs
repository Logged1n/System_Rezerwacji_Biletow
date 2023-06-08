namespace System_Rezerwacji_Biletow;

public class SamolotRegionalnyFactory : ISamolotFactory
{
    public Samolot CreateSamolot(string id, int iloscMiejsc, int zasieg, Lotnisko poczatkoweLotnisko)
    {
        return new SamolotRegionalny(id, iloscMiejsc, zasieg, poczatkoweLotnisko);
    }
}