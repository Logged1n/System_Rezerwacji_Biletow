namespace System_Rezerwacji_Biletow;

public class LotManagement : ILotManagement
{
    private List<Lot>? _loty;
    private static LotManagement _instance;
    private SamolotManagement _samolotManagement;
    private TrasaManagement _trasaManagement;

    private LotManagement()
    {
        _loty = new List<Lot>();
        _samolotManagement = SamolotManagement.GetInstance();
        _trasaManagement = TrasaManagement.GetInstance();
    }

    public static LotManagement GetInstance()
    {
        if (_instance == null)
        {
            _instance = new LotManagement();
        }

        return _instance;
    }

    public void LoadData(string path)
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