namespace System_Rezerwacji_Biletow;

public class Lotnisko
{
    private string _kraj;
    private string _miasto;
    //zalozmy, ze miasto ma jedne lotnisko, wtedy nazwa jest niepotrzebna

    public string GetMiasto()
    {
        return _miasto;
    }
}