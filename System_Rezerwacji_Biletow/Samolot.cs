namespace System_Rezerwacji_Biletow;

public abstract class Samolot
{
    protected string _id;
    protected int _iloscMiejsc;
    protected int _zasieg;
    protected Lotnisko _poczatkoweLotnisko;

    public string GetId()
    {
        return _id;
    }
}