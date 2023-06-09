namespace System_Rezerwacji_Biletow.Exceptions;

public class BrakLotuException : Exception
{
    public BrakLotuException() : base("Brak lotu spelniajacego wymagania."){}
}