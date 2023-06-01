namespace System_Rezerwacji_Biletow;

public interface IDataProvider
{
    public void LoadData(string path);
    public void SaveData(string path);
}