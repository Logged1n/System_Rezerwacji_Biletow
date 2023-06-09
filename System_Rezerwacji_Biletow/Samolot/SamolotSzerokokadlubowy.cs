namespace System_Rezerwacji_Biletow.Samolot;
using Managements;

public class SamolotSzerokokadlubowy : Samolot
{
    public SamolotSzerokokadlubowy(Lotnisko poczatkoweLotnisko) : base(200, 4000, poczatkoweLotnisko)
    {
        Id = "S" + Convert.ToString(SamolotManagement.GetInstance().GetList().Count);
    }
}