namespace System_Rezerwacji_Biletow.Klient;
using Interfaces;

public class KlientFirmaFactory: IKlientFactory
{
    public Klient CreateKlient(string numerTelefonu, string email, string firma, string dodatkowePole2 = null) //z fabryki moze juz skorzystac kazda klasa
    {
        return new KlientFirma(numerTelefonu, email, firma);
    }
}