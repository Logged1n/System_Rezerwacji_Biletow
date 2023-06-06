namespace System_Rezerwacji_Biletow;

public class Lot
{
    public string NumerLotu { get; }
    public Trasa Trasa { get; }
    public Samolot Samolot { get; }

    public DateTime DataOdlotu{ get;}
    public DateTime DataPowrotu { get; }

    public Lot()
    {
    }
    
    public Lot(string numerLotu, Trasa trasa, Samolot samolot, DateTime dataOdlotu, DateTime dataPowrotu)
    {
        NumerLotu = numerLotu;
        Trasa = trasa;
        Samolot = samolot;
        DataOdlotu = dataOdlotu;
        DataPowrotu = dataPowrotu;
    }
}