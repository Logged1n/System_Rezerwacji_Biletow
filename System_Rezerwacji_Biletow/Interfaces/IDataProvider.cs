namespace System_Rezerwacji_Biletow.Interfaces;

public interface IDataProvider // interfejs odpowiedzialny za odczyt i zapis danych
{
    public void LoadData(string path);
    public void SaveData(string path);
}