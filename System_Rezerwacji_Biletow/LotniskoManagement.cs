namespace System_Rezerwacji_Biletow;

public class LotniskoManagement
{
    private List<Lotnisko>? _lotniska;

    public Lotnisko GetLotnisko(string miasto)
    {
        foreach (Lotnisko l in _lotniska)
        {
            if (l.GetMiasto() == miasto)
                return l;
        }

        return null; // obsluga bledu jak nie znajdzie lotniska o takim miescie
    }
}