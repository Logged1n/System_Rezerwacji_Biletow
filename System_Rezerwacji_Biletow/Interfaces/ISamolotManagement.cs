namespace System_Rezerwacji_Biletow.Interfaces;

using Samolot;
public interface ISamolotManagement : IManagement<Samolot> // Interfejs zarzadzania Samolotami ~wykorzystywany w LotPlaner
{
    public List<Samolot> GetListLotnisko(Lotnisko lotnisko);
}