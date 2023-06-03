namespace System_Rezerwacji_Biletow;

public interface IDataProvider<T>
{
    public void LoadData(string path, IManagement<T> management = null); //ZMIANA WZGLEDEM UML, POTRZEBNE NAM SA LOTNISKA W SAMOLOTACH I TRASACH, STAD DRUGI (OPCJONALNY) ARGUMENT.
    public void SaveData(string path);
}