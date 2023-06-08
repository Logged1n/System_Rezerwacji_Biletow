namespace System_Rezerwacji_Biletow;

public class NieUdaloSieOdczytacPlikuException : Exception
{
    public NieUdaloSieOdczytacPlikuException() : base("Nie udalo sie oczytac pliku."){}
}