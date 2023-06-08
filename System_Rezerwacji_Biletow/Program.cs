namespace System_Rezerwacji_Biletow;

internal class Program
{
    //TODO wypelnienie wszystkich opcji; generalnie jakies testy jednostkowe, obslugi bledow
    private static void Main(string[] args)
    {
        //DATA SETUP
       
        SamolotManagement samolotManagement = SamolotManagement.GetInstance();
        //KlientManagement klientManagement = KlientManagement.GetInstance();
        LotniskoManagement lotniskoManagement = LotniskoManagement.GetInstance();
        TrasaManagement trasaManagement = TrasaManagement.GetInstance();
        LotManagement lotManagement = LotManagement.GetInstance();
        //RezerwacjaManagement rezerwacjaManagement = RezerwacjaManagement.GetInstance();
        try
        {
            lotniskoManagement.LoadData("lotniska.txt");
            trasaManagement.LoadData("trasy.txt");
            lotManagement.LoadData("loty.txt");
        }
        catch (NieUdaloSieOdczytacPlikuException ex)
        {
            Console.WriteLine(ex.Message + "\nNie odczytano stanu systemu, ale mozesz korzystac z programu. Nacisnij dowolny przycisk aby kontynuowac...");
            Console.ReadKey();
        }
       
        var koniecProgramu = false;
        
        do
        {
            Console.Clear();
            Console.WriteLine("MENU\n" +
                              "1. Zarzadzaj Samolotami\n" +
                              "2. Zarzadzaj Klientami\n" +
                              "3. Zarzadzaj Trasami\n" +
                              "4. Zarzadzaj Lotniskami\n" +
                              "5. Wygeneruj Lot\n" +
                              "6. Zarezerwuj Bilet\n" +
                              "7. Zamknij Program");
            var wybor = Convert.ToInt32(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                {
                    var validChoice = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1. Dodaj Samolot\n" +
                                          "2. Usun Samolot\n" +
                                          "3. Przegladaj Samoloty");
                        var wybor2 = Convert.ToInt32(Console.ReadLine());
                        switch (wybor2)
                        {
                            case 1:
                            {
                                SamolotRegionalnyFactory srf = new SamolotRegionalnyFactory();
                                Samolot xd = srf.CreateSamolot("12", 60, 500,
                                    LotniskoManagement.GetInstance().GetSingle("Krywlany"));
                                SamolotManagement.GetInstance().Dodaj(xd);
                                validChoice = true;
                                break;
                            }
                            case 2:
                            {
                                //TODO
                                validChoice = true;
                                break;
                            }
                            case 3:
                            {
                                //TODO
                                Console.WriteLine(SamolotManagement.GetInstance().GetSingle("12"));
                                Console.ReadKey();
                                validChoice = true;
                                break;
                            }
                            default:
                            {
                                Console.WriteLine("Niepoprawny wybor! Wybierz ponownie. Nacisnij dowolny przycisk aby kontynuowac...");
                                Console.ReadKey();
                                break;
                            }
                        }
                    } while (!validChoice);

                    break;
                }

                case 2:
                {
                    var validChoice = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1. Dodaj Klienta\n" +
                                          "2. Usun Klienta\n" +
                                          "3. Przegladaj Klientow");
                        var wybor2 = Convert.ToInt32(Console.ReadLine());
                        switch (wybor2)
                        {
                            case 1:
                            {
                                //TODO
                                validChoice = true;
                                break;
                            }
                            case 2:
                            {
                                //TODO
                                validChoice = true;
                                break;
                            }
                            case 3:
                            {
                                //TODO
                                validChoice = true;
                                break;
                            }
                            default:
                            {
                                Console.WriteLine("Niepoprawny wybor! Wybierz ponownie. Nacisnij dowolny przycisk aby kontynuowac...");
                                Console.ReadKey();
                                break;
                            }
                        }
                    } while (!validChoice);

