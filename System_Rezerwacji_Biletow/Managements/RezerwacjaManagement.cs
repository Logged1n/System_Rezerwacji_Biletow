namespace System_Rezerwacji_Biletow.Managements;
using Exceptions;
using Interfaces;
using Rezerwacja;
public class RezerwacjaManagement: IDataProvider, IManagement<Rezerwacja>
{
    private readonly List<Rezerwacja> _Rezerwacje;
    private static RezerwacjaManagement _instance;
    private RezerwacjaManagement()
    {
        _Rezerwacje = new List<Rezerwacja>();
    }

    public static RezerwacjaManagement GetInstance()
    {
        if (_instance == null)
        {
            _instance = new RezerwacjaManagement();
        }

        return _instance;
    }
    public void LoadData(string path)
    {
        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string[] splitedLine;
                while (reader.ReadLine() is { } line)
                {
                    splitedLine = line.Split(";");
                    Rezerwacja r = new Rezerwacja(KlientManagement.GetInstance().GetSingle(splitedLine[0]), LotManagement.GetInstance().GetSingle(splitedLine[1]));
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
                foreach (Rezerwacja r in _Rezerwacje)
                {
                    sw.WriteLine($"{r.Klient.Id};{r.Lot.NumerLotu}");
                }
            }
        }
        catch
        {
            throw new NieUdaloSieZapisacPlikuException();
        }
    }

    public void Dodaj(Rezerwacja rezerwacja)
    {
        foreach (Rezerwacja r in _Rezerwacje)
        {
            if (r.Id == rezerwacja.Id)
            {
                throw new TakaRezerwacjaJuzIstniejeException();
            }
        }
        _Rezerwacje.Add(rezerwacja);
    }

    public void Usun(Rezerwacja rezerwacja)
    {
        foreach (Rezerwacja r in _Rezerwacje)
        {
            if (r.Id == rezerwacja.Id)
            {
                _Rezerwacje.Remove(r);
            }
        }

        throw new BrakRezerwacjiException();
    }

    public Rezerwacja GetSingle(string id)
    {
        foreach (Rezerwacja r in _Rezerwacje)
        {
            if (r.Id == id)
            {
                return r;
            }
        }

        throw new BrakRezerwacjiException();
    }

    public List<Rezerwacja> GetList()
    {
        return _Rezerwacje;
    }
    public void Reset() => _Rezerwacje.Clear(); // do testow jednostkowych
}