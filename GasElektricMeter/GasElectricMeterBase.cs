using System.Diagnostics.Metrics;

namespace GasElektricMeter
{
    public abstract class GasElectricMeterBase : IMeter
    {
        public delegate void GradeAddedDelegdate(object sender, EventArgs args);

        public event GradeAddedDelegdate GradeAdded;

        public GasElectricMeterBase(string name, string surname)

        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }


        public abstract void AddGrade(float grade);

        public abstract void AddGrade(double grade);

        public abstract void AddGrade(string grade);

        public abstract void AddGrade(int grade);

        public abstract void AddGrade(char grade);

        public abstract Statistics GetStatisticsWithForeEach();
    }
}
