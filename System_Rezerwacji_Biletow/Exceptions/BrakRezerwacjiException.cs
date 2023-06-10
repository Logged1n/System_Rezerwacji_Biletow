namespace System_Rezerwacji_Biletow.Exceptions;

public class BrakRezerwacjiException : Exception
{
    public BrakRezerwacjiException() : base("Nie ma takiej rezerwacji w systemie")
    {
        
    }
}