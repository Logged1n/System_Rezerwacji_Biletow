namespace System_Rezerwacji_Biletow.Exceptions;

public class NieUdaloSieZapisacPlikuException : Exception
{
    public NieUdaloSieZapisacPlikuException() : base("Nie udalo sie zapisac stanu systemu."){}
}