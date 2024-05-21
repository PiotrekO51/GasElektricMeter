
using System.Diagnostics.Metrics;

namespace GasElektricMeter
{
    public class DataInMemory : DataBase
    {
        public delegate void GradeAddedDelegdate(object sender, EventArgs args);

        public event GradeAddedDelegdate GradeAdded;
        public event GradeAddedDelegdate PriceAdded;

        private List<float> grades = new List<float>();
        private List<float> price = new List<float>();

        public DataInMemory(string name, string surname)
                : base(name, surname)
        {

        }

        public override void AddPrice(float grade)
        {
            if (grade > 0)
            {
                this.price.Add(grade);

                if (grade >0)
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

        public override void AddGrade(float grade)
        {
            if (grade >= 0)
            {
                
                    this.grades.Add(grade);

                    if (grade != null)
                    {
                        MeterGradeAdded();
                    }
                
            }
        }

        public override void AddGrade(string grade)
        {
            float number;
            float.TryParse(grade, out number);
            this.AddGrade(number);
        }

        public override Statistics GetStatisticsWithForeEach()
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
            else 
            {
                statistics.AddGrade(0);
            }

            return statistics;
        }
         
    }
}
