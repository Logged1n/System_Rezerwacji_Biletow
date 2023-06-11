namespace System_Rezerwacji_Biletow.Samolot;

using Managements;
public class SamolotRegionalny : Samolot
{
    internal SamolotRegionalny(Lotnisko poczatkoweLotnisko) : base( 60, 300, poczatkoweLotnisko)
    {
        Id = "R" + Convert.ToString(SamolotManagement.GetInstance().GetList().Count);
    }
}