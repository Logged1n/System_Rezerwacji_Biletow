namespace System_Rezerwacji_Biletow.Lot; 

public class Lot
{
    public string NumerLotu { get;  internal set; }
    public Trasa Trasa { get; internal set; }
    public Samolot Samolot { get; internal set; }
    public DateTime DataOdlotu{ get; internal set; }
    public DateTime DataPowrotu { get; internal set; }
    public Czestotliwosc CzestotliwoscLotu { get; internal set; }

    public override string ToString()
    {
        return $"{NumerLotu};{Trasa};{Samolot};{DataOdlotu};{DataPowrotu};{CzestotliwoscLotu}";
    }
}