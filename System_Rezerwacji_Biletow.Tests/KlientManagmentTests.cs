namespace System_Rezerwacji_Biletow.Tests;
using Managements;
using NUnit.Framework;
using Klient;

[TestFixture]
public class KlientManagmentTests
{
    private KlientManagement _management = KlientManagement.GetInstance();

    [SetUp]
    public void SetUp()
    {
        _management.Reset();
    }

    [Test]
    public void DodajTest()
    {
        //Arrange
        KlientIndywidualnyFactory kif = new KlientIndywidualnyFactory();
        KlientFirmaFactory kff = new KlientFirmaFactory();
        Klient obj1 = kif.CreateKlient("TestNumer", "TestEmail", "TestImie", "TestNazwisko");
        Klient obj2 = kff.CreateKlient("TestNumer", "TestEmail", "TestFirma");
        //Act
        _management.Dodaj(obj1);
        _management.Dodaj(obj2);
        //Assert
        Assert.Contains(obj1, _management.GetList());
        Assert.Contains(obj2, _management.GetList());
    }

    [Test]
    public void UsunTest()
    {
        //Arrange
        KlientIndywidualnyFactory kif = new KlientIndywidualnyFactory();
        KlientFirmaFactory kff = new KlientFirmaFactory();
        Klient obj1 = kff.CreateKlient("TestNumer", "TestEmail", "TestFirma");
        Klient obj2 = kif.CreateKlient("TestNumer", "TestEmail", "TestImie", "TestNazwisko");
        _management.Dodaj(obj1);
        _management.Dodaj(obj2);
        //Act
        _management.Usun(obj1);
        _management.Usun(obj2);
        //Assert
        Assert.IsFalse(_management.GetList().Contains(obj1));
        Assert.IsFalse(_management.GetList().Contains(obj2));
    }
}