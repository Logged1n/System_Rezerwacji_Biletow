namespace System_Rezerwacji_Biletow;
using Managements;

public class SamolotWaskokadlubowy : Samolot
{
    public SamolotWaskokadlubowy(Lotnisko poczatkoweLotnisko) : base(Convert.ToString(SamolotManagement.GetInstance().GetList().Count),100,1000,poczatkoweLotnisko)
    {}
    public override string ToString()
    {
        return $"{Id};{IloscMiejsc};{Zasieg};{PoczatkoweLotnisko.Miasto}";
    }
}