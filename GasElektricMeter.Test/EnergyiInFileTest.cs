namespace GasElektricMeter.Test
{
    public class EnergyInFileTest
    {
        [Test]
        public void StatisticTest()
        {
            if (File.Exists("Energy.txt"))
            {
                File.Delete("Energy.txt");
            }

            var electrometer = new EnergyInFile("pr¹d", "kWh");
            electrometer.AddGrade("35");
            electrometer.AddGrade("50");
            electrometer.AddGrade("70");
            electrometer.AddGrade("100");

            var statistics = electrometer.GetStatisticsWithForeEach();

            Assert.AreEqual(30, statistics.Max);


        }

        [Test]
        public void StatisticTest2()
        {
            if (File.Exists("Energy.txt"))
            {
                File.Delete("Energy.txt");
            }
            var electrometer = new EnergyInFile("pr¹d", "kWh");
            electrometer.AddGrade(35);
            electrometer.AddGrade(50);
            electrometer.AddGrade(70);
            electrometer.AddGrade(100);

            var statistics = electrometer.GetStatisticsWithForeEach();

            Assert.AreEqual(15, statistics.Min);

        }

        [Test]
        public void StatisticTest3()
        {
            if (File.Exists("Energy.txt"))
            {
                File.Delete("Energy.txt");
            }
            var electrometer = new EnergyInFile("pr¹d", "kWh");
            electrometer.AddGrade(35);
            electrometer.AddGrade(50);
            electrometer.AddGrade(70);
            electrometer.AddGrade(100);

            var statistics = electrometer.GetStatisticsWithForeEach();

            Assert.AreEqual(Math.Round(21.667, 3), Math.Round(statistics.Average, 3));
        }
    }
}