namespace System_Rezerwacji_Biletow.Lot; 
using Samolot;
public class Lot
{
    public string NumerLotu { get;  internal set; } // niepowtarzalny identyfikator danego lotu
    public Trasa Trasa { get; internal set; } // samolot leci z punktu A do punktu B (i wraca do punktu A ~uproszczenie)
    public Samolot Samolot { get; internal set; } // konkretny samolot danego lotu
    public DateTime DataOdlotu{ get; internal set; } // dokladna data (i godzina) odlotu samolotu z punktu A
    public DateTime DataPowrotu { get; internal set; } // dokladna data (i godzina) powrotu samolotu do punktu A ~uproszczenie (A-->B-->A)
    public Czestotliwosc CzestotliwoscLotu { get; internal set; } // Jak czesto ten lot sie powtarza (jest jednorazowy, cotygodniowy, codzienny..?)

    public override string ToString()
    {
        return $"{NumerLotu};{Trasa.Start.Nazwa};{Trasa.Cel.Nazwa};{Samolot.Id};{DataOdlotu};{DataPowrotu};{CzestotliwoscLotu}";
    }
}