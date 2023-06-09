namespace System_Rezerwacji_Biletow.Exceptions;

public class BrakOdpowiedniegoSamolotuException : Exception
{
    public BrakOdpowiedniegoSamolotuException() : base("Nie istnieje samolot spelniajacy wymagania.")
    {}
}