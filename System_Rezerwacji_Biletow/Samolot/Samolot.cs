namespace System_Rezerwacji_Biletow.Samolot;
using Managements;
public abstract class Samolot //schemat patrz klasa Klient
{
    public string Id { get; internal set; }
    public int IloscMiejsc { get; }
    public int Zasieg { get; }
    public Lotnisko PoczatkoweLotnisko { get; }
    
    protected Samolot(int iloscMiejsc, int zasieg, Lotnisko poczatkoweLotnisko)
    {
        Id = "S" + Convert.ToString(SamolotManagement.GetInstance().GetList().Count);
        IloscMiejsc = iloscMiejsc;
        Zasieg = zasieg;
        PoczatkoweLotnisko = poczatkoweLotnisko;
    }

    public override string ToString()
    {
        return $"{Id};{IloscMiejsc};{Zasieg};{PoczatkoweLotnisko.Nazwa}";
    }
    
}