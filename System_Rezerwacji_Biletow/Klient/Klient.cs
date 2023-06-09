namespace System_Rezerwacji_Biletow.Klient;
using Managements;
public abstract class Klient 
{
    public string Id { get; protected set; }
    public string NumerTelefonu { get;}
    public string Email { get;}

    protected Klient(string numerTelefonu, string email)
    {
        Id = "K" + Convert.ToString(KlientManagement.GetInstance().GetList().Count);
        NumerTelefonu = numerTelefonu;
        Email = email;
    }

    public override string ToString()
    {
        return $"{Id}'{NumerTelefonu};{Email}";
    }
}
