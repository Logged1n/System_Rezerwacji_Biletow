namespace System_Rezerwacji_Biletow;

public abstract class Klient
{
    //TODO, ta klasa, dziedziczace, fabryki, interface
    public string Id { get; protected set; } // przyklad jak masz deklarowac pola. get bez niczego znaczy ze ma ta sama hermetyzacje co pole (czyli tutaj public), wiec dowolna klasa moze je bezposrednio odczytac, bez oddzielnej funkcji. protected set; znaczy ze tylko klasy dziedziczace z tej klasy moga ustawiac wartosci na tym polu.
    public string NumerTelefonu { get; protected set;}
    public string Email {get; protected set;}
    
}
