using GasElektricMeter;
using static System.Net.Mime.MediaTypeNames;

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
                Console.WriteLine("║            Podaj Sposób obliczania statystyk           ║");
                Console.WriteLine("║            Sposób na listach   L   do pliku F          ║");
                Console.WriteLine("║                     lub zakończ   X                    ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");


                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "L":
                    case "l":
                        AddGradesToDataStatistics(true);
                        break;

                    case "F":
                    case "f":
                        AddGradesToDataStatistics(false);
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
            Console.WriteLine($"Dodano wartość z licznika {sender}u  ");
        }

        static void MeterPriceAdded(object sender, EventArgs arg)
        {
            Console.WriteLine($"Dodano nową cenę {sender}u");
        }

        private static void AddGradesToDataStatistics(bool InMemory)
        {
            if (true)
            {
                string firstName = GetDataFromUser("Podaj Rodzaj Licznika (Gaz  czy Prd) ");
                string lastName = GetDataFromUser(" Podaj jednostkę mocy  kWh   czy  m3");
                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                {
                    IMeter meter = InMemory ? new DataInMemory(firstName, lastName) : new DataInFile(firstName, lastName);
                    Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                Podaj aktualną cenę                     ║");
                    Console.WriteLine($"║        {meter.Name}u z - , - jako znak rozdzielajacy           ║");
                    Console.WriteLine("╚════════════════════════════════════════════════════════╝");

                    var price1 = Console.ReadLine();
                    meter.PriceAdded += MeterPriceAdded;
                    if (price1 != null)
                    {
                        meter.AddPrice(price1);
                    }

                    meter.GradeAdded += MeterGradeAdded;
                    EnterGrade(meter);

                    meter.ShowStatistics();
                }
                else
                {
                    Console.WriteLine("Nazwy rodzaju i mocy licznika nie mogą być puste");
                }
            }

        }

        private static void EnterGrade(IMeter meter)
        {
            while (true)
            {

                Console.WriteLine($"\nPodaj wartość licznika {meter.Name}lub wciśnij 'q'. ");
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
        private static string GetDataFromUser(string text)
        {
            Console.WriteLine(text);
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}



