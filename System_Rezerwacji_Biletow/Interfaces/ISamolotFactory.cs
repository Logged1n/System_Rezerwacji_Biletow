namespace System_Rezerwacji_Biletow;

public interface ISamolotFactory // Interfejs fabryk samolotow ~wzorzec projektowy Abstract Factory
{
    public Samolot CreateSamolot(Lotnisko poczatkoweLotnisko); // ewentualnie dodac parametry jezeli beda potrzebne
}