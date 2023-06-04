namespace System_Rezerwacji_Biletow;

public class SamolotManagement : ISamolotManagement
{
    private List<Samolot> _samoloty;
    private static SamolotManagement _instance;

    private SamolotManagement()
    {
        _samoloty = new List<Samolot>();
    }
    public static SamolotManagement GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SamolotManagement();
        }
        return _instance;
    }
    public void Dodaj(Samolot item)
    {
        throw new NotImplementedException();
    }

    public void Usun(Samolot item)
    {
        throw new NotImplementedException();
    }

    public Samolot GetSingle(string id)
    {
        throw new NotImplementedException();
    }

    public List<Samolot> GetList()
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

    public List<Samolot> GetListLotnisko(Lotnisko lotnisko)
    {
        throw new NotImplementedException();
    }

    public List<Samolot> GetListZasieg(int zasieg)
    {
        throw new NotImplementedException();
    }
}