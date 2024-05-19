using GasElektricMeter;

namespace GasElektricMeter
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║   Witam w programie licznika kosztów prądu i gazu      ║");
            Console.WriteLine("║ Licznik rejestruje dzienne wprowadzone wskazania oraz  ║");
            Console.WriteLine("║   podaje statystyki i aktuakny koszt zużycia prądu     ║");
            Console.WriteLine("║      NALEŻY PODAĆ CO NAJMNIEJ DWA ODCZYTY !!!!!        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            bool CloseProgram = false;
            while (!CloseProgram)
            {

                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("║     Podaj licznik który chcesz uzupełnić/sprawdzić     ║");
                Console.WriteLine("║       Licznik prądu E lub e licznik gazu G lub g       ║");
                Console.WriteLine("║                     lub zakończ   X                    ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");


                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "G":
                    case "g":
                        AddGradesToEmployee(true);
                        break;

                    case "E":
                    case "e":
                        AddGradesToEmployee(false);
                        break;

                    case "X":
                    case "x":
                        CloseProgram = true;
                        break;

                    default:

                        Console.WriteLine("Niepoprawny wybór.\n");
                        continue;
                }
            }
            Console.WriteLine("\n\n Dziękujemy za skożystanie z aplikacji :) ");
        }
        static void MeterGradeAdded(object sender, EventArgs arg)
        {
            Console.WriteLine($"Dodano wartość z licznika {sender}  ");
        }

        static void PriceAdded(object sender, EventArgs arg)
        {
            Console.WriteLine($"Dodano nową cenę {sender}");
        }

        private static void AddGradesToEmployee(bool InMemory)
        {
            if (true)
            {               
                IMeter meter = InMemory ? new GasInMemory("gaz ", "m3 ") : new EnergyInFile("prąd", "kWh");
                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                Podaj aktualną cenę                     ║");
                Console.WriteLine($"║         {meter.Name} z - , - jako znak rozdzielajacy           ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                
                var price1 = Console.ReadLine();
                if (price1 != null)
                {
                    meter.AddPrice(price1);
                }
                meter.PriceAdded += MeterGradeAdded;
                EnterGrade(meter);
                meter.GradeAdded += MeterGradeAdded;
                meter.ShowStatistics();
            }

        }

        private static void EnterGrade(IMeter meter)
        {
            while (true)
            {
                meter.GradeAdded += MeterGradeAdded;
                Console.WriteLine($" podaj wartość licznika {meter.Name}lub wciśnij 'q'. ");
                var input = Console.ReadLine();

                if (input == "q" || input == "Q")
                {
                    break;
                }
                try
                {
                    meter.AddGrade(input);

                }

                catch (Exception e)
                {
                    Console.WriteLine($"Znaleziono wyjątek :  {e.Message}");
                }
            }
        }
    }
}



