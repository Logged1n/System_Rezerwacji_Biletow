namespace System_Rezerwacji_Biletow;

public class LotDirector
{
    private ILotBuilder _lotBuilder;
    
    public void SetLotBuilder()
    {}

    public LotDirector(ILotBuilder lotBuilder)
    {
        _lotBuilder = lotBuilder;
    }

    public Lot MakeLot()
    {
        return new Lot();
    }
}