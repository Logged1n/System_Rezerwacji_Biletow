namespace System_Rezerwacji_Biletow.Managements;
using Exceptions;

public class RezerwacjaManagment: IDataProvider, IManagement<Rezerwacja>
{
    private List<Rezerwacja> _Rezerwacje;
    public void LoadData(string path)
    {
        throw new NotImplementedException();
    }

    public void SaveData(string path)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Rezerwacja r in _Rezerwacje)
                {
                    sw.WriteLine(r);
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
}