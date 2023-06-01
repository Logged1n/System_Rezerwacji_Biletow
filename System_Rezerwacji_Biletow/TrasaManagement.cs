namespace System_Rezerwacji_Biletow;

public class TrasaManagement : ITrasaManagement
{
    private List<Trasa>? _trasy;

    public TrasaManagement()
    {
        LoadData("trasy.txt");
        _trasy = new List<Trasa>();
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

    public void LoadData(string path) // odczyt tras do zaimplementowania
    {
    }

    public void SaveData(string path) // zapis tras do zaimplementowania
    {
    }
}