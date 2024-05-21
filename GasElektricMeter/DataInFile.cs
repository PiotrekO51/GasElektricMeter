namespace GasElektricMeter
{
    public class DataInFile : DataBase
    {
        public delegate void GradeAddedDelegdate(object sender, EventArgs args);

        public event GradeAddedDelegdate GradeAdded;
        public event GradeAddedDelegdate PriceAdded;

        
        private const string fileName = (".txt");
        private string fullfileName;

        private List<float> price = new List<float>();

        public DataInFile(string name, string surname, string numer)
            : base(name, surname, numer)
        {
            fullfileName = $"{name}_{numer}{fileName}";
        }
       
        public override void AddPrice(float grade)
        {
            if (grade > 0)
            {
                this.price.Add(grade);

                if (grade > 0)
                {
                    MeterPriceAdded();
                }
            }
        }
        public override void AddPrice(string grade)
        { 
            float number;
            float.TryParse(grade, out number);
            this.AddPrice(number);
        }
        
        public override void AddGrade(string grade)
        {
            
            float number;
            using (var writer = File.AppendText(fullfileName))
            {
                float.TryParse(grade, out number);

                if (number > 0)
                {
                    writer.WriteLine(number);

                    if (grade != null)
                    {
                        MeterGradeAdded();
                    }
                }
                else
                {
                    throw new Exception("zła wartość");
                }
            }
        }

        public override void AddGrade(float grade)
        {
            //float gradeAsFloat = grade;
            //this.AddGrade(gradeAsFloat);

            using (var writer = File.AppendText(fullfileName))
            {

                if (grade > 0)
                {
                    writer.WriteLine(grade);

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
            if (File.Exists(fullfileName))
            {
                using (var reader = File.OpenText($"{fullfileName}"))
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

        public Statistics CountStatistics(List<float> grades)
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
        
    }
}
