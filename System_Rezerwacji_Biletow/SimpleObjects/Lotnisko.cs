namespace System_Rezerwacji_Biletow;

public class Lotnisko
{
    //TODO jakas lepsza obsluga wypisywania tego, moze zewnetrzna biblioteka (?)
    public string Kraj { get; }
    public string Miasto { get; }
    public string Nazwa { get; }

    public Lotnisko(string kraj, string miasto, string nazwa)
    {
        Kraj = kraj;
        Miasto = miasto;
        Nazwa = nazwa;
    }

    public override string ToString()
    {
        return $"| {Kraj} | {Miasto} | {Nazwa} |";
    }
}