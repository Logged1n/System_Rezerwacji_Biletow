namespace System_Rezerwacji_Biletow.Tests;
using Managements;
using NUnit.Framework;

[TestFixture]
public class LotniskoManagementTests
{
    private LotniskoManagement _management = LotniskoManagement.GetInstance();

    [SetUp]
    public void SetUp()
    {
        _management.Reset();
    }

    [Test]
    public void DodajTest()
    {
        //Arrange
        Lotnisko obj = new Lotnisko("TestKraj", "TestMiasto", "TestNazwa");
        
        //Act
        _management.Dodaj(obj);
        
        //Assert
        Assert.Contains(obj, _management.GetList());
    }
    [Test]
    public void UsunTest()
    {
        //Arrange
        Lotnisko obj = new Lotnisko("TestKraj", "TestMiasto", "TestNazwa");
        _management.Dodaj(obj);
        
        //Act
        _management.Usun(obj);
        
        //Assert
        Assert.IsFalse(_management.GetList().Contains(obj));
    }
}