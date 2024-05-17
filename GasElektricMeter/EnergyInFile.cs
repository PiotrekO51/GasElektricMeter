namespace GasElektricMeter
{
    public class EnergyInFile : GasEnergyMeterBase
    {
        public delegate void GradeAddedDelegdate(object sender, EventArgs args);

        public event GradeAddedDelegdate GradeAdded;
        public event GradeAddedDelegdate PriceAdded;

        private const string fileName = "Energy.txt";

        private List<float> price = new List<float>();

        public EnergyInFile(string name, string surname)
            : base(name, surname)
        {

        }

        public override void AddPrice(float grade)
        {
            if (grade >0)
            {
                this.price.Add(grade);

                if (PriceAdded != null)
                {
                    PriceAdded(this.Name, new EventArgs());
                }
            }
        }
        public override void AddPrice(string grade)
        {
            float number;
            float.TryParse(grade, out number);
            this.AddPrice(number);
        }


        public override void AddGrade(float grade)
        {
            float gradeAsFloat = grade;
            this.AddGrade(gradeAsFloat);
        }

        public override void AddGrade(string grade)
        {
            float number;
            using (var writer = File.AppendText(fileName))
            {
                float.TryParse(grade, out number);

                if (number >= 1)
                {
                    writer.WriteLine(number);

                    if (GradeAdded != null)
                    {
                        GradeAdded(this.Name, new EventArgs());
                    }
                }
                else
                {
                    throw new Exception("zła wartość");
                }
            }
        }


        public override Statistics GetStatisticsWithForeEach()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.CountStatistics(gradesFromFile);
            return result;
        }
        public List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText($"{fileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {

                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();

                    }
 
                }
            }
            return grades;
        }

      

        public   Statistics CountStatistics(List<float> grades)
        {
            var statistics = new Statistics();
            var grades1 = new List<float>();
            int counter2 = 0;

            foreach (var grade in grades)

            {
                grades1 = grades;
                counter2++;
            }

            for (var i = counter2 - 1; i >= 1; i--)
            {
                statistics.AddGrade(grades1[i] - grades1[i - 1]);
            }
            return statistics;
        }
        public override Statistics GetPrice()
        {
            var statistics = new Statistics();
            var price1 = new List<float>();

            if (price != null)
            {
               statistics.AddGrade(price[0]);
            }

            return statistics;
        }
        public void ShowStatistics2()
        {
            
        }
    }
}
