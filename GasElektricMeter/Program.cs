using GasElektricMeter;

var electrometer = new ElectroMeter("Licznik", "Prąd");
var gasmeter = new GasMeter("Licznik", "Gaz");


electrometer.GradeAdded += MeterGradeAdded;
gasmeter.GradeAdded += MeterGradeAdded;


Console.WriteLine("╔════════════════════════════════════════════════════════╗");
Console.WriteLine("║   Witam w programie licznika kosztów prądu i gazu      ║");
Console.WriteLine("║ Licznik rejestruje dzienne wprowadzone wskazania oraz  ║");
Console.WriteLine("║   podaje statystyki i aktuakny koszt zużycia prądu     ║");
Console.WriteLine("║      NALEŻY PODAĆ CO NAJMNIEJ DWA ODCZYTY !!!!!        ║");
Console.WriteLine("╚════════════════════════════════════════════════════════╝");


Console.WriteLine("╔════════════════════════════════════════════════════════╗");
Console.WriteLine("║     Podaj licznik który chcesz uzupełnić/sprawdzić     ║");
Console.WriteLine("║       Licznik prądu E lub e licznik gazu G lub g       ║");
Console.WriteLine("╚════════════════════════════════════════════════════════╝");
var input = Console.ReadLine();



Console.WriteLine("╔════════════════════════════════════════════════════════╗");
Console.WriteLine("║                   Podaj aktualny koszt                 ║");
Console.WriteLine("║             jednej kWh prądu lub jednego m3 gazu       ║");
Console.WriteLine("╚════════════════════════════════════════════════════════╝");

string tarifE = Console.ReadLine();
float price1 = float.Parse(tarifE);


void MeterGradeAdded(object sender, EventArgs arg)
{
Console.WriteLine("Dodano wartość z licznika");
}

while (input == "E" || input == "e")
{
 Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
 Console.WriteLine("║ Podaj kolejną wartość z liczika Prądu lub zakończ wpisując Q  ║");
 Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");

    var input2 = Console.ReadLine();
    if (input2 == "q" ||input2 == "Q")
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

if (input == "E" || input == "e")
{

    var statistics = electrometer.GetStatisticsWithForeEach();
    var sta = statistics.Sum * price1 * 1.23;
    Console.WriteLine("╔════════════════════════════════════════════════════╗");
    Console.WriteLine("║ Wyniki ststystyczne licznika energi elektrycznej   ║");
    Console.WriteLine("╚════════════════════════════════════════════════════╝");
    Console.WriteLine($"║ Suma zużycia prądu            kWh ║{statistics.Sum}     ");
    Console.WriteLine($"║ Maksymalne dzinne zużycie     kWh ║{statistics.Max}     ");
    Console.WriteLine($"║ Średnia zużycie               kWh ║{statistics.Average:N2}  ");
    Console.WriteLine($"║ Minimalne zużycie             kWh ║{statistics.Min}     ");
    Console.WriteLine($"║ Ilość dni pracy               dni ║{statistics.Count}    ");
    Console.WriteLine($"║ Koszt całkowity zł brutto VAt 23% ║{sta:N2}");
    Console.WriteLine("╚════════════════════════════════════════════════════╝");
}
if (input == "G" || input == "g")
{

    var statistics = gasmeter.GetStatisticsWithForeEach();
    var sta = statistics.Sum * price1 * 1.23;
    Console.WriteLine("╔════════════════════════════════════════════════════╗");
    Console.WriteLine("║ Wyniki ststystyczne licznika gazu                  ║");
    Console.WriteLine("╚════════════════════════════════════════════════════╝");
    Console.WriteLine($"║ Suma zużycia gazu             m3  ║{statistics.Sum}     ");
    Console.WriteLine($"║ Maksymalne dzinne zużycie     m3  ║{statistics.Max}     ");
    Console.WriteLine($"║ Średnia zużycie               m3  ║{statistics.Average:N2}  ");
    Console.WriteLine($"║ Minimalne zużycie             m3  ║{statistics.Min}     ");
    Console.WriteLine($"║ Ilość dni pracy               dni ║{statistics.Count}     ");
    Console.WriteLine($"║ Koszt całkowity zł brutto VAt 23% ║{sta:N2}");
    Console.WriteLine("╚════════════════════════════════════════════════════╝");
}