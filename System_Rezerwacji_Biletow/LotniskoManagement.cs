namespace System_Rezerwacji_Biletow;

public class LotniskoManagement : IManagement<Lotnisko>, IDataProvider<Lotnisko>
{
    private List<Lotnisko>? _lotniska;

    public void Dodaj(Lotnisko item)
    {
        throw new NotImplementedException();
    }

    public void Usun(Lotnisko item)
    {
        throw new NotImplementedException();
    }

    public Lotnisko GetSingle(string miasto)
    {
        foreach (Lotnisko l in _lotniska)
        {
            if (l.GetMiasto() == miasto)
                return l;
        }

        return null; // obsluga bledu jak nie znajdzie lotniska o takim miescie
    }

    public List<Lotnisko> GetList()
    {
        throw new NotImplementedException();
    }

    public void LoadData(string path, IManagement<Lotnisko> management = null)
    {
        throw new NotImplementedException();
    }
    
    public void SaveData(string path)
    {
        throw new NotImplementedException();
    }
}