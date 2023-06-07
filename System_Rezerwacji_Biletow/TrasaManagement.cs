namespace System_Rezerwacji_Biletow;

public class TrasaManagement : IManagement<Trasa>, IDataProvider
{
    private readonly List<Trasa>? _trasy;
    private static TrasaManagement _instance; // ZMIANA WZGLEDEM UML
    private readonly LotniskoManagement _lotniskoManagement;

    private TrasaManagement()
    {
        _trasy = new List<Trasa>();
        _lotniskoManagement = LotniskoManagement.GetInstance();
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
                start = _lotniskoManagement.GetSingle(splitedLine[1]);
                cel = _lotniskoManagement.GetSingle(splitedLine[2]);
                dystans = Convert.ToInt32(splitedLine[3]);
                Trasa t = new Trasa(id, start, cel, dystans);
                this.Dodaj(t);
            }
        }
    }

    public void SaveData(string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach (Trasa t in _trasy)
            {
                sw.WriteLine($"{t.Id};{t.Start.Nazwa}{t.Cel.Nazwa};{t.Dystans}");
            }
        }
    }
}