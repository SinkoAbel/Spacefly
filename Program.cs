using System;

namespace spacefly
{
    class Program
    {
        static void Main(string[] args)
        {

            bool exit = false;


            do
            {

                Console.Clear();

                Console.Write("Kérjük válasszon az alábbi menüpontok közül: ");
                Console.WriteLine();

                Console.WriteLine("1. Repülési idő kiszámítása");
                Console.WriteLine("2. Sugárzás hatásainak kiszámítása");
                Console.WriteLine("3. Űrcsata klingonokkal");
                Console.WriteLine();

                ConsoleKeyInfo pushedButton = Console.ReadKey(true);

                byte speed, distance, tripDays;
                Random rnd = new Random();





                switch (pushedButton.Key)
                {
              
                    /// 1. Repülési idő kiszámítása
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:

                        Console.Clear();

                        do
                        {
                            Console.Write("Kérem adja meg az űrhajó sebességét (Maximum 255 milló km/nap): ");
                        } while (!byte.TryParse(Console.ReadLine(), out speed) || speed >= 255);

                        do
                        {
                            Console.Write("Kérem adja meg az utazás távolságát (Maximum 255 milló km): ");
                        } while (!byte.TryParse(Console.ReadLine(), out distance) || distance >= 255);


                        tripDays = (byte)(distance / speed);

                        Console.WriteLine();
                        Console.WriteLine("A megadott paraméterekkel az űrutazás {0} napot venne igénybe.", tripDays);

                        break;





                    /// 2. Sugárzás hatásainak kiszámítása
                    case ConsoleKey.D2 or ConsoleKey.NumPad2:

                        Console.Clear();

                        int dailyRadiationDose = rnd.Next(1000, 50001);

                        do
                        {
                            Console.Write("Kérem adja meg a repülés időtartamát (Maximum 255 nap): ");
                        } while (!byte.TryParse(Console.ReadLine(), out tripDays) || tripDays >= 255);

                        int receivedDose = dailyRadiationDose * tripDays;
                        const int dangerousDose = 1000000;


                        if (receivedDose > dangerousDose)
                            Console.WriteLine("\nFigyelem!!!\nA repülési idő alatt a megengedettnél nagyobb dózisú sugárzás fogja érni,\nmely halálos lehet!");
                        else
                            Console.WriteLine("\nAz út alatt nem fogja túllépni a megengedett sugárdózist!\nAz utazás biztonságos!");


                        break;




                    /// 3. Űrcsata a klingonokkal
                    case ConsoleKey.D3 or ConsoleKey.NumPad3:

                        Console.Clear();

                        int humanFirePower, klingonFirePower;
                        int humanEfficiency = rnd.Next(1, 101);
                        int klingonEfficiency = rnd.Next(1, 101);

                        bool klingonWin;
                        bool humanWin;

                        do
                        {

                            klingonWin = false;
                            humanWin = false;


                            Console.WriteLine("A klingonok a Qo’nos bolygón kifejlődött harcias humanoid faj.");
                            Console.WriteLine("Büszke, hagyományőrző nép, akik számára a becsület a legfontosabb.\nEmiatt sokszor szembekerülnek a Föderációval.");
                            Console.WriteLine();

                            Console.WriteLine("Jelenleg összeütközésbe kerültünk velük a Khitomer bolygó közelében.");
                            Console.WriteLine();

                            Console.Write("Egy az űrhajó rendszerét ért sérülés miatt elveszett a tűzerőt szabályzó érték.\n");
                            Console.WriteLine("Neked mint a hajón lévő főmérnöknek a feladatod, hogy manuálisan határozd meg ezt az értéket.");
                            Console.WriteLine();

                            do
                            {
                                Console.Write("Add meg a hiányzó értéket (100 és 1000 között): ");


                            } while (!int.TryParse(Console.ReadLine(), out humanFirePower) || humanFirePower < 100 || humanFirePower > 1000);



                            do
                            {
                                Console.Write("\nAdd meg a klingonok űrhajójának tűzerejét is (100 és 1000 között): ");
                            } while (!int.TryParse(Console.ReadLine(), out klingonFirePower) || klingonFirePower < 100 || klingonFirePower > 1000);



                            int humanPerformance = humanFirePower * humanEfficiency;
                            int klingonPerformance = klingonFirePower * klingonEfficiency;

                            if (humanPerformance > klingonPerformance)
                            {
                                humanWin = true;
                                Console.WriteLine();
                                Console.WriteLine("Győzelem!\nSikeresen határoztad meg az értéket! Hatalmas szereped volt a küldetésben! Szép munka!");
                                Console.WriteLine();

                            }
                            else if (humanPerformance == klingonPerformance)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Az ütközet döntetlennel végződött. A következő ütközetben mi győzünk!");
                                Console.WriteLine();

                            }
                            else
                            {
                                klingonWin = true;
                                Console.WriteLine();
                                Console.WriteLine("Vesztettünk...a klingonok fölénk kerekedtek.");
                                Console.WriteLine();
                            }



                        } while (klingonWin == humanWin);



                        break;



                    case ConsoleKey.Escape:
                        exit = true;

                        break;


                    default:
                        Console.WriteLine("Rossz billentyűt nyomtál!");
                        break;

                }


                if (!exit)
                    Console.ReadKey();

            } while (!exit);
        }
    }
}
