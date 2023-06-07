﻿namespace System_Rezerwacji_Biletow;

internal class Program
{
    private static void Main(string[] args)
    {
        LotniskoManagement lotniskoManagement = LotniskoManagement.GetInstance();
        TrasaManagement trasaManagement = TrasaManagement.GetInstance();
        
        lotniskoManagement.LoadData("lotniska.txt");
        trasaManagement.LoadData("trasy.txt");
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
                                int id = trasaManagement.GetList().Count;
                                Console.WriteLine("Podaj nazwe lotniska poczatkowego nowej trasy: ");
                                string nazwaPoczatek = Console.ReadLine();
                                Console.WriteLine("Podaj nazwe lotniska docelowego nowej trasy: ");
                                string nazwaCel = Console.ReadLine();
                                Console.WriteLine("Podaj jakiego dystansu jest to trasa (w km): ");
                                int dystans = Convert.ToInt32(Console.ReadLine());
                                Trasa dodawanaTrasa = new Trasa(id.ToString(),lotniskoManagement.GetSingle(nazwaPoczatek), lotniskoManagement.GetSingle(nazwaCel), dystans);
                                trasaManagement.Dodaj(dodawanaTrasa);
                                validChoice = true;
                                break;
                            }
                            case 2:
                            {
                                Console.WriteLine("Podaj ID trasy, ktora chcesz usunac: ");
                                string id = Console.ReadLine();
                                trasaManagement.Usun(trasaManagement.GetSingle(id));
                                validChoice = true;
                                break;
                            }
                            case 3:
                            {
                                Console.WriteLine("|   ID   |  Start  |  Cel  |   Dystans [km]  |");
                                foreach (var t in trasaManagement.GetList())
                                {
                                    Console.WriteLine(t);
                                }

                                Console.ReadKey();
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
                                Console.WriteLine("Podaj kraj, w ktorym znajduje sie lotnisko: ");
                                string kraj = Console.ReadLine();
                                Console.WriteLine("Podaj miasto, w ktorym znajduje sie lotnisko: ");
                                string miasto = Console.ReadLine();
                                Console.WriteLine("Podaj nazwe lotniska: ");
                                string nazwa = Console.ReadLine();
                                lotniskoManagement.Dodaj(new Lotnisko(kraj, miasto, nazwa));
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
                    Console.WriteLine("Zapisano stan systemu. Nastapi zamkniecie programu. Nacisnij dowolny przycisk aby kontynuowac...");
                    koniecProgramu = true;
                    Console.ReadKey();
                    break;
                }
            }
        } while (!koniecProgramu);
    }
}