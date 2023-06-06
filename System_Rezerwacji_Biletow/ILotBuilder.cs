namespace System_Rezerwacji_Biletow;

public interface ILotBuilder
{
    public void SetNumerLotu();
    public void SetTrasa(Trasa trasa);
    public void SetSamolot(Samolot samolot);
    public void SetDataOdlotu(DateTime dataOdlotu);
    public void SetDataPowrotu(DateTime dataPowrotu);
    public Lot GetLot();
}