                    break;
                }

                case 3:
                {
                    var validChoice = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1. Dodaj Trase\n" +
                                          "2. Usun Trase\n" +
                                          "3. Przegladaj Trasy");
                        var wybor2 = Convert.ToInt32(Console.ReadLine());
                        switch (wybor2)
                        {
                            case 1:
                            {
                                int id = trasaManagement.GetList().Count;
                                Console.WriteLine("Podaj nazwe lotniska poczatkowego nowej trasy: ");
                                string nazwaPoczatek = Console.ReadLine();
                                Console.WriteLine("Podaj nazwe lotniska docelowego nowej trasy: ");
                                string nazwaCel = Console.ReadLine();
                                Console.WriteLine("Podaj jakiego dystansu jest to trasa (w km): ");
                                int dystans = Convert.ToInt32(Console.ReadLine());
                                Trasa dodawanaTrasa = new Trasa(id.ToString(),lotniskoManagement.GetSingle(nazwaPoczatek), lotniskoManagement.GetSingle(nazwaCel), dystans);
                                trasaManagement.Dodaj(dodawanaTrasa);
                                Console.WriteLine("Pomyslnie dodano trase do bazy danych tras. Nacisnij dowolny przycisk aby kontynuowac...");
                                Console.ReadKey();
                                validChoice = true;
                                break;
                            }
                            case 2:
                            {
                                Console.WriteLine("Podaj ID trasy, ktora chcesz usunac: ");
                                string id = Console.ReadLine();
                                trasaManagement.Usun(trasaManagement.GetSingle(id));
                                Console.WriteLine($"Pomyslnie usunieto trase o id {id}. Nacisnij dowolny przycisk aby kontynuowac...");
                                Console.ReadKey();
                                validChoice = true;
                                break;
                            }
                            case 3:
                            {
                                Console.WriteLine("|    ID    |   Start   |   Cel   |    Dystans [km]   |");
                                foreach (var t in trasaManagement.GetList())
                                {
                                    Console.WriteLine(t);
                                }
                                Console.WriteLine("\nNacisnij dowolny przycisk, aby kontynuowac...");
                                Console.ReadKey();
                                validChoice = true;
                                break;
                            }
                            default:
                            {
                                Console.WriteLine("Niepoprawny wybor! Wybierz ponownie. Nacisnij dowolny przycisk aby kontynuowac...");
                                Console.ReadKey();
                                break;
                            }
                        }
                    } while (!validChoice);

                    break;
                }

                case 4:
                {
                    var validChoice = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1. Dodaj Lotnisko\n" +
                                          "2. Usun Lotnisko\n" +
                                          "3. Przegladaj Lotniska");
                        var wybor2 = Convert.ToInt32(Console.ReadLine());
                        switch (wybor2)
                        {
                            case 1:
                            {
                                Console.WriteLine("Podaj kraj, w ktorym znajduje sie lotnisko: ");
                                string kraj = Console.ReadLine();
                                Console.WriteLine("Podaj miasto, w ktorym znajduje sie lotnisko: ");
                                string miasto = Console.ReadLine();
                                Console.WriteLine("Podaj nazwe lotniska: ");
                                string nazwa = Console.ReadLine();
                                lotniskoManagement.Dodaj(new Lotnisko(kraj, miasto, nazwa));
                                Console.WriteLine("Pomyslnie dodano lotnisko do bazy danych lotnisk. Nacisnij dowolny przycisk aby kontynuowac...");
                                Console.ReadKey();
                                validChoice = true;
                                break;
                            }
                            case 2:
                            {
                                //TODO
                                validChoice = true;
                                break;
                            }
                            case 3:
                            {
                                //TODO
                                validChoice = true;
                                break;
                            }
                            default:
                            {
                                Console.WriteLine("Niepoprawny wybor! Wybierz ponownie. Nacisnij dowolny przycisk aby kontynuowac...");
                                Console.ReadKey();
                                break;
                            }
                        }
                    } while (!validChoice);

                    break;
                }

                case 5:
                {
                    //TODO
                    break;
                }

                case 6:
                {
                    //TODO
                    break;
                }

                case 7:
                {
                    try
                    {
                        samolotManagement.SaveData("samoloty.txt");
                        lotniskoManagement.SaveData("lotniska.txt");
                        trasaManagement.SaveData("trasy.txt");
                        lotManagement.SaveData("loty.txt");
                        Console.WriteLine(
                            "Zapisano stan systemu. Nastapi zamkniecie programu. Nacisnij dowolny przycisk aby kontynuowac...");
                    }
                    catch (NieUdaloSieZapisacPlikuException ex)
                    {
                        Console.WriteLine(ex.Message + "\n W zwiazku z tym, program zostanie zamkniety bez zapisania zmian. Nacisnij dowolny przycisk aby kontynuowac...");
                    }
                    
                    koniecProgramu = true;
                    Console.ReadKey();
                    break;
                }
                default:
                {
                    Console.WriteLine("Nieprawidlowy wybor. Sprobuj ponownie. Nacisnij dowolny przycisk aby kontynuowac...");
                    Console.ReadKey();
                    break;
                }
            }
        } while (!koniecProgramu);
    }
}