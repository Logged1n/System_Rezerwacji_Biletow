namespace System_Rezerwacji_Biletow;

internal class Program
{
    private static void Main(string[] args)
    {
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
                                Console.WriteLine("Niepoprawny wybor! Wybierz ponownie.");
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
                                Console.WriteLine("Niepoprawny wybor! Wybierz ponownie.");
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
                                Console.WriteLine("Niepoprawny wybor! Wybierz ponownie.");
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
                                Console.WriteLine("Niepoprawny wybor! Wybierz ponownie.");
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
                    //TODO
                    Console.WriteLine(
                        "Zapisano stan systemu. Nastapi zamkniecie programu. Nacisnij dowolny przycisk aby kontynuowac...");
                    koniecProgramu = true;
                    break;
                }
            }
        } while (!koniecProgramu);
    }
}