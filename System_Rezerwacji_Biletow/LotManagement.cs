namespace System_Rezerwacji_Biletow;

public class LotManagement : ILotManagement, IDataProvider
{
    private readonly List<Lot> _loty;
    private static LotManagement _instance;
    private readonly SamolotManagement _samolotManagement;
    private readonly TrasaManagement _trasaManagement;

    private LotManagement()
    {
        _loty = new List<Lot>();
        _samolotManagement = SamolotManagement.GetInstance();
        _trasaManagement = TrasaManagement.GetInstance();
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
        using (StreamReader reader = new StreamReader(path))
        {
            string[] line;
            string numerLotu;
            Trasa trasa;
            Samolot samolot;
            DateTime dataOdlotu, dataPowrotu;
            while ((line = reader.ReadLine().Split(";")) != null)
            {
                numerLotu = line[0];
                trasa = _trasaManagement.GetSingle(line[1]);
                samolot = _samolotManagement.GetSingle(line[2]);
                dataOdlotu = DateTime.Parse(line[3]);
                dataPowrotu = DateTime.Parse(line[4]);
                this.Dodaj(new Lot(numerLotu, trasa, samolot, dataOdlotu, dataPowrotu));
            }
        }
    }

    public void SaveData(string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach (Lot l in _loty)
            {
                sw.WriteLine($"{l.NumerLotu};{l.Trasa.Id}{l.Samolot.GetId()};{l.DataOdlotu};{l.DataPowrotu}");
            }
        }
    }

    public void Dodaj(Lot lot)
    {
        _loty.Add(lot);
    }

    public void Usun(Lot lot)
    {
        _loty.Remove(lot);
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
        return null;
    }

    public bool CzySamolotWolny(Samolot samolot, DateTime dataOdlotu, DateTime dataPowrotu)
    {
        throw new NotImplementedException();
    }
}