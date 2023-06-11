namespace System_Rezerwacji_Biletow.Tests;
using Managements;
using Samolot;
using NUnit.Framework;

[TestFixture]
public class SamolotManagementTests
{
    private SamolotManagement _management = SamolotManagement.GetInstance();
    [SetUp]
    public void SetUp()
    {
        _management.Reset();
    }
    [Test]
    public void DodajTest()
    {
        //Arrange
        SamolotRegionalnyFactory SRF = new SamolotRegionalnyFactory();
        SamolotSzerokokadlubowyFactory SSF = new SamolotSzerokokadlubowyFactory();
        SamolotWaskokadlubowyFactory SWF = new SamolotWaskokadlubowyFactory();
        Lotnisko obj = new Lotnisko("TestKraj", "TestMiasto", "TestNazwa");
        Samolot samolot = SRF.CreateSamolot(obj);
        Samolot samolot1 = SSF.CreateSamolot(obj);
        Samolot samolot2 = SWF.CreateSamolot(obj);
        
        //Act
        _management.Dodaj(samolot);
        _management.Dodaj(samolot1);
        _management.Dodaj(samolot2);
        
        //Assert
        Assert.Contains(samolot, _management.GetList());
        Assert.Contains(samolot1,_management.GetList());
        Assert.Contains(samolot2,_management.GetList());
    }

    [Test]
    public void UsunTest()
    {
        //Arrange
        SamolotRegionalnyFactory SRF = new SamolotRegionalnyFactory();
        SamolotSzerokokadlubowyFactory SSF = new SamolotSzerokokadlubowyFactory();
        SamolotWaskokadlubowyFactory SWF = new SamolotWaskokadlubowyFactory();
        Lotnisko obj = new Lotnisko("TestKraj", "TestMiasto", "TestNazwa");
        Samolot samolot = SRF.CreateSamolot(obj);
        Samolot samolot1 = SSF.CreateSamolot(obj);
        Samolot samolot2 = SWF.CreateSamolot(obj);
        _management.Dodaj(samolot);
        _management.Dodaj(samolot1);
        _management.Dodaj(samolot2);
        
        //Act
        _management.Usun(samolot);
        _management.Usun(samolot1);
        _management.Usun(samolot2);
        
        //Assert
        Assert.IsFalse(_management.GetList().Contains(samolot));
        Assert.IsFalse(_management.GetList().Contains(samolot1));
        Assert.IsFalse(_management.GetList().Contains(samolot2));
    }
}