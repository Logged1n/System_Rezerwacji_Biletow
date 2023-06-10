namespace System_Rezerwacji_Biletow.Exceptions;

public class TakieLotniskoJuzIstniejeException : Exception
{
    public TakieLotniskoJuzIstniejeException() : base("Lotnisko o takiej nazwie już istnieje!"){}
}