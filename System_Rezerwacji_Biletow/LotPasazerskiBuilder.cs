namespace System_Rezerwacji_Biletow;

public class LotPasazerskiBuilder : ILotBuilder
{
    private string _numerLotu;
    private Trasa _trasa;
    private Samolot _samolot;
    private DateTime _dataOdlotu;
    private DateTime _dataPowrotu;
    private ISamolotManagement _samolotManagement;
    private ILotManagement _lotManagement;

    public LotPasazerskiBuilder()
    {
    }

    public ILotBuilder SetNumerLotu(string numerLotu)
    {
        _numerLotu = numerLotu;
        return this;
    }

    public ILotBuilder SetTrasa(Trasa trasa)
    {
        _trasa = trasa;
        return this;
    }

    public ILotBuilder SetSamolot(Samolot samolot)
    {
        _samolot = samolot;
        return this;
    }

    public ILotBuilder SetDataOdlotu(DateTime dataOdlotu)
    {
        _dataOdlotu = dataOdlotu;
        return this;
    }

    public ILotBuilder SetDataPowrotu(DateTime dataPowrotu)
    {
        _dataPowrotu = dataPowrotu;
        return this;
    }

    public Lot Build()
    {
        Lot _lot = new Lot(_numerLotu, _trasa, _samolot, _dataOdlotu, _dataPowrotu);
        _lotManagement.Dodaj(_lot);
        return _lot;
    }
}