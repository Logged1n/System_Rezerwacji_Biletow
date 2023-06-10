namespace System_Rezerwacji_Biletow.Exceptions;

public class TakiSamolotJuzIstniejeException : Exception
{
    public TakiSamolotJuzIstniejeException():base("Samolot o takim Id jest już w bazie samolotów!"){}
}