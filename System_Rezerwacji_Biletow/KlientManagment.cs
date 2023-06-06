namespace System_Rezerwacji_Biletow;

public class KlientManagment: IKlientManagment
{
    private List<Klient> _klienci;
    private static KlientManagment _instance;
    public KlientManagment()
    {
        _klienci = new List<Klient>();
    }
}