using System.Diagnostics.Metrics;

namespace GasElektricMeter
{
    public abstract class GasEnergyMeterBase : IMeter
    {
        public delegate void GradeAddedDelegdate(object sender, EventArgs args);

        public event GradeAddedDelegdate GradeAdded;

        public event GradeAddedDelegdate PriceAdded;

        public GasEnergyMeterBase(string name, string surname)

        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }
 
        public abstract void AddPrice(float grade);

        public abstract void AddPrice(string grade);

        public abstract void AddGrade(float grade);

        public abstract void AddGrade(string grade);
        
        public abstract Statistics GetStatisticsWithForeEach();

        public abstract Statistics GetPrice();
        public void ShowStatistics()
        {
            var statistics = GetStatisticsWithForeEach();
            var ststistics2 = GetPrice();
            var price = ststistics2.Cost;
            var sta1 = statistics.Sum * price * 1.23;

            if (statistics.Count != 0)
            {
                Console.WriteLine("╔════════════════════════════════════════════════════╗");
                Console.WriteLine("║ Wyniki ststystyczne licznika                       ║");
                Console.WriteLine("╚════════════════════════════════════════════════════╝");
                Console.WriteLine($"║ Aktualne ststystyki licznik {Name}       ");
                Console.WriteLine($"║ Suma zużycia licznik           {Surname} ║{statistics.Sum}     ");
                Console.WriteLine($"║ Maksymalne dzinne zużycie      {Surname} ║{statistics.Max}     ");
                Console.WriteLine($"║ Średnia zużycie                {Surname} ║{statistics.Average :N2}  ");
                Console.WriteLine($"║ Minimalne zużycie              {Surname} ║{statistics.Min}     ");
                Console.WriteLine($"║ Ilość dni pracy                {Surname} ║{statistics.Count}    ");
                Console.WriteLine($"║ Aktualna cena                  zł  ║{price}    ");
                Console.WriteLine($"║ Koszt całkowity zł brutto VAt  23% ║{sta1:N2}");
                Console.WriteLine("╚═════════════════════════════════════════════════════");
            }
            else { Console.WriteLine(" Statystyki są puste "); }
        }
        public void MeterGradeAdded()
        {
            if (GradeAdded != null)
            {
                GradeAdded(this.Name, new EventArgs());
            }
        }
        public void MeterPriceAdded()
        {
            if (PriceAdded != null)
            {
                PriceAdded(this.Name, new EventArgs());
            }
        }
    }    
}
