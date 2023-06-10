namespace System_Rezerwacji_Biletow.Klient;
using Managements;
public class KlientFirma : Klient
{
    public string NazwaFirmy {get; }

    public KlientFirma(string numerTelefonu, string email, string nazwaFirmy) : base(numerTelefonu, email) // jak zrobisz KlientManagement to w base id zamien na cos podobnego co jest w samolotach
    {
        Id = "F" + Convert.ToString(KlientManagement.GetInstance().GetList().Count);
        NazwaFirmy = nazwaFirmy;
    }

    public override string ToString()
    {
        return $"{Id};{NumerTelefonu};{Email};{NazwaFirmy}";
    }
}