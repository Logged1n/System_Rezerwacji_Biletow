namespace System_Rezerwacji_Biletow;

public interface ISamolotManagement : IManagement<Samolot>
{
    public List<Samolot> GetListLotnisko(Lotnisko lotnisko);
    public List<Samolot> GetListZasieg(int zasieg);
}