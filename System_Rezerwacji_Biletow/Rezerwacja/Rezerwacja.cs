namespace System_Rezerwacji_Biletow.Rezerwacje;
using Lot;
using Klient;

public class Rezerwacja
{
    public string Id { get; }
    public Klient Klient { get; }
    public Lot Lot { get; }

    public Rezerwacja(string id, Klient klient, Lot lot)
    {
        Id = id;
        Klient = klient;
        Lot = lot;
    }
}
   