namespace System_Rezerwacji_Biletow.Interfaces;


public interface ISamolotFactory // Interfejs fabryk samolotow ~wzorzec projektowy Abstract Factory
{
    public Samolot.Samolot CreateSamolot(Lotnisko poczatkoweLotnisko); // ewentualnie dodac parametry jezeli beda potrzebne
}