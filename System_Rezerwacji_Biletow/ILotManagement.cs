namespace System_Rezerwacji_Biletow;

public interface ILotManagement : IManagement<Lot>, IDataProvider
{
    public bool CzySamolotWolny(Samolot samolot, DateTime dataOdlotu, DateTime dataPowrotu);
}