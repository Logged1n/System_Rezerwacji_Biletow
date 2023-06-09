namespace System_Rezerwacji_Biletow.Managements;
using Exceptions;
using Interfaces;
using Klient;
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
                throw new TakiKlientJuzIstniejeException();
            }
        }
        _klienci.Add(klient);
    }

    public void Usun(Klient klient)
    {
        try
        {
            _klienci.Remove(klient);
        }
        catch
        {
            throw new BrakKlientaException();
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

        throw new BrakKlientaException();

    }

    public List<Klient> GetList()
    {
        return _klienci;
    }

    public void LoadData(string path)
    {
        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string[] splitedLine;
                while (reader.ReadLine() is { } line)
                {
                    splitedLine = line.Split(";");
                   
                }
            }
        }
        catch
        {
            throw new NieUdaloSieOdczytacPlikuException();
        }
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