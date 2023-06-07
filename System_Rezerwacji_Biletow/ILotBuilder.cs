namespace System_Rezerwacji_Biletow;

public interface ILotBuilder
{
    void SetNumerLotu(string numerLotu);
    void SetTrasa(Trasa trasa);
    void SetSamolot(Samolot samolot);
    void SetDataOdlotu(DateTime dataOdlotu);
    void SetDataPowrotu(DateTime dataPowrotu);
    Lot Build();
}