namespace System_Rezerwacji_Biletow;

public class TrasaManagement : ITrasaManagement
{
    private List<Trasa>? _trasy;
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
    public void DodajTrase(Trasa trasa)
    {
        _trasy.Add(trasa);
    }

    public void UsunTrase(Trasa trasa)
    {
        _trasy.Remove(trasa);
    }

    public List<Trasa> GetTrasy()
    {
        return _trasy;
    }

    public Trasa GetTrasa(string id)
    {
        foreach (Trasa t in _trasy)
        {
            if (t.GetId() == id)
                return t;
        }
        return null; // tu obsluga wyjatku jak nie znajdzie odpowiedniego id, ewentualnie wczesniej jakas walidacja
    }
    
    /*ZAKLADANY FORMAT PLIKU TXT Z TRASAMI:
     id;startMiastoLotniska;celMiastoLotniska;dystans\n
     trzeba pamietac ze najpierw musimy wczytac lotniska, nastepnie wziac je za pomoca GetLotnisko("miastoLotniska"). Mamy zalozenie, ze miasta lotnisk sie nie powtarzaja.*/

    public void LoadData(string path, LotniskoManagement lotniskoManagement)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            string[] line;
            string id;
            Lotnisko start, cel;
            int dystans;
            while ((line = reader.ReadLine().Split(";")) != null)
            {
                id = line[0];
                start = lotniskoManagement.GetLotnisko(line[1]);
                cel = lotniskoManagement.GetLotnisko(line[2]);
                dystans = Convert.ToInt32(line[3]);
                Trasa t = new Trasa(id, start, cel, dystans);
                _trasy.Add(t);
            }
        }
    }

    public void SaveData(string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach (Trasa t in _trasy)
            {
                sw.WriteLine($"{t.GetId()};{t.GetStart().GetMiasto()}{t.GetCel().GetMiasto()};{t.GetDystans()}\n");
            }
        }
    }
}