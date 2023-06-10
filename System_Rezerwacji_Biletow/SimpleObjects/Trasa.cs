using System_Rezerwacji_Biletow.Managements;

namespace System_Rezerwacji_Biletow;

public class Trasa
{
    public string Id { get; }
    public Lotnisko Start { get; }
    public Lotnisko Cel { get; }
    public int Dystans { get; }

    public Trasa(Lotnisko start, Lotnisko cel, int dystans) // konstruktor do wczytywania danych w TrasaManagement
    {
        Id = Convert.ToString(TrasaManagement.GetInstance().GetList().Count);
        Start = start;
        Cel = cel;
        Dystans = dystans;
    }

    public override string ToString()
    {
        return $"{Id};{Start.Nazwa};{Cel.Nazwa};{Dystans};";
    }
}