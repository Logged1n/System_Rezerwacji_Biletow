namespace System_Rezerwacji_Biletow;
using Lot;

public interface ILotBuilder // Interfejs budowniczego lotu
{
    void Reset();
    void SetNumerLotu(string numerLotu);
    void SetTrasa(Trasa trasa);
    void SetSamolot(Samolot samolot);
    void SetDataOdlotu(DateTime dataOdlotu);
    void SetDataPowrotu(DateTime dataPowrotu);
    void SetCzestotliwoscLotu(Czestotliwosc czestotliwoscLotu);
    Lot.Lot Build();
}