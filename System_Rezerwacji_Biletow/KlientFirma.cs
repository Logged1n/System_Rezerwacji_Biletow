using System.Dynamic;

namespace System_Rezerwacji_Biletow;

public class  KlientFirma : Klient
{
    public string NazwaFirmy { get; }

    public string GetNazwaFirmy()
    {
        return NazwaFirmy;
    }
}