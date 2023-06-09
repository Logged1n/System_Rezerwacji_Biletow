namespace System_Rezerwacji_Biletow;
using Managements;
public class SamolotRegionalny : Samolot
{
    //przyklad poprawnie zrobionej podklasy w fabryce abstrakcyjnej
    // zrob reszte, przy okazji zrozumiesz schemat
    public SamolotRegionalny(Lotnisko poczatkoweLotnisko) : base(Convert.ToString(SamolotManagement.GetInstance().GetList().Count), 60, 300, poczatkoweLotnisko)
    {
    }
    public override string ToString()
    {
        return $"{Id};{IloscMiejsc};{Zasieg};{PoczatkoweLotnisko}";
    }
}