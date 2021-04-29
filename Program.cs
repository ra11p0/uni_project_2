using System;

namespace ObliczeniaIteracyjne_53514
{
    class Program
    {
        //pobranie liczby naturalnej, opcjonalnie czy wiekszej od zera, czy nie  
        static int plPobranieLiczbyNaturalnej(string plZapytanie, bool plCzyZeroDopuszczalne = true)
        {
            //deklaracja zmiennych
            int plLiczba = 0;
            //wypisanie zapytania 
            Console.Write("\n\t" + plZapytanie);
            //sprawdzenie, czy zero jest dopuszczalne, czy nie 
            if (!plCzyZeroDopuszczalne)
            {
                while (!int.TryParse(Console.ReadLine(), out plLiczba) || plLiczba <= 0)
                {
                    //podano nieprawidlowy znak
                    Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby naturalne większe od zera.");
                    Console.Write("\tWpisz ponownie liczbę: ");
                }
            }
            else if (plCzyZeroDopuszczalne)
            {
                while (!int.TryParse(Console.ReadLine(), out plLiczba) || plLiczba < 0)
                {
                    //podano nieprawidlowy znak
                    Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby naturalne.");
                    Console.Write("\tWpisz ponownie liczbę: ");
                }
            }
            return plLiczba;
        }
        // pobranie liczby wymiernej, opcjonalnie czy większej od zera, czy dodatniej
        static float plPobranieLiczbyWymiernej(string plZapytanie, bool plCzyZeroDopuszczalne = true, bool plCzyUjemneDopuszczalne = true)
        {
            //deklaracje zmiennych
            float plLiczba = 0;
            //wypisanie zapytania 
            Console.Write("\n\t" + plZapytanie);
            //sprawidzenie czy zero jest dopuszczalne 
            if (!plCzyZeroDopuszczalne)
            {
                //sprawdzenie czy liczby ujemne sa dopuszczalne 
                if (plCzyUjemneDopuszczalne)
                {
                    while (!float.TryParse(Console.ReadLine(), out plLiczba) || plLiczba == 0)
                    {
                        //podano nieprawidlowy znak
                        Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne różne od zera.");
                        Console.Write("\tWpisz ponownie liczbę: ");
                    }
                }
                else
                {
                    while (!float.TryParse(Console.ReadLine(), out plLiczba) || plLiczba <= 0)
                    {
                        //podano nieprawidlowy znak
                        Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne większe od zera.");
                        Console.Write("\tWpisz ponownie liczbę: ");
                    }
                }
            }
            else if (plCzyZeroDopuszczalne)
            {
                if (plCzyUjemneDopuszczalne)
                {
                    while (!float.TryParse(Console.ReadLine(), out plLiczba))
                    {
                        //podano nieprawidlowy znak
                        Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne.");
                        Console.Write("\tWpisz ponownie liczbę: ");
                    }
                }
                else
                {
                    while (!float.TryParse(Console.ReadLine(), out plLiczba) || plLiczba < 0)
                    {
                        //podano nieprawidlowy znak
                        Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne dodatnie.");
                        Console.Write("\tWpisz ponownie liczbę: ");
                    }
                }
            }
            return plLiczba;
        }
        //silnia
        static ulong plObliczanieSilni(float plLiczba)
        {
            //deklaracje zmiennych
            ulong plSilnia = 1;
            //obliczanie silni
            for (int pli = 1; pli <= plLiczba; pli++)
            {
                plSilnia = plSilnia * (ulong)pli;
            }
            if (plLiczba == 0 || plLiczba == 1) return 1;

            //zwracanie wyniku silni
            return plSilnia;
        }
        //obliczenie Sumy szeregu potegowego
        static double plObliczanieSumySzeregu(float plX, float plEps, out ushort plK)
        {
            //deklaracja zmiennych
            float plW;
            float plSumaSzeregu;
            //Stan poczatkowy
            plK = 0;
            plW = 0.5F;
            plSumaSzeregu = 0.0F;
            //iteracyjne obliczanie sumy szeregu potegowego

            do
            {
                plSumaSzeregu += plW;
                plK++;
                if (plK < 23) plW = plW * (plX * (((1 / (float)plObliczanieSilni(plK - 1)) + 1) / (plK + (1 / plObliczanieSilni(plK - 1)))));
                else if (plK >= 23) plW = plW * (plX / plK);
                //    Console.WriteLine("\n K: {0}", plK);
                //    Console.WriteLine("\n W: {0}", plW);
                //    Console.WriteLine("\n Suma: {0}", plSumaSzeregu);
                //   Console.WriteLine("\n Element: {0}", plW);
                //    Console.ReadKey();

            } while (Math.Abs(plW) > plEps);
            //zwracanie sumy szeregu
            return plSumaSzeregu;
        }
        //pierwiastek Heron
        static float plPierwiastekHerona(float plA, float plEps, out short plI)
        {
            float plXi, plXi1;
            //sprawdzenie i wykrycie bledu
            if ((plA < 0.0F) || (plEps <= 0.0F) || (plEps >= 1.0F))
            {
                plI = -1;
                return 0.0F;
            }
            plI = 0;
            plXi = plA / 2.0F;
            //iteracyjne przyblizenie pierwiastka a
            do
            {
                plXi1 = plXi;
                plI++;
                plXi = (plXi1 + plA / plXi1) / 2.0f;
            } while (Math.Abs(plXi - plXi1) > plEps);
            //zwrot wyniku
            return plXi;
        }
        //pierwiastek newton
        static float plPierwiastekNewtona(float plA, short plN, float plEps, out short plI)
        {
            float plXi, plXi1;
            //sprawdzenie warunku wejściowego
            if ((plA <= 0.0F) || (plN < 0) || (plEps <= 0.0F) || (plEps >= 1.0F))
            {
                plI = -1;
                return 0.0F;
            }
            //ustalenie stanu poczatkowego obliczen
            plI = 0;
            plXi = plA;
            //iteracyjne obliczanie pierwiastka
            do
            {
                plXi1 = plXi;
                plI++;
                plXi = ((plN - 1) * plXi1 + plA / (float)Math.Pow(plXi - 1, plN - 1)) / plN;
            } while (Math.Abs(plXi - plXi1) > plEps);
            //zwrot wyniku obliczen
            return plXi;
        }
        static void Main(string[] args)
        {
            //deklaracja zmiennych lokalnych
            ConsoleKeyInfo plWybranaFunkcjonalnosc;
            bool plSledzenie = false;

            //konfiguracja okna wiersza poleceń (WINDOWS)
            //Console.SetWindowSize(120, 24);
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.ForegroundColor = ConsoleColor.White;
            do
            {
                //wypisanie nazwy programu
                Console.WriteLine("\tProgram ObliczeniaIteracyjne_53514 umożliwia obliczanie sum szeregu potęgowego");

                //wypisanie menu funkcji programu
                Console.WriteLine("\n\n\tFunkcjonalne menu programu:");
                Console.WriteLine("\tA: Obliczanie wartości (sumy) szerego potęgowego.");
                Console.WriteLine("\tB: Tablicowanie wartości (sumy) szeregu potęgowego");
                Console.WriteLine("\tC: Tablicowanie wartości pierwiastka kwadratowego.");
                Console.WriteLine("\tD: Obliczanie wartości n-tego pierwiastka.");
                Console.WriteLine("\tX: Zakończenie (wyjście z) programu\n");

                //żądanie wybrania funkcji programu 
                Console.Write("\tNaciśnij klawisz przypisany odpowiedniej funkcjonalności z której chcesz skorzystać: ");

                //odczytanie wybranej funkcji programu 
                plWybranaFunkcjonalnosc = Console.ReadKey();
                if (plWybranaFunkcjonalnosc.Key != ConsoleKey.X)
                {
                    Console.Write("\n\tAby włączyć śledzenie obliczeń, naciśnij klawisz T (lub t), jeśli nie, naciśnij dowolny inny klawisz: ");
                    if (Console.ReadKey().Key == ConsoleKey.T) plSledzenie = true;
                }

                Console.Clear();

                //uruchomienie wybranej funkcjonalności programu
                switch (plWybranaFunkcjonalnosc.Key)
                {
                    case ConsoleKey.A:
                        //deklaracja zmiennych 
                        float plX, plEps, plSumaSzeregu;
                        ushort plLicznikWyrazowSzeregu;
                        //wypisanie nazwy wybranej funkcji
                        Console.WriteLine("\n\n\tWybrana funkcjonalność: Obliczanie wartości (sumy) szerego potęgowego.");

                        //pobranie liczby X
                        plX = plPobranieLiczbyWymiernej("Wpisz wartość zmiennej X szeregu potęgowego: ");

                        if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisana wartość zmiennej X szeregu potęgowego: {0}", plX);

                        //pobranie dokladnosci obliczen sumy szeregu
                        do
                        {

                            plEps = plPobranieLiczbyWymiernej("Wpisz dokładność obliczeń sumy szeregu potęgowego (dodatnia mniejsza od jeden): ", false, false);

                            if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisana dokładność obliczeń sumy szeregu potęgowego: {0}", plEps);

                            if (plEps >= 1) Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne mniejsze od 1.");


                        } while (plEps >= 1);

                        plSumaSzeregu = (float)plObliczanieSumySzeregu(plX, plEps, out plLicznikWyrazowSzeregu);

                        Console.WriteLine("\n\tObliczona suma: {0}. \n\tObliczono sumę z: {1} elementow.", plSumaSzeregu, plLicznikWyrazowSzeregu);


                        break;
                    case ConsoleKey.B:
                        //deklaracja zmiennych 
                        float plPrzedzialA, plPrzedzialB, plZmiana;
                        //wypisanie nazwy wybranej funkcji
                        Console.WriteLine("\n\n\tWybrana funkcjonalność: Obliczanie wartości (sumy) szerego potęgowego.");

                        //pobranie wartosci minimalnej parametru X
                        plPrzedzialA = plPobranieLiczbyWymiernej("Wpisz wartość minimalną X szeregu potęgowego: ");


                        //pobranie maksymalnej wartosci parametru X
                        do
                        {

                            plPrzedzialB = plPobranieLiczbyWymiernej("Wpisz wartość maksymalną X szeregu potęgowego: ");

                            if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisana wartość maksymalna X szeregu potęgowego: {0}", plPrzedzialB);

                            //sprawdzenie, czy maksymalna wartosc parametru X nie jest wieksza od minimalnej wartosci parametru X
                            if (plPrzedzialB < plPrzedzialA) Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, wartość maksymalna nie może być mniejsza od wartości minimalnej.");


                        } while (plPrzedzialB < plPrzedzialA);

                        //pobranie przyrostu parametru X
                        do
                        {

                            plZmiana = plPobranieLiczbyWymiernej("Wpisz przyrost X szeregu potęgowego (dodatnia mniejsza od jeden): ", false, false);

                            if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisany przyrost X szeregu potęgowego: {0}", plZmiana);

                            if (plZmiana >= 1) Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne mniejsze od 1.");


                        } while (plZmiana >= 1);

                        //pobranie dokladnosci obliczania sum szeregu
                        do
                        {

                            plEps = plPobranieLiczbyWymiernej("Wpisz dokładność obliczeń szeregu potęgowego (dodatnia mniejsza od jeden): ", false, false);

                            if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisana dokładność obliczeń szeregu potęgowego: {0}", plEps);

                            if (plEps >= 1) Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne mniejsze od 1.");


                        } while (plEps >= 1);

                        plX = plPrzedzialA;
                        Console.WriteLine("\n\t     X     |     Sumy szeregu w różnych postaciach");
                        do
                        {
                            plSumaSzeregu = (float)plObliczanieSumySzeregu(plX, plEps, out plLicznikWyrazowSzeregu);
                            Console.WriteLine("\t{0, 8:F2}   |{1, 10}|{1, 8:E2}|{1, 8:F2}|{1, 8:G2}", plX, plSumaSzeregu);
                            plX += plZmiana;
                        } while (plX <= plPrzedzialB);
                        break;


                    case ConsoleKey.C:
                        //wypisanie nazwy wybranej funkcji
                        float plEps_pierwiastka;
                        short plLicznikPierwiastka;
                        Console.WriteLine("\n\n\tWybrana funkcjonalność: Obliczanie wartości (sumy) szerego potęgowego.");
                        //pobranie wartosci minimalnej parametru X
                        plPrzedzialA = plPobranieLiczbyWymiernej("Wpisz wartość minimalną X szeregu potęgowego: ");


                        //pobranie maksymalnej wartosci parametru X
                        do
                        {

                            plPrzedzialB = plPobranieLiczbyWymiernej("Wpisz wartość maksymalną X szeregu potęgowego: ");

                            if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisana wartość maksymalna X szeregu potęgowego: {0}", plPrzedzialB);

                            //sprawdzenie, czy maksymalna wartosc parametru X nie jest wieksza od minimalnej wartosci parametru X
                            if (plPrzedzialB < plPrzedzialA) Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, wartość maksymalna nie może być mniejsza od wartości minimalnej.");


                        } while (plPrzedzialB < plPrzedzialA);

                        //pobranie przyrostu parametru X
                        do
                        {

                            plZmiana = plPobranieLiczbyWymiernej("Wpisz przyrost X szeregu potęgowego (dodatnia mniejsza od jeden): ", false, false);

                            if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisany przyrost X szeregu potęgowego: {0}", plZmiana);

                            if (plZmiana >= 1) Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne mniejsze od 1.");


                        } while (plZmiana >= 1);

                        //pobranie dokladnosci obliczania sum szeregu
                        do
                        {

                            plEps = plPobranieLiczbyWymiernej("Wpisz dokładność obliczeń szeregu potęgowego (dodatnia mniejsza od jeden): ", false, false);

                            if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisana dokładność obliczeń szeregu potęgowego: {0}", plEps);

                            if (plEps >= 1) Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne mniejsze od 1.");


                        } while (plEps >= 1);

                        //pobranie dokladnosci obliczania pierwiastka sum szeregu
                        do
                        {

                            plEps_pierwiastka = plPobranieLiczbyWymiernej("Wpisz dokładność obliczeń pierwiastka sumy szeregu potęgowego (dodatnia mniejsza od jeden): ", false, false);

                            if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisana dokładność obliczeń pierwiastka sumy szeregu potęgowego: {0}", plEps_pierwiastka);

                            if (plEps_pierwiastka >= 1) Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne mniejsze od 1.");


                        } while (plEps_pierwiastka >= 1);

                        plX = plPrzedzialA;
                        Console.WriteLine("\n\t     X     |  Sumy szeregu w różnych postaciach   |     Pierwiastek obliczonej sumy");
                        do
                        {
                            plSumaSzeregu = (float)plObliczanieSumySzeregu(plX, plEps, out plLicznikWyrazowSzeregu);
                            Console.WriteLine("\t{0, 8:F2}   |{1, 10}|{1, 8:E2}|{1, 8:F2}|{1, 8:G2}|{2, 10}", plX, plSumaSzeregu, plPierwiastekHerona(plSumaSzeregu, plEps_pierwiastka, out plLicznikPierwiastka));
                            plX += plZmiana;
                        } while (plX <= plPrzedzialB);

                        break;

                    case ConsoleKey.D:
                        //wypisanie nazwy wybranej funkcji
                        short plPierwiastek;
                        Console.WriteLine("\n\n\tWybrana funkcjonalność: Obliczanie wartości (sumy) szerego potęgowego.");
                        //pobranie wartosci minimalnej parametru X
                        plPrzedzialA = plPobranieLiczbyWymiernej("Wpisz wartość minimalną X szeregu potęgowego: ");


                        //pobranie maksymalnej wartosci parametru X
                        do
                        {

                            plPrzedzialB = plPobranieLiczbyWymiernej("Wpisz wartość maksymalną X szeregu potęgowego: ");

                            if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisana wartość maksymalna X szeregu potęgowego: {0}", plPrzedzialB);

                            //sprawdzenie, czy maksymalna wartosc parametru X nie jest wieksza od minimalnej wartosci parametru X
                            if (plPrzedzialB < plPrzedzialA) Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, wartość maksymalna nie może być mniejsza od wartości minimalnej.");


                        } while (plPrzedzialB < plPrzedzialA);


                        //pobranie przyrostu parametru X
                        do
                        {

                            plZmiana = plPobranieLiczbyWymiernej("Wpisz przyrost X szeregu potęgowego (dodatnia mniejsza od jeden): ", false, false);

                            if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisany przyrost X szeregu potęgowego: {0}", plZmiana);

                            if (plZmiana >= 1) Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne mniejsze od 1.");


                        } while (plZmiana >= 1);

                        //pobranie dokladnosci obliczania sum szeregu
                        do
                        {

                            plEps = plPobranieLiczbyWymiernej("Wpisz dokładność obliczeń szeregu potęgowego (dodatnia mniejsza od jeden): ", false, false);

                            if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisana dokładność obliczeń szeregu potęgowego: {0}", plEps);

                            if (plEps >= 1) Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne mniejsze od 1.");


                        } while (plEps >= 1);

                        //pobranie stopnia pierwiastka sum szeregu
                        plPierwiastek = (short)plPobranieLiczbyNaturalnej("Wpisz stopień pierwiastka sumy szeregu potęgowego: ", false);

                        //pobranie dokladnosci obliczania pierwiastka sum szeregu
                        do
                        {

                            plEps_pierwiastka = plPobranieLiczbyWymiernej("Wpisz dokładność obliczeń pierwiastka sumy szeregu potęgowego (dodatnia mniejsza od jeden): ", false, false);

                            if (plSledzenie) Console.WriteLine("\t\tŚLEDZENIE: Wpisana dokładność obliczeń pierwiastka sumy szeregu potęgowego: {0}", plEps_pierwiastka);

                            if (plEps_pierwiastka >= 1) Console.WriteLine("\n\tBłąd! Wpisano niedozwolony znak, dopuszczalne są tylko liczby wymierne mniejsze od 1.");


                        } while (plEps_pierwiastka >= 1);



                        plX = plPrzedzialA;
                        Console.WriteLine("\n\t     X     |  Sumy szeregu w różnych postaciach   |     Pierwiastek obliczonej sumy");
                        do
                        {
                            plSumaSzeregu = (float)plObliczanieSumySzeregu(plX, plEps, out plLicznikWyrazowSzeregu);
                            Console.WriteLine("\t{0, 8:F2}   |{1, 10}|{1, 8:E2}|{1, 8:F2}|{1, 8:G2}|{2, 10}", plX, plSumaSzeregu, plPierwiastekNewtona(plSumaSzeregu, plPierwiastek, plEps_pierwiastka, out plLicznikPierwiastka));
                            plX += plZmiana;
                        } while (plX <= plPrzedzialB);

                        break;

                }



                //zakonczenie dzialania programu 
                if (plWybranaFunkcjonalnosc.Key != ConsoleKey.X)
                {
                    Console.Write("\n\n\tNaciśnij dowolny klawisz aby kontynuować działanie programu... ");
                    Console.ReadKey();
                }

                Console.Clear();
            } while (plWybranaFunkcjonalnosc.Key != ConsoleKey.X);
            Console.WriteLine("\n\tAutor: Przemysław Lenczewski, 53514");
            Console.WriteLine("\tDzisiejsza data i godzina: {0}", DateTime.Now);
            Console.Write("\n\tNaciśnij dowolny klawisz... ");
            Console.ReadKey();
        }
    }
}
