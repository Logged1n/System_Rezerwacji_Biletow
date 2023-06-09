namespace System_Rezerwacji_Biletow.Lot;
using Managements;
using Exceptions;
using Interfaces;
using Samolot;

public class LotPlaner
{
    private readonly ILotBuilder _lotBuilder; // aktualnie LotPlaner pelni tez role LotDirectora - wybiera sposob tworzenia lotow.

    public LotPlaner (ILotBuilder lotBuilder)
    {
        _lotBuilder = lotBuilder;
    }
    public Lot GenerujLot(Trasa trasa, DateTime poczatek, DateTime koniec, Czestotliwosc czestotliwoscLotu = Czestotliwosc.Jednorazowy) // wybieramy odpowiedni samolot, a nastepnie przy pomocy buildera tworzymy nowy lot
    {
        List<Samolot> samolotyDoWyboru = SamolotManagement.GetInstance().GetListLotnisko(trasa.Start);
        foreach (var samolot in samolotyDoWyboru)
        {
            if (LotManagement.GetInstance().CzySamolotWolny(samolot, poczatek, koniec) &&
                samolot.Zasieg >= trasa.Dystans)
            {
                _lotBuilder.Reset();
                _lotBuilder.SetNumerLotu(Convert.ToString(LotManagement.GetInstance().GetList().Count));
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

    public void PowielLot(Lot lot) // zwykle powielenie lotu na prosbe uzytkownika w zaleznosci od czestotliwosci powtarzania go (powielenie jest tylko jednokrotne ~uproszczenie)
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