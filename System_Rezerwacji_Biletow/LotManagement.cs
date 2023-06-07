namespace System_Rezerwacji_Biletow;

public class LotManagement : ILotManagement, IDataProvider
{
    private readonly List<Lot> _loty;
    private static LotManagement _instance;
   

    private LotManagement()
    {
        _loty = new List<Lot>();
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
        //TODO obsluga bledow, nie udalo odczytac sie pliku; trasamangment nie wczytany; samolotmanagement nie wczytany;
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            string[] splitedLine;
            string numerLotu;
            Trasa trasa;
            Samolot samolot;
            DateTime dataOdlotu, dataPowrotu;
            while ((line = reader.ReadLine()) != null)
            {
                splitedLine = line.Split(";");
                numerLotu = splitedLine[0];
                trasa = TrasaManagement.GetInstance().GetSingle(splitedLine[1]);
                samolot = SamolotManagement.GetInstance().GetSingle(splitedLine[2]);
                dataOdlotu = DateTime.Parse(splitedLine[3]);
                dataPowrotu = DateTime.Parse(splitedLine[4]);
                Dodaj(new Lot(numerLotu, trasa, samolot, dataOdlotu, dataPowrotu));
            }
        }
    }

    public void SaveData(string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach (Lot l in _loty)
            {
                sw.WriteLine($"{l.NumerLotu};{l.Trasa.Id}{l.Samolot.Id};{l.DataOdlotu};{l.DataPowrotu}");
            }
        }
    }

    public void Dodaj(Lot lot)
    {
        //TODO sprawdzic czy przypadkiem nie ma juz lotu ktory chcemy dodac
        _loty.Add(lot);
    }

    public void Usun(Lot lot)
    {
        //TODO obsluga bledu, jezeli nie znaleziono tego lotu na liscie
        _loty.Remove(lot);
    }

    public List<Lot> GetList()
    {
        return _loty;
    }

    public Lot GetSingle(string numerLotu)
    {
        //TODO obsluga bledu, jezeli nie znaleziono lotu o takim numerze
        foreach (Lot l in _loty)
        {
            if (l.NumerLotu == numerLotu)
            {
                return l;
            }
        }
        return null;
    }

    public bool CzySamolotWolny(Samolot samolot, DateTime dataOdlotu, DateTime dataPowrotu)
    {
        //TODO
        throw new NotImplementedException();
    }
}