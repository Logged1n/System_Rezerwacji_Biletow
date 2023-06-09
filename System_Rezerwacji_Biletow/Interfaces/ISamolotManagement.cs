namespace System_Rezerwacji_Biletow;

public interface ISamolotManagement : IManagement<Samolot> // Interfejs zarzadzania Samolotami
{
    public List<Samolot> GetListLotnisko(Lotnisko lotnisko);
}