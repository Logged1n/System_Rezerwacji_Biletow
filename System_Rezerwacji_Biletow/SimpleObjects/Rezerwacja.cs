namespace System_Rezerwacji_Biletow;

public class Rezerwacja
{
    private string Id { get; }
    private Klient.Klient klient { get; }
    private Lot.Lot Lot { get;  }
}