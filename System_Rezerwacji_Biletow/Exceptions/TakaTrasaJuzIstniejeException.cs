namespace System_Rezerwacji_Biletow.Exceptions;

public class TakaTrasaJuzIstniejeException : Exception
{
    public TakaTrasaJuzIstniejeException() : base("Taka trasa juz istnieje.") {}
}