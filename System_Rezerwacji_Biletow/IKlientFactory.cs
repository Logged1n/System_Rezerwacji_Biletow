namespace System_Rezerwacji_Biletow;

public interface IKlientFactory
{
    public  Klient CreateKlient(string id, string nrtel, string email);
}