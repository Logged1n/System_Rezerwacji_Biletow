using System.Diagnostics;
using System_Rezerwacji_Biletow.Managements;

namespace System_Rezerwacji_Biletow;

public abstract class Samolot
{
    //TODO klasy dziedziczace, fabryki, ewentualnie w interface dodac argumenty CreateSamolot()
    public string Id { get; protected set; }
    public int IloscMiejsc { get; protected set; }
    public int Zasieg { get; protected set; }
    public Lotnisko PoczatkoweLotnisko { get; protected set; }
    
    protected Samolot(string id, int iloscMiejsc, int zasieg, Lotnisko lotnisko)
    {
        Id = id;
        IloscMiejsc = iloscMiejsc;
        Zasieg = zasieg;
        PoczatkoweLotnisko = lotnisko;
    }

    public override string ToString()
    {
        return $"{GetType()}{Id};{IloscMiejsc};{Zasieg};{PoczatkoweLotnisko}"; //TODO zmiana GetType na cos zgrabniejszego lub w kazdej podklasie samolotu oddzielnie nadpisywac metode ToString()
    }
}