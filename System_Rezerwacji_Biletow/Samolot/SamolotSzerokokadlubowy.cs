namespace System_Rezerwacji_Biletow;
using Managements;

public class SamolotSzerokokadlubowy : Samolot
{
    public SamolotSzerokokadlubowy(Lotnisko poczatkoweLotnisko) : base(Convert.ToString(SamolotManagement.GetInstance().GetList().Count),200,4000,poczatkoweLotnisko)
    {}
    public override string ToString()
    {
        return $"{Id};{IloscMiejsc};{Zasieg};{PoczatkoweLotnisko}";
    }
}