namespace System_Rezerwacji_Biletow;

public interface ILotManagement : IManagement<Lot>
{
    public bool CzySamolotWolny(Samolot samolot, DateTime dataOdlotu, DateTime dataPowrotu);
}