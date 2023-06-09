namespace System_Rezerwacji_Biletow.Interfaces;

using Samolot;
using Lot;

public interface ILotManagement : IManagement<Lot> // Interfejs zarzadzania Lotami
{
    public bool CzySamolotWolny(Samolot samolot, DateTime dataOdlotu, DateTime dataPowrotu);
}