namespace System_Rezerwacji_Biletow;

public class LotDirector
{
    private ILotBuilder _lotBuilder;

    public void SetLotBuilder(ILotBuilder lotBuilder)
    {
        _lotBuilder = lotBuilder;
    }

    public LotDirector(ILotBuilder lotBuilder)
    {
        this.SetLotBuilder(lotBuilder);
    }

    public Lot MakeLot()
    {
        return new Lot();
    }
}