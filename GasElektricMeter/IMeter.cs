using static GasElektricMeter.GasEnergyMeterBase;

namespace GasElektricMeter
{
    public interface IMeter
    {
        string Name { get; }

        string Surname { get; }

        void AddPrice(float grade);

        void AddPrice(string grade);

        void AddGrade(float grade);

        void AddGrade(string grade);
        //void GradeAdded(float grade);
        //void PriceAdded(float grade);

        event GradeAddedDelegdate GradeAdded;
        event GradeAddedDelegdate PriceAdded;

        Statistics GetStatisticsWithForeEach();
        void ShowStatistics();
    }
       
}
