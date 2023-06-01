namespace System_Rezerwacji_Biletow;

public interface ITrasaManagement : IDataProvider
{
    public void DodajTrase(Trasa trasa);
    public void UsunTrase(Trasa trasa);
    public List<Trasa> GetTrasy();
    public Trasa GetTrasa(string id);
}