namespace System_Rezerwacji_Biletow.Managements;
using Exceptions;
using Interfaces;

public class TrasaManagement : IManagement<Trasa>, IDataProvider
{
    private readonly List<Trasa> _trasy;
    private static TrasaManagement _instance;

    private TrasaManagement()
    {
        _trasy = new List<Trasa>();
    }

    public static TrasaManagement GetInstance()  // SINGLETON, tak jak w kazdym managemencie. Chcemy mieć dokładnie 1 obiekt klasy XManagement.
    {
        if (_instance == null)
        {
            _instance = new TrasaManagement();
        }

        return _instance;
    }
    public void Dodaj(Trasa trasa)
    {
        foreach (var t in _trasy) // sprawdzenie czy nie ma juz trasy, ktora chcemy dodac
        {
            if (t.Start.Nazwa == trasa.Start.Nazwa && t.Cel.Nazwa == trasa.Cel.Nazwa)
                throw new TakaTrasaJuzIstniejeException();
        }
        _trasy.Add(trasa);
    }

    public void Usun(Trasa trasa)
    {
        try
        {
            _trasy.Remove(trasa);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "Nie usunieto podanej trasy.");
        }
    }

    public List<Trasa> GetList()
    {
        return _trasy;
    }

    public Trasa GetSingle(string id)
    {
        foreach (Trasa t in _trasy)
        {
            if (t.Id == id)
                return t;
        }

        throw new BrakTrasyException();
    }

    public void LoadData(string path)
    {
        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string[] splitedLine;
                int dystans;
                while (reader.ReadLine() is { } line)
                {
                    splitedLine = line.Split(";");
                    var start = LotniskoManagement.GetInstance().GetSingle(splitedLine[0]);
                    var cel = LotniskoManagement.GetInstance().GetSingle(splitedLine[1]);
                    dystans = Convert.ToInt32(splitedLine[2]);
                    Trasa t = new Trasa(start, cel, dystans);
                    Dodaj(t);
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
                foreach (Trasa t in _trasy)
                {
                    sw.WriteLine($"{t.Start.Nazwa};{t.Cel.Nazwa};{t.Dystans}");
                }
            }
        }
        catch
        {
            throw new NieUdaloSieZapisacPlikuException();
        }
    }
    public void Reset() => _trasy.Clear(); // do testow jednostkowych
}