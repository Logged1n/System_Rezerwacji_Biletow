namespace System_Rezerwacji_Biletow;

public class KlientIndywidualnyFactory : IKlientFactory
{
    public Klient CreateKlient(string id, string numerTelefonu, string email, string imie,string nazwisko)
    {
        return new KlientIndywidualny(id, numerTelefonu, email, imie, nazwisko);
    }
}