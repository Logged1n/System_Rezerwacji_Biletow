namespace System_Rezerwacji_Biletow;

public class LotPasazerskiBuilder : ILotBuilder
{
    private Lot _lot;
    private ISamolotManagement _samolotManagement;
    private ILotManagement _lotManagement;

    public LotPasazerskiBuilder()
    {
        this.Reset();
    }

    public void Reset()
    {
        _lot = new Lot();
    }

    public void SetNumerLotu(string numerLotu)
    {
        _lot.SetNumerLotu(numerLotu);
    }

    public void SetTrasa(Trasa trasa)
    {
        _lot.SetTrasa(trasa);
    }

    public void SetSamolot(Samolot samolot)
    {
        _lot.SetSamolot(samolot);
    }

    public void SetDataOdlotu(DateTime dataOdlotu)
    {
        _lot.SetDataOdlotu(dataOdlotu);
    }

    public void SetDataPowrotu(DateTime dataPowrotu)
    {
        _lot.SetDataPowrotu(dataPowrotu);
    }

    public Lot GetLot()
    {
        _lotManagement.Dodaj(_lot);
        return _lot;
    }
}