namespace System_Rezerwacji_Biletow.Exceptions;

public class BrakKlientaException : Exception
{
    public BrakKlientaException() : base("Brak takiego klienta na liscie.")
    {
        
    }
}