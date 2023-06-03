namespace System_Rezerwacji_Biletow;

public class Trasa
{
    private string _id;
    private Lotnisko _start;
    private Lotnisko _cel;
    private int _dystans;

    public Trasa(string id, Lotnisko start, Lotnisko cel, int dystans) // ROZNICA WZGLEDEM UML, nie bylo tego konstruktora
    {
        _id = id;
        _start = start;
        _cel = cel;
        _dystans = dystans;
    }
    public string GetId()
    {
        return _id;
    }

    public Lotnisko GetStart()
    {
        return _start;
    }

    public Lotnisko GetCel()
    {
        return _cel;
    }

    public int GetDystans()
    {
        return _dystans;
    }
}