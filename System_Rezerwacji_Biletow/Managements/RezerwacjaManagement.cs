using System_Rezerwacji_Biletow.Klient;

namespace System_Rezerwacji_Biletow.Managements;
using Exceptions;
using Interfaces;
using Rezerwacja;
public class RezerwacjaManagement: IDataProvider, IManagement<Rezerwacja>
{
    private readonly List<Rezerwacja> _Rezerwacje;
    private static RezerwacjaManagement _instance;
    public static int IloscRezerwacji { get; private set; }// usuniecie cyklicznego odwolania przy nadawaniu ID

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
                    Dodaj(new Rezerwacja(KlientManagement.GetInstance().GetSingle(splitedLine[0]), LotManagement.GetInstance().GetSingle(splitedLine[1])));
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
        int i = 0;
        foreach (var r in _Rezerwacje)
        {
            if (r.Lot == rezerwacja.Lot)
                i++;
        }

        if (rezerwacja.Lot.Samolot.IloscMiejsc > i)
        {
            IloscRezerwacji++;  
            _Rezerwacje.Add(rezerwacja);
        }
        else
        {
            {
                throw new SamolotPelnyException();
            }
        }
        
    }

    public void Usun(Rezerwacja rezerwacja)
    {
        var lista = new List<Rezerwacja>(_Rezerwacje);
        foreach (Rezerwacja r in lista)
        {
            if (r.Id == rezerwacja.Id)
            {
                _Rezerwacje.Remove(r);
                IloscRezerwacji--;
                return;
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