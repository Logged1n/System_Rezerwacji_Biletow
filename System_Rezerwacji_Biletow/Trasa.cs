namespace System_Rezerwacji_Biletow;

public class Trasa
{
    public string Id { get; }
    public Lotnisko Start { get; }
    public Lotnisko Cel { get; }
    public int Dystans { get; }

    public Trasa(string id, Lotnisko start, Lotnisko cel, int dystans) // ROZNICA WZGLEDEM UML, nie bylo tego konstruktora
    {
        Id = id;
        Start = start;
        Cel = cel;
        Dystans = dystans;
    }

    public override string ToString()
    {
        return $"ID: {Id}; Lotnisko startowe: {Start}; Lotnisko docelowe: {Cel}; Dystans: {Dystans} km;";
    }
}