namespace System_Rezerwacji_Biletow.Managements;
using Exceptions;
using Interfaces;

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
    public void Dodaj(Lotnisko lotnisko)
    {
        foreach (var l in _lotniska)
        {
            if (l.Nazwa == lotnisko.Nazwa)
                throw new TakieLotniskoJuzIstniejeException();
        }
        _lotniska.Add(lotnisko);
    }

    public void Usun(Lotnisko lotnisko)
    {
        try
        {
            _lotniska.Remove(lotnisko);
        }
        catch
        {
            throw new BrakLotniskaException();
        }
    }

    public Lotnisko GetSingle(string nazwa)
    {
        foreach (Lotnisko l in _lotniska)
        {
            if (l.Nazwa == nazwa)
                return l;
        }

        throw new BrakLotniskaException();
    }

    public List<Lotnisko> GetList()
    {
        return _lotniska;
    }

    public void LoadData(string path)
    {
        try
        {
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
                foreach (Lotnisko lotnisko in _lotniska)
                {
                    sw.WriteLine(lotnisko);
                }
            }
        }
        catch
        {
            throw new NieUdaloSieZapisacPlikuException();
        }
    }
}