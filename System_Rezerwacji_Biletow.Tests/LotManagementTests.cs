using System_Rezerwacji_Biletow.Interfaces;

namespace System_Rezerwacji_Biletow.Tests;
using NUnit.Framework;
using Lot;
using Managements;

[TestFixture]
public class LotManagementTests
{
    private LotManagement _management = LotManagement.GetInstance();
    private ILotBuilder _lotBuilder = new LotPasazerskiBuilder();
    
    [SetUp]
    public void SetUp()
    {
        _management.Reset();
        _lotBuilder.Reset();
    }

    [Test]
    public void DodajTest()
    {
       //Arrange & Act
        var lot = _lotBuilder.Build();
        
        //Assert
        Assert.Contains(lot,_management.GetList());
    }

    [Test]
    public void UsunTest()
    {
        //Arrange
        var lot = _lotBuilder.Build();
        
        //Act
        _management.Usun(lot);
        
        //Assert
        Assert.IsFalse(_management.GetList().Contains(lot));
    }
}