namespace System_Rezerwacji_Biletow.Klient;

using Interfaces;
public class KlientFirmaFactory: IKlientFactory
{
    public Klient CreateKlient(string numerTelefonu, string email, string firma, string dodatkowePole2 = null)
    {
        return new KlientFirma(numerTelefonu, email, firma);
    }
}