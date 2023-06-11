namespace System_Rezerwacji_Biletow.Managements;
using Exceptions;
using Interfaces;
using Klient;

public class KlientManagement: IManagement<Klient>, IDataProvider
{
    private readonly List<Klient> _klienci;
    private static KlientManagement _instance;

    private KlientManagement()
    {
        _klienci = new List<Klient>();
    }

    public static KlientManagement GetInstance() //SINGLETON
    {
        if (_instance == null)
        {
            _instance = new KlientManagement();
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
            KlientIndywidualnyFactory indywidualnyFactory = new KlientIndywidualnyFactory();
            KlientFirmaFactory firmaFactory = new KlientFirmaFactory();
            using (StreamReader reader = new StreamReader(path))
            {
                string[] splitedLine;
                
                while (reader.ReadLine() is { } line)
                {
                    splitedLine = line.Split(";");
                    if (splitedLine[0][0] == 'F')
                    {
                        Dodaj(firmaFactory.CreateKlient(splitedLine[1], splitedLine[2], splitedLine[3]));
                    }
                    else if (splitedLine[0][0]=='I')
                    {
                        Dodaj(indywidualnyFactory.CreateKlient(splitedLine[1], splitedLine[2], splitedLine[3], splitedLine[4]));
                    }
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

    public void Reset() => _klienci.Clear(); // do testow jednostkowych
    
}