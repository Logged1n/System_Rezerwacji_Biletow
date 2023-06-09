namespace System_Rezerwacji_Biletow.Exceptions;

public class BrakLotniskaException : Exception
{
    public BrakLotniskaException() : base("Nie istnieje takie lotnisko na liscie."){}
}