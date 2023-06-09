namespace System_Rezerwacji_Biletow.Samolot;

using Managements;
public class SamolotRegionalny : Samolot
{
    //przyklad poprawnie zrobionej podklasy w fabryce abstrakcyjnej
    // zrob reszte, przy okazji zrozumiesz schemat
    public SamolotRegionalny(Lotnisko poczatkoweLotnisko) : base( 60, 300, poczatkoweLotnisko)
    {
        Id = "R" + Convert.ToString(SamolotManagement.GetInstance().GetList().Count);
    }
}