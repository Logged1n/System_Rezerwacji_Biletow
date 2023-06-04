namespace System_Rezerwacji_Biletow;

public class Lot
{
    private string _numerLotu;
    private Trasa _trasa;
    private Samolot _samolot;
    private DateTime _dataOdlotu;
    private DateTime _dataPowrotu;

    public Lot()
    {
    }
    
    public Lot(string numerLotu, Trasa trasa, Samolot samolot, DateTime dataOdlotu, DateTime dataPowrotu)
    {
        _numerLotu = numerLotu;
        _trasa = trasa;
        _samolot = samolot;
        _dataOdlotu = dataOdlotu;
        _dataPowrotu = dataPowrotu;
    }
    
    public string GetNumerLotu()
    {
        return _numerLotu;
    }

    public void SetNumerLotu(string numerLotu)
    {
        _numerLotu = numerLotu;
    }

    public Trasa GetTrasa()
    {
        return _trasa;
    }

    public void SetTrasa(Trasa trasa)
    {
        _trasa = trasa;
    }

    public Samolot GetSamolot()
    {
        return _samolot;
    }

    public void SetSamolot(Samolot samolot)
    {
        _samolot = samolot;
    }

    public DateTime GetDataOdlotu()
    {
        return _dataOdlotu;
    }

    public void SetDataOdlotu(DateTime dataOdlotu)
    {
        _dataOdlotu = dataOdlotu;
    }

    public DateTime GetDataPowrotu()
    {
        return _dataPowrotu;
    }

    public void SetDataPowrotu(DateTime dataPowrotu)
    {
        _dataPowrotu = dataPowrotu;
    }
}