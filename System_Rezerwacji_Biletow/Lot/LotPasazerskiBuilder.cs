namespace System_Rezerwacji_Biletow.Lot;
using Managements;
public class LotPasazerskiBuilder : ILotBuilder
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
        LotManagement.GetInstance().Dodaj(_lot);
        return _lot;
    }
}