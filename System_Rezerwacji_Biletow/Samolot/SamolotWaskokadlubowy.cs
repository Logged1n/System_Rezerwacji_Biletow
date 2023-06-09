namespace System_Rezerwacji_Biletow.Samolot;
using Managements;

public class SamolotWaskokadlubowy : Samolot
{
    public SamolotWaskokadlubowy(Lotnisko poczatkoweLotnisko) : base(100, 1000, poczatkoweLotnisko)
    {
        Id = "W" + Convert.ToString(SamolotManagement.GetInstance().GetList().Count);
    }
}