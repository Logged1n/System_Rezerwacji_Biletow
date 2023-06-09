namespace System_Rezerwacji_Biletow.Exceptions;

public class TakiKlientJuzIstniejeException : Exception
{
    public TakiKlientJuzIstniejeException() : base("Taki klient juz sie znajduje na liscie klientow!"){}
}