namespace System_Rezerwacji_Biletow;

public class TrasaManagement : IManagement<Trasa>, IDataProvider
{
    private readonly List<Trasa> _trasy;
    private static TrasaManagement _instance; // ZMIANA WZGLEDEM UML

    private TrasaManagement()
    {
        _trasy = new List<Trasa>();
    }

    public static TrasaManagement GetInstance() // SINGLETON, kazego mangementu chcemy miec dokldnie jedna instancje
    {
        if (_instance == null)
        {
            _instance = new TrasaManagement();
        }

        return _instance;
    }
    public void Dodaj(Trasa trasa)
    {
        //sprawdzenie czy nie ma juz tej trasy na liscie
        _trasy.Add(trasa);
    }

    public void Usun(Trasa trasa)
    {
        _trasy.Remove(trasa);
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
        return null; // tu obsluga wyjatku jak nie znajdzie odpowiedniego id, ewentualnie wczesniej jakas walidacja
    }

    public void LoadData(string path)
    {
        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                string[] splitedLine;
                string id;
                Lotnisko start, cel;
                int dystans;
                while ((line = reader.ReadLine()) != null)
                {
                    splitedLine = line.Split(";");
                    id = splitedLine[0];
                    start = LotniskoManagement.GetInstance().GetSingle(splitedLine[1]);
                    cel = LotniskoManagement.GetInstance().GetSingle(splitedLine[2]);
                    dystans = Convert.ToInt32(splitedLine[3]);
                    Trasa t = new Trasa(id, start, cel, dystans);
                    this.Dodaj(t);
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
                    sw.WriteLine($"{t.Id};{t.Start.Nazwa}{t.Cel.Nazwa};{t.Dystans}");
                }
            }
        }
        catch
        {
            throw new NieUdaloSieZapisacPlikuException();
        }
    }
}