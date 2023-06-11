namespace System_Rezerwacji_Biletow.Interfaces;
using Samolot;

public interface ISamolotFactory // Interfejs fabryk samolotow ~wzorzec projektowy Abstract Factory
{
    public Samolot CreateSamolot(Lotnisko poczatkoweLotnisko);
}