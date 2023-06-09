using System_Rezerwacji_Biletow.Interfaces;

namespace System_Rezerwacji_Biletow;

public class KlientManagment: IKlientManagment, IDataProvider
{
    private readonly List<Klient> _klienci;
    private static KlientManagment _instance;

    private KlientManagment()
    {
        _klienci = new List<Klient>();
    }

    public static KlientManagment GetInstance()
    {
        if (_instance == null)
        {
            _instance = new KlientManagment();
        }

        return _instance;
    }

    public void Dodaj(Klient klient)
    {
        foreach (Klient k in _klienci)
        {
            if (k.Id == klient.Id)
            {
                return;
            }
        }
        _klienci.Add(klient);
    }

    public void Usun(Klient klient)
    {
        foreach (Klient k in _klienci)
        {
            if (k.Id == klient.Id)
            {
                _klienci.Remove(k);
            }
        }
    }
    
    public void LoadData(string path)
    {
        throw new NotImplementedException();
    }

    public void SaveData(string path)
    {
        throw new NotImplementedException();
    }
}