using System_Rezerwacji_Biletow.Managements;

namespace System_Rezerwacji_Biletow.Tests;
using NUnit.Framework;
using Lot;
using Samolot;

[TestFixture]
public class LotPasazerskiBuilderTests
{
    private LotPasazerskiBuilder lotBuilder = new LotPasazerskiBuilder();

    [SetUp]
    public void SetUp()
    {
        LotManagement.GetInstance().Reset();
        lotBuilder.Reset();
    }

    [Test]
    public void SetNumerLotuTest()
    {
        //Arrange
        string numerLotu = "123";
        
        //Act
        lotBuilder.SetNumerLotu(numerLotu);
        var result = lotBuilder.Build();
        
        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(numerLotu, result.NumerLotu);
    }

    [Test]
    public void SetTrasaTest()
    {
        //Arrange
        int dystans = 200;
        Lotnisko lotniskoStart = new Lotnisko("KrajStart", "MiastoStart", "NazwaStart");
        Lotnisko lotniskoCel = new Lotnisko("KrajCel", "MiastoCel", "NazwaCel");
        Trasa trasa = new Trasa(lotniskoStart, lotniskoCel, dystans);
        
        //Act
        lotBuilder.SetTrasa(trasa);
        var result = lotBuilder.Build();
        
        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(trasa,result.Trasa);
    }

    [Test]
    public void SetSamolotTest()
    {
        //Arrange
        Lotnisko lotniskoStart = new Lotnisko("KrajStart", "MiastoStart", "NazwaStart");
        SamolotRegionalnyFactory srf = new SamolotRegionalnyFactory();
        SamolotWaskokadlubowyFactory swf = new SamolotWaskokadlubowyFactory();
        SamolotSzerokokadlubowyFactory ssf = new SamolotSzerokokadlubowyFactory();
        Samolot SR = srf.CreateSamolot(lotniskoStart);
        Samolot SW = swf.CreateSamolot(lotniskoStart);
        Samolot SS = ssf.CreateSamolot(lotniskoStart);
        
        //Act & Assert
        lotBuilder.SetSamolot(SR);
        var result = lotBuilder.Build();
        Assert.IsNotNull(result);
        Assert.AreEqual(SR, result.Samolot);
        LotManagement.GetInstance().Reset();
        lotBuilder.Reset();
        lotBuilder.SetSamolot(SW);
        result = lotBuilder.Build();
        Assert.IsNotNull(result);
        Assert.AreEqual(SW, result.Samolot);
        LotManagement.GetInstance().Reset();
        lotBuilder.Reset();
        lotBuilder.SetSamolot(SS);
        result = lotBuilder.Build();
        Assert.IsNotNull(result);
        Assert.AreEqual(SS, result.Samolot);
    }

    [Test]
    public void SetDatyTest()
    {
        //Arrange
        DateTime dataStart = DateTime.Today;
        DateTime dataCel = DateTime.Today.AddHours(7);
        
        //Act
        lotBuilder.SetDataOdlotu(dataStart);
        lotBuilder.SetDataPowrotu(dataCel);
        var result = lotBuilder.Build();
        
        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(dataStart, result.DataOdlotu);
        Assert.AreEqual(dataCel, result.DataPowrotu);
    }

    [Test]
    public void SetCzestotliwoscTest()
    {
        //Arrange
        Czestotliwosc czestotliwosc = Czestotliwosc.Jednorazowy;
        
        //Act
        lotBuilder.SetCzestotliwoscLotu(czestotliwosc);
        var result = lotBuilder.Build();
        
        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(czestotliwosc, result.CzestotliwoscLotu);
    }
}