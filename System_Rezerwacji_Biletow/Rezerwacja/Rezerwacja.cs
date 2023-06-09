namespace System_Rezerwacji_Biletow.Rezerwacja;
using Lot;
using Klient;
using Managements;

public class Rezerwacja
{
    public string Id { get; }
    public Klient Klient { get; }
    public Lot Lot { get; }

    public Rezerwacja(Klient klient, Lot lot)
    {
        Id = Convert.ToString(KlientManagement.GetInstance().GetList().Count);
        Klient = klient;
        Lot = lot;
    }

    public override string ToString()
    {
        return $"{Id};{Klient};{Lot}";
    }
}
   