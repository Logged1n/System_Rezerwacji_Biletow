namespace System_Rezerwacji_Biletow;

public class LotniskoManagement : IManagement<Lotnisko>, IDataProvider
{
    private List<Lotnisko>? _lotniska;
    private static LotniskoManagement? _instance;

    private LotniskoManagement()
    {
        _lotniska = new List<Lotnisko>();
    }

    public static LotniskoManagement GetInstance()
    {
        if (_instance == null)
        {
            _instance = new LotniskoManagement();
        }
        return _instance;
    }
    public void Dodaj(Lotnisko item)
    {
        throw new NotImplementedException();
    }

    public void Usun(Lotnisko item)
    {
        throw new NotImplementedException();
    }

    public Lotnisko GetSingle(string nazwa)
    {
        foreach (Lotnisko l in _lotniska)
        {
            if (l.Nazwa == nazwa)
                return l;
        }

        return null; // obsluga bledu jak nie znajdzie lotniska o takim miescie
    }

    public List<Lotnisko> GetList()
    {
        throw new NotImplementedException();
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