namespace System_Rezerwacji_Biletow.Tests;
using Managements;
using NUnit.Framework;
using Rezerwacja;
using Klient;
using Lot;
using Samolot;

[TestFixture]
public class RezerwacjaManagementTests
{
    private RezerwacjaManagement _management = RezerwacjaManagement.GetInstance();
    private LotPasazerskiBuilder lotBuilder = new LotPasazerskiBuilder();

    [SetUp]
    public void SetUp()
    {
        _management.Reset();
        lotBuilder.Reset();
        LotManagement.GetInstance().Reset();
        KlientManagement.GetInstance().Reset();
    }
    
    [Test]
    public void DodajTest()
    {
        //Arrange
        Lotnisko A = new Lotnisko("X", "Y", "Z");
        Lotnisko B = new Lotnisko("A", "B", "C");
        SamolotRegionalnyFactory srf = new SamolotRegionalnyFactory();
        Samolot regionalny = srf.CreateSamolot(A);
        KlientIndywidualnyFactory kif = new KlientIndywidualnyFactory();
        KlientFirmaFactory kff = new KlientFirmaFactory();
        Klient TestKlient1 = kif.CreateKlient("TestNumer", "TestEmail", "TestImie", "TestNazwisko");
        Klient TestKlient2 = kff.CreateKlient("TestNumer", "TestEmail", "TestFirma");
        lotBuilder.SetNumerLotu("1");
        lotBuilder.SetTrasa(new Trasa(A, B, 150));
        lotBuilder.SetSamolot(regionalny);
        lotBuilder.SetDataOdlotu(DateTime.Now);
        lotBuilder.SetDataPowrotu(DateTime.Now.AddHours(8));
        lotBuilder.SetCzestotliwoscLotu(Czestotliwosc.Jednorazowy);
        var lot = lotBuilder.Build();
        Rezerwacja obj1 = new Rezerwacja(TestKlient1, lot);
        Rezerwacja obj2 = new Rezerwacja(TestKlient2, lot);
        //Act & Assert
        _management.Dodaj(obj1);
        Assert.Contains(obj1, _management.GetList());
        _management.Reset();
        _management.Dodaj(obj2);
        Assert.Contains(obj2, _management.GetList());
    }

    [Test]
    public void UsunTest()
    {
        //Arrange
        Lotnisko A = new Lotnisko("X", "Y", "Z");
        Lotnisko B = new Lotnisko("A", "B", "C");
        SamolotRegionalnyFactory srf = new SamolotRegionalnyFactory();
        Samolot regionalny = srf.CreateSamolot(A);
        KlientIndywidualnyFactory kif = new KlientIndywidualnyFactory();
        KlientFirmaFactory kff = new KlientFirmaFactory();
        Klient TestKlient1 = kif.CreateKlient("TestNumer", "TestEmail", "TestImie", "TestNazwisko");
        Klient TestKlient2 = kff.CreateKlient("TestNumer", "TestEmail", "TestFirma");
        lotBuilder.SetNumerLotu("1");
        lotBuilder.SetTrasa(new Trasa(A, B, 150));
        lotBuilder.SetSamolot(regionalny);
        lotBuilder.SetDataOdlotu(DateTime.Now);
        lotBuilder.SetDataPowrotu(DateTime.Now.AddHours(8));
        lotBuilder.SetCzestotliwoscLotu(Czestotliwosc.Jednorazowy);
        var lot = lotBuilder.Build();
        Rezerwacja obj1 = new Rezerwacja(TestKlient1, lot);
        Rezerwacja obj2 = new Rezerwacja(TestKlient2, lot);
        
        //Act & Assert
        _management.Dodaj(obj1);
        _management.Usun(obj1);
        Assert.IsFalse(_management.GetList().Contains(obj1));
        _management.Reset();
        _management.Dodaj(obj2);
        _management.Usun(obj2);
        Assert.IsFalse(_management.GetList().Contains(obj2));
    }
}