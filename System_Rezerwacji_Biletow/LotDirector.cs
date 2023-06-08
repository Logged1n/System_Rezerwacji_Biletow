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
        SetLotBuilder(lotBuilder);
    }

    public Lot MakeLot()
    {
        //TODO
        return _lotBuilder.Build();
    }
}