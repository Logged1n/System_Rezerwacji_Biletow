namespace System_Rezerwacji_Biletow;

public class RezerwacjaManagment: IDataProvider, IManagement<Rezerwacja>
{
    private List<Rezerwacja> _Rezerwacje;
    public void LoadData(string path)
    {
        throw new NotImplementedException();
    }

    public void SaveData(string path)
    {
        throw new NotImplementedException();
    }

    public void Dodaj(Rezerwacja rezerwacja)
    {
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

        return null;
    }

    public List<Rezerwacja> GetList()
    {
        return _Rezerwacje;
    }
}