namespace System_Rezerwacji_Biletow.Klient;
using Managements;
public class KlientFirma : Klient
{
    public string NazwaFirmy {get; }

    internal KlientFirma(string numerTelefonu, string email, string nazwaFirmy) : base(numerTelefonu, email) // tylko klasy w tej samej przestrzeni nazw moga skorzystac z tego konstruktora - czyli fabryki
    {
        Id = "F" + Convert.ToString(KlientManagement.GetInstance().GetList().Count);
        NazwaFirmy = nazwaFirmy;
    }

    public override string ToString()
    {
        return $"{Id};{NumerTelefonu};{Email};{NazwaFirmy}";
    }
}