using static GasElektricMeter.GasElectricMeterBase;

namespace GasElektricMeter
{
    public interface IMeter
    {
        string Name { get; }

        string Surname { get; }

        void AddGrade(float grade);

        void AddGrade(int grade);

        void AddGrade(double grade);

        void AddGrade(string grade);

        void AddGrade(char grade);

        event GradeAddedDelegdate GradeAdded;


        Statistics GetStatisticsWithForeEach();

        
    }
}
