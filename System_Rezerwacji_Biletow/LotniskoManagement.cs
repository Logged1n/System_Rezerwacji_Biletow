namespace System_Rezerwacji_Biletow;

public class LotniskoManagement : IManagement<Lotnisko>, IDataProvider
{
    private List<Lotnisko> _lotniska;
    private static LotniskoManagement _instance;

    private LotniskoManagement()
    {
        _lotniska = new List<Lotnisko>();
    }

    public static LotniskoManagement GetInstance()
    {
        if (_instance == null)
        {
            _instance = new LotniskoManagement();
        }
        return _instance;
    }
    public void Dodaj(Lotnisko item)
    {
        //TODO Dodac sprawdzenie czy nazwa lotniska sie juz przypadkiem nie powtorzyla
        _lotniska.Add(item);
    }

    public void Usun(Lotnisko item)
    {
        throw new NotImplementedException();
    }

    public Lotnisko GetSingle(string nazwa)
    {
        foreach (Lotnisko l in _lotniska)
        {
            if (l.Nazwa == nazwa)
                return l;
        }

        return null; //TODO obsluga bledu jak nie znajdzie lotniska o takim miescie
    }

    public List<Lotnisko> GetList()
    {
        //TODO
        throw new NotImplementedException();
    }

    public void LoadData(string path)
    {
        //TODO obsluga bledow, nie udalo odczytac sie pliku; <-- jak sie odpali to poinformowac jakos uzytkownika ze stan systemu nie mogl zostac wczytany
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            string[] splitedLine;
            string kraj, miasto, nazwa;
            while ((line = reader.ReadLine()) != null)
            {
                splitedLine = line.Split(";");
                kraj = splitedLine[0];
                miasto = splitedLine[1];
                nazwa = splitedLine[2];
                Lotnisko l = new Lotnisko(kraj, miasto, nazwa);
                Dodaj(l);
            }
        }
    }
    
    public void SaveData(string path)
    {
        //TODO
        throw new NotImplementedException();
    }
}