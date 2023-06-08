namespace System_Rezerwacji_Biletow;

public class KlientFirma: Klient
{
    public string NazwaFirmy { get; }

    public KlientFirma(string id, string NrTel, string Email, string NazwaFirmy) : base(id, NrTel, Email)
    {
        
    }
}