namespace System_Rezerwacji_Biletow.Klient;
using Managements;
public abstract class Klient 
{
    //TODO, ta klasa, dziedziczace, fabryki, interface
    public string Id { get; protected set; } // to getter. Pod spodem kompilator deklaruje chronione pole id.
    public string NumerTelefonu { get; protected set;}
    public string Email {get; protected set;}

    protected Klient(string numerTelefonu, string email)
    {
        Id = "K" + Convert.ToString(KlientManagment.GetInstance().GetList().Count);
        NumerTelefonu = numerTelefonu;
        Email = email;
    }

    public override string ToString()
    {
        return $"{Id}'{NumerTelefonu};{Email}";
    }
}
