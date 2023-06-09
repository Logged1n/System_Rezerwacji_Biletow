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
        foreach (Samolot s in _samoloty)
        {
            if (s.Id == samolot.Id)
                throw new TakiSamolotJuzIstniejeException();
        }

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
            throw new BrakOdpowiedniegoSamolotuException(); 
        }

    }

    public Samolot GetSingle(string id)
    {
        //TODO obsluga bledu jezeli nie znajdziesz samolotu o takim id
        foreach (Samolot s in _samoloty)
        {
            if (s.Id == id)
                return s;
        }
        throw new BrakOdpowiedniegoSamolotuException();
    }

    public List<Samolot> GetList()
    {
        return _samoloty;
    }

    public void LoadData(string path)
    {
        SamolotRegionalnyFactory regionalnyFactory = new SamolotRegionalnyFactory();
        SamolotWaskokadlubowyFactory waskokadlubowyFactory = new SamolotWaskokadlubowyFactory();
        SamolotSzerokokadlubowyFactory szerokokadlubowyFactory = new SamolotSzerokokadlubowyFactory();
        using (StreamReader reader = new StreamReader(path))
        {
            string[] splitedLine;
            int zasieg, iloscMiejsc;
            while (reader.ReadLine() is { } line)
            {
                splitedLine = line.Split(";");
                
            }
        }
        //TODO
        throw new NotImplementedException();
    }

    public void SaveData(string path)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Samolot samolot in _samoloty)
                {
                    sw.WriteLine(samolot);
                }
            }
        }
        catch
        {
            throw new NieUdaloSieZapisacPlikuException();
        }
    }

    public List<Samolot> GetListLotnisko(Lotnisko lotnisko)
    {
        //TODO; obsluga bledu jezeli nie ma takiego lotniska
        throw new NotImplementedException();
    }
    
}