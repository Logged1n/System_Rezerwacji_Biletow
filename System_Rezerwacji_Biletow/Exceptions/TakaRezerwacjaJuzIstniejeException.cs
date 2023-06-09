namespace System_Rezerwacji_Biletow.Exceptions;

public class TakaRezerwacjaJuzIstniejeException : Exception
{
    public TakaRezerwacjaJuzIstniejeException() : base("Taka rezerwacja juz istnieje.")
    {
        
    }
}