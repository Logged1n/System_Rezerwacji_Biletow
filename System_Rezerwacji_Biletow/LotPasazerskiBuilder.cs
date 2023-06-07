namespace System_Rezerwacji_Biletow;

public class LotPasazerskiBuilder : ILotBuilder
{
    private Lot _lot;

    public LotPasazerskiBuilder()
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

    public Lot Build()
    {
        // TODO sprawdzic czy nie ma juz dokladnie takiego lotu na liscie
        LotManagement.GetInstance().Dodaj(_lot);
        return _lot;
    }
}