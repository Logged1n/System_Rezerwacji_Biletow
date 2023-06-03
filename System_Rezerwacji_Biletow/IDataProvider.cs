namespace System_Rezerwacji_Biletow;

public interface IDataProvider
{
    public void LoadData(string path, LotniskoManagement lotniskoManagement = null); //ZMIANA WZGLEDEM UML, POTRZEBNE NAM SA LOTNISKA W SAMOLOTACH I TRASACH, STAD DRUGI (OPCJONALNY) ARGUMENT.
    public void SaveData(string path);
}