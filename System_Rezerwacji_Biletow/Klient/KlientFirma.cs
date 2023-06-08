namespace System_Rezerwacji_Biletow;

public class KlientFirma : Klient
{
    public string NazwaFirmy { get; }

    public KlientFirma(string id, string numerTelefonu, string email, string nazwaFirmy) : base(id, numerTelefonu, email)
    {
        NazwaFirmy = nazwaFirmy;
    }
}