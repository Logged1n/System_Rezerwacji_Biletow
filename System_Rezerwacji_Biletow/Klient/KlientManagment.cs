using System_Rezerwacji_Biletow.;

namespace System_Rezerwacji_Biletow;

public class KlientManagment: IManagement<Klient>, IDataProvider
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

    public Klient GetSingle(string id)
    {
        foreach (Klient k in _klienci)
        {
            if (k.Id == id)
            {
                return k;
            }
        }

        return null;
    }

    public List<Klient> GetList()
    {
        return _klienci;
    }

    public void LoadData(string path)
    {
        
    }

    public void SaveData(string path)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Klient k in _klienci)
                {
                    sw.WriteLine(k);
                }
            }
        }
        catch
        {
            throw new NieUdaloSieZapisacPlikuException();
        }
    }
}