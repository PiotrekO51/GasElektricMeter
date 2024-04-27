namespace GasElektricMeter
{
    public class ElectroMeter : GasElectricMeterBase
    {
        public delegate void GradeAddedDelegdate(object sender, EventArgs args);

        public event GradeAddedDelegdate GradeAdded;

        private const string fileName = "Eenegy.Text";

        public ElectroMeter(string name, string surname)
            : base(name, surname)
        {

        }

        public override void AddGrade(float grade)
        {
            float gradeAsFloat = grade;
            this.AddGrade(gradeAsFloat);
        }

        public override void AddGrade(int grade)
        {
            float gradeAsFloat = grade;
            this.AddGrade(gradeAsFloat);
        }

        public override void AddGrade(double grade)
        {
            float gradeAsFloat = (float)grade;
            this.AddGrade(gradeAsFloat);
        }

        public override void AddGrade(char grade)
        {
            float gradeAsFloat = (float)grade;
            this.AddGrade(gradeAsFloat);
        }


        public override void AddGrade(string grade)
        {
            float number;
            using (var writer = File.AppendText(fileName))
            {
                float.TryParse(grade, out number);

                if (number >= 0)
                {
                    writer.WriteLine(number);

                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
                else
                {
                    Console.WriteLine("Zła wartość");
                }
            }
        }


        public override Statistics GetStatisticsWithForeEach()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.CountStatistics(gradesFromFile);
            return result;
        }
        private List<float> ReadGradesFromFile()
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
                    if (reader != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }

                }
            }
            return grades;
        }

        private Statistics CountStatistics(List<float> grades)
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
    }
}
