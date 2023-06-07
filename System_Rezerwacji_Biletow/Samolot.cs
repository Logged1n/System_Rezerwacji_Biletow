namespace System_Rezerwacji_Biletow;

public abstract class Samolot
{
    //TODO klasy dziedziczace, fabryki, ewentualnie w interface dodac argumenty CreateSamolot()
    public string Id { get; protected set; }
    public int IloscMiejsc { get; protected set; }
    public int Zasieg { get; protected set; }
    public Lotnisko PoczatkoweLotnisko { get; protected set; }
}