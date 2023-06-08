namespace System_Rezerwacji_Biletow;

public class BrakLotuException : Exception
{
    public BrakLotuException() : base("Brak lotu spelniajacego wymagania."){}
}