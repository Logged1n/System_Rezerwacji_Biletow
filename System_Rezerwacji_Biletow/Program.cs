﻿namespace System_Rezerwacji_Biletow;
using ConsoleTables;
using Samolot;
using Lot;
using Managements;
using Exceptions;
using Klient;

class Program
{
    private static void Main(string[] args)
    {
        //DATA SETUP
        LotniskoManagement lotniskoManagement = LotniskoManagement.GetInstance();
        SamolotManagement samolotManagement = SamolotManagement.GetInstance();
        KlientManagement klientManagement = KlientManagement.GetInstance();
        TrasaManagement trasaManagement = TrasaManagement.GetInstance();
        LotManagement lotManagement = LotManagement.GetInstance();
        RezerwacjaManagement rezerwacjaManagement = RezerwacjaManagement.GetInstance();
        try
        {
            lotniskoManagement.LoadData("../../../SystemFiles/lotniska.txt");
            klientManagement.LoadData("../../../SystemFiles/klienci.txt");
            samolotManagement.LoadData("../../../SystemFiles/samoloty.txt");
            trasaManagement.LoadData("../../../SystemFiles/trasy.txt");
            lotManagement.LoadData("../../../SystemFiles/loty.txt");
            rezerwacjaManagement.LoadData("../../../SystemFiles/rezerwacje.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "Nie odczytano stanu systemu, ale mozesz korzystac z programu. Nacisnij dowolny przycisk aby kontynuowac...");
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
                              "5. Wyswietl liste Lotow\n" +
                              "6. Wygeneruj Lot\n" +
                              "7. Powiel Lot, ktory juz istnieje\n" +
                              "8. Zarzadzaj Biletami\n" +
                              "9. Zamknij Program");
            var wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                {
                    var validChoice = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1. Dodaj Samolot\n" +
                                          "2. Usun Samolot\n" +
                                          "3. Przegladaj Samoloty");
                        string wybor2 = Console.ReadLine();
                        switch (wybor2)
                        {
                            case "1":
                            {
                               //SETUP FABRYK SAMOLOTOW
                               SamolotRegionalnyFactory SRF = new SamolotRegionalnyFactory();
                               SamolotWaskokadlubowyFactory SWF = new SamolotWaskokadlubowyFactory();
                               SamolotSzerokokadlubowyFactory SSF = new SamolotSzerokokadlubowyFactory();
                               Lotnisko _lotnisko;
                               Console.WriteLine("Podaj nazwe lotniska poczatkowego dodawanego samolotu: ");
                               string lotnisko = Console.ReadLine();
                               try
                               {
                                   _lotnisko = lotniskoManagement.GetSingle(lotnisko);
                               }
                               catch (Exception ex)
                               {
                                   Console.WriteLine(ex.Message + "Sprobuj ponownie.");
                                   Console.ReadKey();
                                   break;
                               }
                               
                               Console.WriteLine("Podaj typ samolotu, jaki chcesz dodac.\n" +
                                                 "1. Regionalny\n" +
                                                 "2. Waskokadlubowy\n" +
                                                 "3. Szerokokadlubowy");
                               string typ = Console.ReadLine();
                               switch (typ)
                               {
                                   case "1":
                                   {
                                       samolotManagement.Dodaj(SRF.CreateSamolot(_lotnisko));
                                       validChoice = true;
                                       break;
                                   }
                                   case "2":
                                   {
                                       samolotManagement.Dodaj(SWF.CreateSamolot(_lotnisko));
                                       validChoice = true;
                                       break;
                                   }
                                   case "3":
                                   {
                                       samolotManagement.Dodaj(SSF.CreateSamolot(_lotnisko));
                                       validChoice = true;
                                       break;
                                   }
                                   default:
                                   {
                                       Console.WriteLine("Niepoprawna wartosc. Sprobuj ponownie: ");
                                       break;
                                   }
                               }
                               break;
                            }
                            case "2":
                            {
                                Console.WriteLine("Podaj ID samolotu, ktory chcesz usunac: ");
                                string usuwany = Console.ReadLine();
                                try
                                {
                                    samolotManagement.Usun(samolotManagement.GetSingle(usuwany));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message + "Nie udalo sie usunac wskazanego samolotu");
                                }
                                Console.WriteLine("Nacisnij dowolny przycisk, aby kontynuowac...");
                                Console.ReadKey();
                                validChoice = true;
                                break;
                            }
                            case "3":
                            {
                                Console.Clear();
                                var table = new ConsoleTable("ID", "Ilosc miejsc", "Zasieg (km)", "Lotnisko poczatkowe");
                                
                                foreach (var samolot in samolotManagement.GetList())
                                {
                                    string[] splitedProps = samolot.ToString().Split(";");
                                    table.AddRow(splitedProps[0], splitedProps[1], splitedProps[2], splitedProps[3]);
                                }
                                table.Write();
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

                case "2":
                {
                    var validChoice = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1. Dodaj Klienta\n" +
                                          "2. Usun Klienta\n" +
                                          "3. Przegladaj Klientow");
                        var wybor2 = Console.ReadLine();
                        switch (wybor2)
                        {
                            case "1":
                            {
                                KlientIndywidualnyFactory KIF = new KlientIndywidualnyFactory();
                                KlientFirmaFactory KFF = new KlientFirmaFactory();
                                bool poprawny = false;
                                do
                                {
                                    Console.WriteLine("Podaj typ klienta, ktorego chcesz dodac.\n" +
                                                      "1. Indywidualny\n" +
                                                      "2. Firma-Posrednik.");
                                    string typ = Console.ReadLine();
                                    switch (typ)
                                    {
                                        case "1":
                                        {
                                            Console.WriteLine("Podaj imie klienta: ");
                                            string imie = Console.ReadLine();
                                            Console.WriteLine("Podaj nazwisko klienta: ");
                                            string nazwisko = Console.ReadLine();
                                            Console.WriteLine("Podaj email klienta: ");
                                            string email = Console.ReadLine();
                                            Console.WriteLine("Podaj numer telefonu klienta: ");
                                            string numer = Console.ReadLine();
                                            klientManagement.Dodaj(KIF.CreateKlient(numer, email, imie, nazwisko));
                                            poprawny = true;
                                            break;
                                        }
                                        case "2":
                                        {
                                            Console.WriteLine("Podaj nazwe firmy: ");
                                            string nazwa = Console.ReadLine();
                                            Console.WriteLine("Podaj email firmy: ");
                                            string email = Console.ReadLine();
                                            Console.WriteLine("Podaj numer telefonu firmy: ");
                                            string numer = Console.ReadLine();
                                            klientManagement.Dodaj(KFF.CreateKlient(numer, email, nazwa));
                                            poprawny = true;
                                            break;
                                        }
                                        default:
                                        {
                                            Console.WriteLine("Niepoprawny wybor! Sprobuj ponownie.");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                } while (!poprawny);
                                
                                validChoice = true;
                                break;
                            }
                            case "2":
                            {
                                Console.WriteLine("Podaj ID klienta, ktorego chcesz usunac: ");
                                string id = Console.ReadLine();
                                try
                                {
                                    klientManagement.Usun(klientManagement.GetSingle(id));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message + "Nacisnij dowolny przycisk, aby kontynuowac...");
                                    Console.ReadKey();
                                }
                                validChoice = true;
                                break;
                            }
                            case "3":
                            {
                                Console.Clear();
                                var table = new ConsoleTable("ID", "Numer telefonu", "Email", "Imie", "Nazwisko", "Nazwa firmy");
                                foreach (var klient in klientManagement.GetList())
                                {
                                    if (klient is KlientIndywidualny)
                                    {
                                        string[] props = klient.ToString().Split(";");
                                        table.AddRow(props[0], props[1], props[2], props[3], props[4], "Brak");
                                    }
                                    else if (klient is KlientFirma)
                                    {
                                        string[] props = klient.ToString().Split(";");
                                        table.AddRow(props[0], props[1], props[2], "Brak", "Brak", props[3]);
                                    }
                                }
                                table.Write();
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

                case "3":
                {
                    var validChoice = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1. Dodaj Trase\n" +
                                          "2. Usun Trase\n" +
                                          "3. Przegladaj Trasy");
                        var wybor2 = Console.ReadLine();
                        switch (wybor2)
                        {
                            case "1":
                            {
                                int id = trasaManagement.GetList().Count;
                                Console.WriteLine("Podaj nazwe lotniska poczatkowego nowej trasy: ");
                                string nazwaPoczatek = Console.ReadLine();
                                Console.WriteLine("Podaj nazwe lotniska docelowego nowej trasy: ");
                                string nazwaCel = Console.ReadLine();
                                Console.WriteLine("Podaj jakiego dystansu jest to trasa (w km): ");
                                int dystans = Convert.ToInt32(Console.ReadLine());
                                Trasa dodawanaTrasa = new Trasa(lotniskoManagement.GetSingle(nazwaPoczatek), lotniskoManagement.GetSingle(nazwaCel), dystans);
                                trasaManagement.Dodaj(dodawanaTrasa);
                                Console.WriteLine("Pomyslnie dodano trase do bazy danych tras. Nacisnij dowolny przycisk aby kontynuowac...");
                                Console.ReadKey();
                                validChoice = true;
                                break;
                            }
                            case "2":
                            {
                                try
                                {
                                    Console.WriteLine("Podaj ID trasy, ktora chcesz usunac: ");
                                    string id = Console.ReadLine();
                                    trasaManagement.Usun(trasaManagement.GetSingle(id));
                                    Console.WriteLine($"Pomyslnie usunieto trase o id {id}. Nacisnij dowolny przycisk aby kontynuowac...");
                                    Console.ReadKey();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message + "Nacisnij dowolny przycisk, aby kontynuowac..");
                                    Console.ReadKey();
                                }
                                validChoice = true;
                                break;
                            }
                            case "3":
                            {
                                Console.Clear();
                                var table = new ConsoleTable("ID", "Poczatek", "Koniec", "Dystans (km)");
                                foreach (var t in trasaManagement.GetList())
                                {
                                    string[] props = t.ToString().Split(";");
                                    table.AddRow(props[0], props[1], props[2], props[3]);
                                }
                                table.Write();
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

                case "4":
                {
                    var validChoice = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1. Dodaj Lotnisko\n" +
                                          "2. Usun Lotnisko\n" +
                                          "3. Przegladaj Lotniska");
                        var wybor2 = Console.ReadLine();
                        switch (wybor2)
                        {
                            case "1":
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
                            case "2":
                            {
                                Console.WriteLine("Podaj nazwe lotniska, ktore chcesz usunac: ");
                                string nazwa = Console.ReadLine();
                                try
                                {
                                    lotniskoManagement.Usun(lotniskoManagement.GetSingle(nazwa));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message + "Nacisnij dowolny przycisk, aby kontynuowac..");
                                    Console.ReadKey();
                                }
                                validChoice = true;
                                break;
                            }
                            case "3":
                            {
                                Console.Clear();
                                var table = new ConsoleTable("Kraj", "Miasto", "Nazwa");
                                foreach (var lotnisko in lotniskoManagement.GetList())
                                {
                                    string[] props = lotnisko.ToString().Split(";");
                                    table.AddRow(props[0], props[1], props[2]);
                                }
                                table.Write();
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

                case "5":
                {
                    Console.Clear();
                    var table = new ConsoleTable("Numer lotu", "Lotnisko startowe", "Lotnisko docelowe","ID samolotu", "Data odlotu", "Data powrotu", "Czestotliwosc lotu");
                    foreach (var lot in lotManagement.GetList())
                    {
                        string[] props = lot.ToString().Split(";");
                        table.AddRow(props[0], props[1], props[2], props[3], props[4], props[5], props[6]);
                    }
                    table.Write();

                    Console.ReadKey();
                    break;
                }

                case "6":
                {
                    try
                    {
                        LotPasazerskiBuilder lotBuilder = new LotPasazerskiBuilder();
                        LotPlaner lotPlaner = new LotPlaner(lotBuilder);
                        Console.WriteLine("Podaj id trasy, dla ktorej chcesz wygenerowac lot: ");
                        string idTrasy = Console.ReadLine();
                        Console.WriteLine("Podaj date odlotu lotu, ktory chcesz wygenerowac(dd.MM.yyyy GG:mm:ss):");
                        DateTime dataOdlotu = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Podaj date powrotu lotu, ktory chcesz wygenerowac(dd.MM.yyyy GG:mm:ss): ");
                        DateTime dataPowrotu = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Jak czesto ma sie powtarzac lot? (Jednorazowy, Comiesieczny, Cotygodniowy, Codzienny): ");
                        Czestotliwosc czestotliwosc = Enum.Parse<Czestotliwosc>(Console.ReadLine());
                        lotPlaner.GenerujLot(TrasaManagement.GetInstance().GetSingle(idTrasy), dataOdlotu, dataPowrotu, czestotliwosc);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "Nacisnij dowolny przycisk, aby kontynuowac..");
                        Console.ReadKey();
                    }
                    break;
                }

                case "7":
                {
                    try
                    {
                        LotPasazerskiBuilder lotBuilder = new LotPasazerskiBuilder();
                        LotPlaner lotPlaner = new LotPlaner(lotBuilder);
                        Console.WriteLine("Podaj numer lotu, ktory chcesz powielic: ");
                        string numerLotu = Console.ReadLine();
                        lotPlaner.PowielLot(LotManagement.GetInstance().GetSingle(numerLotu));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "Nacisnij dowolny przycisk, aby kontynuowac..");
                        Console.ReadKey();
                    }
                    break;
                }
                case "8":
                {
                    var validChoice = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1. Zarezerwuj Bilet\n" +
                                          "2. Przegladaj Rezerwacje\n");
                        var wybor2 = Console.ReadLine();
                        switch (wybor2)
                        {
                            case "1":
                            {
                                Console.WriteLine("Podaj id klienta, na ktorego ma byc rezerwacja: ");
                                string id = Console.ReadLine();
                                Console.WriteLine("Podaj numer lotu, na ktory chcesz dokonac rezerwacji: ");
                                string numer = Console.ReadLine();
                                try
                                {
                                    rezerwacjaManagement.Dodaj(new Rezerwacja.Rezerwacja(klientManagement.GetSingle(id),
                                        lotManagement.GetSingle(numer)));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message + "Nacisnij dowolny przycisk, aby kontynuowac...");
                                    Console.ReadKey();
                                }
                                validChoice = true;
                                break;
                            }
                            case "2":
                            {
                                var table = new ConsoleTable("ID Rezerwacji", "ID Klienta", "Numer lotu");
                                foreach (var rezerwacja in rezerwacjaManagement.GetList())
                                {
                                    string[] props = rezerwacja.ToString().Split(";");
                                    table.AddRow(props[0], props[1], props[2]);
                                }
                                table.Write();
                                validChoice = true;
                                Console.ReadKey();
                                break;
                            }
                            default:
                            {
                                Console.WriteLine(
                                    "Niepoprawny wybor! Wybierz ponownie. Nacisnij dowolny przycisk aby kontynuowac...");
                                Console.ReadKey();
                                break;
                            }
                        }

                    } while (!validChoice);
                    break;
                }

                case "9":
                {
                    try
                    {
                        samolotManagement.SaveData("../../../SystemFiles/samoloty.txt");
                        lotniskoManagement.SaveData("../../../SystemFiles/lotniska.txt");
                        trasaManagement.SaveData("../../../SystemFiles/trasy.txt");
                        lotManagement.SaveData("../../../SystemFiles/loty.txt");
                        klientManagement.SaveData("../../../SystemFiles/klienci.txt");
                        rezerwacjaManagement.SaveData("../../../SystemFiles/rezerwacje.txt");
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