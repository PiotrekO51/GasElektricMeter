using static GasElektricMeter.DataBase;

namespace GasElektricMeter
{
    public interface IMeter
    {
        string Name { get; }

        string Surname { get; }

        string Numer {  get; }

        void AddPrice(float grade);

        void AddPrice(string grade);

        void AddGrade(float grade);

        void AddGrade(string grade);       

        event GradeAddedDelegdate GradeAdded;
        event GradeAddedDelegdate PriceAdded;

        Statistics GetStatisticsWithForeEach();
        void ShowStatistics();
    }
       
}
