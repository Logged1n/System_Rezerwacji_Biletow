namespace System_Rezerwacji_Biletow;

public interface IDataProvider // interfejs odpowiedzialny za odczyt i zapis danych na dysku
{
    public void LoadData(string path);
    public void SaveData(string path);
}