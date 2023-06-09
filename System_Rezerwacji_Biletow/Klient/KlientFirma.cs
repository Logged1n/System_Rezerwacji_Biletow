namespace System_Rezerwacji_Biletow;

public class KlientFirma : Klient
{
    public string NazwaFirmy { get; }

    public KlientFirma(string id, string numerTelefonu, string email, string nazwaFirmy) : base(id, numerTelefonu, email) // jak zrobisz KlientManagement to w base id zamien na cos podobnego co jest w samolotach
    {
        NazwaFirmy = nazwaFirmy;
    }
}