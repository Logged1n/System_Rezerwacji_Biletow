namespace System_Rezerwacji_Biletow.Interfaces;

using Samolot;
public interface ISamolotManagement : IManagement<Samolot> // Interfejs zarzadzania Samolotami
{
    public List<Samolot> GetListLotnisko(Lotnisko lotnisko);
}