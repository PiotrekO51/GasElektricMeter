namespace GasElektricMeter
{
    public class GasMeter : GasElectricMeterBase
    {
        public delegate void GradeAddedDelegdate(object sender, EventArgs args);

        public event GradeAddedDelegdate GradeAdded;

        private const string fileName2 = "gas.Text";

        private List<float> grades2 = new List<float>();

        public GasMeter(string name, string surname)
                : base(name, surname)
        {

        }

        public override void AddGrade(float grade)
        {
            if (grade >= 1)
            {
                this.grades2.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
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
            using (var writer = File.AppendText(fileName2))
            {
                float.TryParse(grade, out number);

                if (number >= 1)
                {
                    writer.WriteLine(number);

                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
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
            if (File.Exists(fileName2))
            {
                using (var reader = File.OpenText($"{fileName2}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if (reader != null)
                        {
                            var number = float.Parse(line);
                            grades.Add(number);
                            line = reader.ReadLine();
                        }
                        else if (GradeAdded != null)
                        {

                            GradeAdded(this, new EventArgs());
                        }
                    }

                }
            }
            return grades;
        }
       
        public Statistics CountStatistics(List<float>grades)
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

        public override Statistics GetStatisticsWithForeEach2()
        {
            
            var result = this.CountStatistics();
            return result;
        }
        
        public override Statistics CountStatistics()
        {
            var statistics = new Statistics();
            var grades1 = new List<float>();
            int counter2 = 0;

            foreach (var grade in grades2)

            {
                grades1 = grades2;
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
