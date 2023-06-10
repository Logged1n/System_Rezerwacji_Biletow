namespace System_Rezerwacji_Biletow.Tests;
using NUnit.Framework;
using Managements;

[TestFixture]
public class TrasaManagementTests
{
    private TrasaManagement _management = TrasaManagement.GetInstance();
    
    [SetUp]
    public void SetUp()
    {
        _management.Reset();
    }

    [Test]
    public void DodajTest()
    {
        //Arrange
        Lotnisko lot1 = new Lotnisko("TestKraj", "TestMiasto", "TestNazwa");
        Lotnisko lot2 = new Lotnisko("TestKraj", "TestMiasto", "TestNazwa");
        Trasa obj = new Trasa( lot1, lot2,100);
        
        //Act
        _management.Dodaj(obj);
        
        //Assert
        Assert.Contains(obj, _management.GetList());
    }
    
    [Test]
    public void UsunTest()
    {
        //Arrange
        Lotnisko lot1 = new Lotnisko("TestKraj", "TestMiasto", "TestNazwa");
        Lotnisko lot2 = new Lotnisko("TestKraj", "TestMiasto", "TestNazwa");
        Trasa obj = new Trasa(lot1, lot2,100);
        _management.Dodaj(obj);
        
        //Act
        _management.Usun(obj);
        
        //Assert
        Assert.IsFalse(_management.GetList().Contains(obj));
    }
}