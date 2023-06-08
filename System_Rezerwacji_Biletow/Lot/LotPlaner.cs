namespace System_Rezerwacji_Biletow;

public class LotPlaner
{
    //TODO powielanie na wiele dni, cotygodniowe itd
    private ILotBuilder _lotBuilder; // zmiana, sensowniej jest uznac, ze klasa LotPlaner bedzie Directorem dla klas ILotBuilder

    public LotPlaner (ILotBuilder lotBuilder)
    {
        _lotBuilder = lotBuilder;
    }
    public Lot GenerujLot(Trasa trasa, DateTime poczatek, DateTime koniec)
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
                return _lotBuilder.Build();
            }
        }

        throw new BrakOdpowiedniegoSamolotuException();
    }
}