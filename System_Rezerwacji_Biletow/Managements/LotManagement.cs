namespace System_Rezerwacji_Biletow.Managements;
using Interfaces;
using Samolot;
using Lot;
using Exceptions;

public class LotManagement : ILotManagement, IDataProvider
{
    private readonly List<Lot> _loty;
    private static LotManagement _instance;


    private LotManagement()
    {
        _loty = new List<Lot>();
    }

    public static LotManagement GetInstance() //SINGLETON
    {
        if (_instance == null)
        {
            _instance = new LotManagement();
        }

        return _instance;
    }

    public void LoadData(string path)
    {
        LotPasazerskiBuilder _lotBuilder = new LotPasazerskiBuilder();
        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string[] splitedLine;
                while (reader.ReadLine() is { } line)
                {
                    splitedLine = line.Split(";");
                    _lotBuilder.Reset();
                    _lotBuilder.SetNumerLotu(Convert.ToString(_loty.Count));
                    _lotBuilder.SetTrasa(TrasaManagement.GetInstance().GetSingle(splitedLine[0]));
                    _lotBuilder.SetSamolot(SamolotManagement.GetInstance().GetSingle(splitedLine[1]));
                    _lotBuilder.SetDataOdlotu(DateTime.Parse(splitedLine[2]));
                    _lotBuilder.SetDataPowrotu(DateTime.Parse(splitedLine[3]));
                   _lotBuilder.SetCzestotliwoscLotu(Enum.Parse<Czestotliwosc>(splitedLine[4]));
                   _lotBuilder.Build();
                }
            }
        }
        catch(Exception ex)
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
                    sw.WriteLine($"{l.Trasa.Id};{l.Samolot.Id};{l.DataOdlotu};{l.DataPowrotu};{l.CzestotliwoscLotu}");
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

    public bool CzySamolotWolny(Samolot samolot, DateTime dataOdlotu, DateTime dataPowrotu) // metoda sprawdzajaca, czy dany samolot jest wolny miedzy dwiema podanymi datami, z uwzglednieniem czestotliwosci lotow
    {
        foreach (var lot in _loty)
        {
            if (lot.Samolot == samolot)
            {
                switch (lot.CzestotliwoscLotu)
                {
                    case Czestotliwosc.Jednorazowy:
                    {
                        if (dataOdlotu <= lot.DataOdlotu || dataPowrotu >= lot.DataPowrotu)
                            return false;
                        break;
                    }
                    case Czestotliwosc.Codzienny:
                    {
                        for (DateTime data = lot.DataOdlotu; data < lot.DataPowrotu; data = data.AddDays(1))
                        {
                            if (dataOdlotu <= data || dataPowrotu >= data)
                                return false;
                        }

                        break;
                    }
                    case Czestotliwosc.Cotygodniowy:
                    {
                        for (DateTime data = lot.DataOdlotu; data < lot.DataPowrotu; data = data.AddDays(7))
                        {
                            if (dataOdlotu <= data || dataPowrotu >= data)
                            {
                                return false;
                            }
                        }

                        break;
                    }
                    case Czestotliwosc.Comiesieczny:
                    {
                        for(DateTime data = lot.DataOdlotu; data < lot.DataPowrotu; data = data.AddMonths(1))
                        {
                            if(dataOdlotu <= data || dataPowrotu >= data)
                            {
                                return false;
                            }
                        }

                        break;
                    }
                }
            }
        }
        return true;
    }
    public void Reset() => _loty.Clear(); // do testow jednostkowych

}