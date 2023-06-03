namespace System_Rezerwacji_Biletow;

public class LotManagement : ILotManagement
{
    private List<Lot>? _loty;
    private static LotManagement _instance;

    private LotManagement()
    {
        _loty = new List<Lot>();
    }

    public static LotManagement GetInstance()
    {
        if (_instance == null)
        {
            _instance = new LotManagement();
        }

        return _instance;
    }
    
    public void LoadData(string path, IManagement<Lot> management = null)
    {
        throw new NotImplementedException("Use other LoadData() implementation.");
    }

    public void LoadData(string path, SamolotManagement samolotManagement, TrasaManagement trasaManagement)
    {
        throw new NotImplementedException();
    }

    public void SaveData(string path)
    {
        throw new NotImplementedException();
    }

    public void Dodaj(Lot lot)
    {
        throw new NotImplementedException();
    }

    public void Usun(Lot lot)
    {
        throw new NotImplementedException();
    }

    public List<Lot> GetList()
    {
        throw new NotImplementedException();
    }

    public Lot GetSingle(string numerLotu)
    {
        throw new NotImplementedException();
    }

    public bool CzySamolotWolny(Samolot samolot, DateTime dataOdlotu, DateTime dataPowrotu)
    {
        throw new NotImplementedException();
    }
}