namespace System_Rezerwacji_Biletow;

public interface IKlientManagment : IManagement<Klient>, IDataProvider
{
    public List<Klient> Get
}