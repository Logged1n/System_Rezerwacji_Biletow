using System.Dynamic;

namespace System_Rezerwacji_Biletow;

public abstract class Klient
{
    protected string Id { get; }
    protected string NumerTelefonu { get; }
    protected string Email { get; }

    public virtual string GetId()
    {
        return Id;
    }

    public virtual string GetNumerTelefonu()
    {
        return NumerTelefonu;
    }

    public virtual string GetEmail()
    {
        return Email;
    }
    
}