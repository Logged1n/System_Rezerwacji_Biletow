namespace System_Rezerwacji_Biletow.Managements;
using Exceptions;

public class SamolotManagement : ISamolotManagement, IDataProvider
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
    public void Dodaj(Samolot samolot)
    {
        foreach (var s in _samoloty)
        {
            if (s.Zasieg == samolot.Zasieg && s.IloscMiejsc == samolot.IloscMiejsc)
                throw new NotImplementedException();
        }
        //TODO, sprawdzicz czy przypadkiem dodajesz samolotu, ktory jest juz na liscie
        
      _samoloty.Add(samolot);
    }

    public void Usun(Samolot samolot)
    {
        //TODO obsluga bledu jak nie znajdziesz tego samolotu do usuniecia
        try
        {
            _samoloty.Remove(samolot);
        }
        catch
        {
            throw new NotImplementedException(); 
        }

    }

    public Samolot GetSingle(string id)
    {
        //TODO obsluga bledu jezeli nie znajdziesz samolotu o takim id
        foreach (var s in _samoloty)
        {
            if (s.Id == id)
                return s;
        }

        return null;
    }

    public List<Samolot> GetList()
    {
        return _samoloty;
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
    
}