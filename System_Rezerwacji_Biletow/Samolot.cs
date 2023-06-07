namespace System_Rezerwacji_Biletow;

public abstract class Samolot
{
    public string Id { get; protected set; }
    public int IloscMiejsc { get; protected set; }
    public int Zasieg { get; protected set; }
    public Lotnisko PoczatkoweLotnisko { get; protected set; }
}