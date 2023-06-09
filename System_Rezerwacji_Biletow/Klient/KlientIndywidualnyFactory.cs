namespace System_Rezerwacji_Biletow;

public class KlientIndywidualnyFactory : IKlientFactory
{
    public Klient CreateKlient(string numerTelefonu, string email, string imie,string nazwisko)
    {
        return new KlientIndywidualny(numerTelefonu, email, imie, nazwisko);
    }
}