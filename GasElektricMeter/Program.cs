using GasElektricMeter;

var electrometer = new EnergyInFile("prąd", "kWh");
var gasmeter = new GasInMemory("gaz ", "m3 ");


electrometer.GradeAdded += MeterGradeAdded;
gasmeter.GradeAdded += MeterGradeAdded;
gasmeter.PriceAdded += PriceAdded;
electrometer.PriceAdded += PriceAdded;

Console.WriteLine("╔════════════════════════════════════════════════════════╗");
Console.WriteLine("║   Witam w programie licznika kosztów prądu i gazu      ║");
Console.WriteLine("║ Licznik rejestruje dzienne wprowadzone wskazania oraz  ║");
Console.WriteLine("║   podaje statystyki i aktuakny koszt zużycia prądu     ║");
Console.WriteLine("║      NALEŻY PODAĆ CO NAJMNIEJ DWA ODCZYTY !!!!!        ║");
Console.WriteLine("╚════════════════════════════════════════════════════════╝");

Console.WriteLine("╔════════════════════════════════════════════════════════╗");
Console.WriteLine("║     Podaj licznik który chcesz uzupełnić/sprawdzić     ║");
Console.WriteLine("║       Licznik prądu E lub e licznik gazu G lub g       ║");
Console.WriteLine("║                     lub zakończ   X                    ║");
Console.WriteLine("╚════════════════════════════════════════════════════════╝");
var input = Console.ReadLine();

if (input == "G" || input == "g")
{
    Console.WriteLine("╔════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                Podaj aktualną cenę                     ║");
    Console.WriteLine("║         gazu z - , - jako znak rozdzielajacy           ║");
    Console.WriteLine("╚════════════════════════════════════════════════════════╝");

    var price1 = Console.ReadLine();
    if (price1 != null)
    {
        gasmeter.AddPrice(price1);
    }
}
if (input == "E" || input == "e")
{
    Console.WriteLine("╔════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                 Podajaktualną cenę                     ║");
    Console.WriteLine("║         prądu z - , - jako znak rozdzielajacy          ║");
    Console.WriteLine("╚════════════════════════════════════════════════════════╝");

    var price1 = Console.ReadLine();
    if (price1 != null)
    {
        electrometer.AddPrice(price1);
    }
}
void MeterGradeAdded(object sender, EventArgs arg)
{
    Console.WriteLine($"Dodano wartość z licznika {sender}  ");
}

void PriceAdded(object sender, EventArgs arg)
{
    Console.WriteLine($"Dodano nową cenę {sender}");
}


while (input == "E" || input == "e")
{
    Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║ Podaj kolejną wartość z liczika Prądu lub zakończ wpisując Q  ║");
    Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");

    var input2 = Console.ReadLine();
    if (input2 == "q" || input2 == "Q")
    {
        break;
    }

    try
    {
        if (input2 != null)
        {

            electrometer.AddGrade(input2);
        }
    }

    catch (Exception e)
    {
        Console.WriteLine($"Znaleziono wyjątek :  {e.Message}");
    }
}


while (input == "G" || input == "g")
{

    Console.WriteLine("╔════════════════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║ Podaj kolejną wartość  wartość z liczika lub gazu zakończ wpisując Q   ║");
    Console.WriteLine("╚════════════════════════════════════════════════════════════════════════╝");

    var input2 = Console.ReadLine();

    if (input2 == "q" || input2 == "Q")
    {
        break;
    }

    try
    {
        if (input2 != null)
        {

            gasmeter.AddGrade(input2);
        }
    }

    catch (Exception e)
    {
        Console.WriteLine($"Znaleziono wyjątek :  {e.Message}");
    }
}

if (input == "G" || input == "g")
{
    gasmeter.ShowStatistics();
}
else if (input == "E" || input == "e")
{

    electrometer.ShowStatistics();
}


