namespace System_Rezerwacji_Biletow;

public class KlientFirmaFactory: IKlientFactory
{
    public Klient CreateKlient(string id, string numerTelefonu, string email, string dodatkowePole1, string dodatkowePole2 = null)
    {
        return new KlientFirma(id, numerTelefonu, email, dodatkowePole1);
    }
}