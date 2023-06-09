namespace System_Rezerwacji_Biletow.Lot;
using Managements;
using Interfaces;
using Samolot;
public class LotPasazerskiBuilder : ILotBuilder // przykladowa implementacja interfejsu budowniczego lotu. w przyszlosci mozemy miec inne rodzaje lotu, budowane w inny sposob.
{
    private Lot _lot;

    public LotPasazerskiBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        _lot = new Lot();
    }
    public void SetNumerLotu(string numerLotu)
    {
        _lot.NumerLotu = numerLotu;
    }

    public void SetTrasa(Trasa trasa)
    {
        _lot.Trasa = trasa;
    }

    public void SetSamolot(Samolot samolot)
    {
        _lot.Samolot = samolot;
    }

    public void SetDataOdlotu(DateTime dataOdlotu)
    {
        _lot.DataOdlotu = dataOdlotu;
    }

    public void SetDataPowrotu(DateTime dataPowrotu)
    {
       _lot.DataPowrotu = dataPowrotu;
    }

    public void SetCzestotliwoscLotu(Czestotliwosc czestotliwoscLotu)
    {
        _lot.CzestotliwoscLotu = czestotliwoscLotu;
    }

    public Lot Build()
    {
        LotManagement.GetInstance().Dodaj(_lot); // Po stworzeniu lotu od razu dodajemy go do listy lotow (co jest bardzo latwe dzieki SINGLETONOWI)
        return _lot;
    }
}