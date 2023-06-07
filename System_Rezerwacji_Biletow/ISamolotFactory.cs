namespace System_Rezerwacji_Biletow;

public interface ISamolotFactory
{
    public Samolot CreateSamolot(string id, int iloscMiejsc, int zasieg, Lotnisko poczatkoweLotnisko); // ewentualnie dodac parametry jezeli beda potrzebne
}