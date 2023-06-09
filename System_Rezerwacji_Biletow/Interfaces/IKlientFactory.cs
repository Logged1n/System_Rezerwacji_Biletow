namespace System_Rezerwacji_Biletow.Interfaces;

using Klient;
public interface IKlientFactory // interfejs fabryk klientow ~wzorzec projektowy
{
    public Klient CreateKlient(string numerTelefonu, string email, string dodatkowePole1, string dodatkowePole2 = null);
}