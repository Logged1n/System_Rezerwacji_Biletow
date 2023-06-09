namespace System_Rezerwacji_Biletow.Klient;

public abstract class Klient 
{
    //TODO, ta klasa, dziedziczace, fabryki, interface
    public string Id { get; protected set; } // to getter. Pod spodem kompilator deklaruje chronione pole id.
    public string NumerTelefonu { get; protected set;}
    public string Email {get; protected set;}

    protected Klient(string id, string numerTelefonu, string email)
    {
        Id = id;
        NumerTelefonu = numerTelefonu;
        Email = email;
    }
    
}
