namespace System_Rezerwacji_Biletow;

public class RezerwacjaManagment: IManagement<Rezerwacja>, IDataProvider
{
    private List<Rezerwacja> _rezerwacje;
    private static RezerwacjaManagment _instance;
    public void Dodaj(Rezerwacja rezerwacja)
    {
        foreach (Rezerwacja r in _rezerwacje)
        {
            if (r.Id == rezerwacja.Id)
            {
                return;
            }
        }

        _rezerwacje.Add(rezerwacja);
    }

    public void Usun(Rezerwacja rezerwacja)
    {
        foreach (Rezerwacja r in _rezerwacje)
        {
            if (r.Id == rezerwacja.Id)
            {
                _rezerwacje.Remove(rezerwacja);
            }
        }
    }

    public Rezerwacja GetSingle(string id)
    {
        foreach (Rezerwacja r in _rezerwacje)
        {
            if (r.Id == id)
            {
                return r;
            }

            return null;
    }

    public List<Rezerwacja> GetList()
    {
        return _rezerwacje;
    }

    public void LoadData(string path)
    {
        throw new NotImplementedException();
    }

    public void SaveData(string path)
    {
        throw new NotImplementedException();
    }
}