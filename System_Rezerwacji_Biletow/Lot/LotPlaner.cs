namespace System_Rezerwacji_Biletow.Lot;
using Managements;
using Exceptions;

public class LotPlaner
{
    private ILotBuilder _lotBuilder; // zmiana, sensowniej jest uznac, ze klasa LotPlaner bedzie Directorem dla klas ILotBuilder

    public LotPlaner (ILotBuilder lotBuilder)
    {
        _lotBuilder = lotBuilder;
    }
    public Lot GenerujLot(Trasa trasa, DateTime poczatek, DateTime koniec, Czestotliwosc czestotliwoscLotu = Czestotliwosc.Jednorazowy)
    {
        List<Samolot> samolotyDoWyboru = SamolotManagement.GetInstance().GetListLotnisko(trasa.Start);
        foreach (var samolot in samolotyDoWyboru)
        {
            if (LotManagement.GetInstance().CzySamolotWolny(samolot, poczatek, koniec) &&
                samolot.Zasieg >= trasa.Dystans)
            {
                _lotBuilder.Reset();
                _lotBuilder.SetSamolot(samolot);
                _lotBuilder.SetTrasa(trasa);
                _lotBuilder.SetDataOdlotu(poczatek);
                _lotBuilder.SetDataPowrotu(koniec);
                _lotBuilder.SetCzestotliwoscLotu(czestotliwoscLotu);
                return _lotBuilder.Build();
            }
        }

        throw new BrakOdpowiedniegoSamolotuException();
    }

    public void PowielLot(Lot lot)
    {
        switch (lot.CzestotliwoscLotu)
        {
            case Czestotliwosc.Jednorazowy:
            {
                throw new TakiLotJuzIstniejeException();
            }
            case Czestotliwosc.Comiesieczny:
            {
                GenerujLot(lot.Trasa, lot.DataOdlotu.AddMonths(1), lot.DataPowrotu.AddMonths(1));
                break;
            }
            case Czestotliwosc.Cotygodniowy:
            {
                GenerujLot(lot.Trasa, lot.DataOdlotu.AddDays(7), lot.DataPowrotu.AddDays(7));
                break;
            }
            case Czestotliwosc.Codzienny:
            {
                GenerujLot(lot.Trasa, lot.DataOdlotu.AddDays(1), lot.DataPowrotu.AddDays(1));
                break;
            }
        }
    }
}