namespace System_Rezerwacji_Biletow;

public class KlientFirmaFactory: IKlientFactory
{
    public Klient CreateKlient(string id, string nrtel, string email, string firma)
    {
        return new KlientFirma(id, nrtel, email, firma);
    }


    public Klient CreateKlient(string id, string nrtel, string email)
    {
        throw new NotImplementedException();
    }
}