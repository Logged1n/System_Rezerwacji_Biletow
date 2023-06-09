namespace System_Rezerwacji_Biletow.Exceptions;

public class BrakTrasyException : Exception
{
    public BrakTrasyException() : base("Brak szukanej trasy."){}
}