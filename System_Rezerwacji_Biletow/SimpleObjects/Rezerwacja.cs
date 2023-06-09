namespace System_Rezerwacji_Biletow;
using Lot;

public class Rezerwacja
{
    public string Id { get; }
    public Klient Klient { get; }
    public Lot.Lot Lot { get; }
}
   