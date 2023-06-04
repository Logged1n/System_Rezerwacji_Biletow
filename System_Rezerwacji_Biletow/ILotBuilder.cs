namespace System_Rezerwacji_Biletow;

public interface ILotBuilder
{
    ILotBuilder SetNumerLotu(string numerLotu);
    ILotBuilder SetTrasa(Trasa trasa);
    ILotBuilder SetSamolot(Samolot samolot);
    ILotBuilder SetDataOdlotu(DateTime dataOdlotu);
    ILotBuilder SetDataPowrotu(DateTime dataPowrotu);
    Lot Build();
}