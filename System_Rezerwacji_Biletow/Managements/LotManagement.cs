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
        try
        {
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
                foreach (Lot l in _loty)
                {
                    sw.WriteLine($"{l.NumerLotu};{l.Trasa.Id}{l.Samolot.Id};{l.DataOdlotu};{l.DataPowrotu}");
                }
            }
        }
        catch
        {
            throw new NieUdaloSieZapisacPlikuException();
        }
    }

    public void Dodaj(Lot lot)
    {
        foreach (var l in _loty)
        {
            if (lot.NumerLotu == l.NumerLotu)
                throw new TakiLotJuzIstniejeException();
        }
        _loty.Add(lot);
    }

    public void Usun(Lot lot)
    {
        try
        {
            _loty.Remove(lot);
        }
        catch
        {
            throw new BrakLotuException();
        }
    }

    public List<Lot> GetList()
    {
        return _loty;
    }

    public Lot GetSingle(string numerLotu)
    {
        foreach (Lot l in _loty)
        {
            if (l.NumerLotu == numerLotu)
            {
                return l;
            }
        }

        throw new BrakLotuException();
    }

    public bool CzySamolotWolny(Samolot samolot, DateTime dataOdlotu, DateTime dataPowrotu)
    {
        foreach (var lot in _loty)
        {
            if (lot.Samolot == samolot && dataOdlotu >= lot.DataOdlotu && dataOdlotu <= lot.DataPowrotu || dataPowrotu >= lot.DataOdlotu && dataPowrotu <= lot.DataPowrotu)
            {
                return false;
            }
        }
        return true;
    }
}