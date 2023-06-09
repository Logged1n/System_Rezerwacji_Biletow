namespace System_Rezerwacji_Biletow.Interfaces;

public interface IManagement<T> // generyczny interfejs zarzadzania obiektami T
{
    public void Dodaj(T item);
    public void Usun(T item);
    public T GetSingle(string id);
    public List<T> GetList();
}