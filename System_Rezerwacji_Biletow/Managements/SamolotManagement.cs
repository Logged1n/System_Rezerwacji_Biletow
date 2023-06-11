namespace System_Rezerwacji_Biletow.Managements;
using Exceptions;
using Interfaces;
using Samolot;

public class SamolotManagement : ISamolotManagement, IDataProvider
{
    private readonly List<Samolot> _samoloty;
    private static SamolotManagement _instance;

    private SamolotManagement()
    {
        
        _samoloty = new List<Samolot>();
    }
    public static SamolotManagement GetInstance() //SINGLETON
    {
        if(_instance == null)
        {
            _instance = new SamolotManagement();
        }
        return _instance;
    }
    public void Dodaj(Samolot samolot)
    {
        _samoloty.Add(samolot);
    }

    public void Usun(Samolot samolot)
    {
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
            
            while (reader.ReadLine() is { } line)
            {
                splitedLine = line.Split(";");
                if (splitedLine[0][0] == 'R')
                {
                    _instance.Dodaj(regionalnyFactory.CreateSamolot(LotniskoManagement.GetInstance().GetSingle(splitedLine[1])));
                }
                else if (splitedLine[0][0] == 'W')
                {
                    _instance.Dodaj(waskokadlubowyFactory.CreateSamolot(LotniskoManagement.GetInstance().GetSingle(splitedLine[1])));
                }
                else if (splitedLine[0][0] == 'S')
                {
                    _instance.Dodaj(szerokokadlubowyFactory.CreateSamolot(LotniskoManagement.GetInstance().GetSingle(splitedLine[1])));
                }
            }
        }

    }

    public void SaveData(string path)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Samolot samolot in _samoloty)
                {
                    sw.WriteLine($"{samolot.Id[0]};{samolot.PoczatkoweLotnisko.Nazwa}");
                }
            }
        }
        catch
        {
            throw new NieUdaloSieZapisacPlikuException();
        }
    }


    public List<Samolot> GetListLotnisko(Lotnisko lotnisko) //Metoda zwracajaca liste wszystkich samolotow wylatujacych z danego lista ~uzywana w LotPlaner
    {
        List<Samolot> _samolociki = new List<Samolot>();
        foreach (Samolot samolot in _samoloty)
        {
            if (samolot.PoczatkoweLotnisko == lotnisko)
            {
                _samolociki.Add(samolot);
            }
        }
        return _samolociki;
    }
    
    public void Reset() => _samoloty.Clear(); // do testow jednostkowych
}