namespace System_Rezerwacji_Biletow;

public interface IManagement<T>
{
    public void Dodaj(T item);
    public void Usun(T item);
    public T GetSingle(string id);
    public List<T> GetList();
}