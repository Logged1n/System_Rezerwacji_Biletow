namespace System_Rezerwacji_Biletow;

public class Lot
{
    //TODO generalny ogar z builderem
    public string NumerLotu { get; set; }
    public Trasa Trasa { get; set; }
    public Samolot Samolot { get; set; }
    public DateTime DataOdlotu{ get; set; }
    public DateTime DataPowrotu { get; set; }

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