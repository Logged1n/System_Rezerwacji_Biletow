namespace System_Rezerwacji_Biletow;

public class SamolotManagement : ISamolotManagement
{
    private readonly List<Samolot> _samoloty;
    private static SamolotManagement _instance;

    private SamolotManagement()
    {
        
        _samoloty = new List<Samolot>();
    }
    public static SamolotManagement GetInstance()
    {
        if(_instance == null)
        {
            _instance = new SamolotManagement();
        }
        return _instance;
    }
    public void Dodaj(Samolot item)
    {
        //TODO, sprawdzicz czy przypadkiem dodajesz samolotu, ktory jest juz na liscie
        throw new NotImplementedException();
    }

    public void Usun(Samolot item)
    {
        //TODO obsluga bledu jak nie znajdziesz tego samolotu do usuniecia
        throw new NotImplementedException();
    }

    public Samolot GetSingle(string id)
    {
        //TODO obsluga bledu jezeli nie znajdziesz samolotu o takim id
        throw new NotImplementedException();
    }

    public List<Samolot> GetList()
    {
        throw new NotImplementedException();
    }

    public void LoadData(string path)
    {
        //TODO
        throw new NotImplementedException();
    }

    public void SaveData(string path)
    {
        //TODO
        throw new NotImplementedException();
    }

    public List<Samolot> GetListLotnisko(Lotnisko lotnisko)
    {
        //TODO; obsluga bledu jezeli nie ma takiego lotniska
        throw new NotImplementedException();
    }

    public List<Samolot> GetListZasieg(int zasieg)
    {
        //TODO; obsluga bledu jezeli wprowadzono jakis zasieg na minusie czy cos
        throw new NotImplementedException();
    }
}