namespace System_Rezerwacji_Biletow;

public class Lot
{
    private string _numerLotu;
    private Trasa _trasa;
    private Samolot _samolot;
    private DateTime _dataOdlotu;
    private DateTime _dataPowrotu;

    public string GetNumerLotu()
    {
        return _numerLotu;
    }

    public Trasa GetTrasa()
    {
        return _trasa;
    }

    public Samolot GetSamolot()
    {
        return _samolot;
    }

    public DateTime GetDataOdlotu()
    {
        return _dataOdlotu;
    }

    public DateTime GetDataPowrotu()
    {
        return _dataPowrotu;
    }
}