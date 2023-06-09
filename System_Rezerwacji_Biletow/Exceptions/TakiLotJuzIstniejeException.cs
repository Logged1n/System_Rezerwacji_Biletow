namespace System_Rezerwacji_Biletow.Exceptions;

public class TakiLotJuzIstniejeException : Exception
{
    public TakiLotJuzIstniejeException() : base("Lot o numerze, ktory probujesz dodac jest juz w bazie lotow!"){}
}