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

            var energy = new EnergyInFile("pr�d", "kWh");
            energy.AddGrade(35);
            energy.AddGrade(50);
            energy.AddGrade(70);
            energy.AddGrade(100);

            var statistics = energy.GetStatisticsWithForeEach();

            Assert.AreEqual(30, statistics.Max);


        }

        [Test]
        public void StatisticTest2()
        {
            if (File.Exists("Energy.txt"))
            {
                File.Delete("Energy.txt");
            }
            var energy = new EnergyInFile("pr�d", "kWh");
            energy.AddGrade(35);
            energy.AddGrade(50);
            energy.AddGrade(70);
            energy.AddGrade(100);

            var statistics = energy.GetStatisticsWithForeEach();

            Assert.AreEqual(15, statistics.Min);

        }

        [Test]
        public void StatisticTest3()
        {
            if (File.Exists("Energy.txt"))
            {
                File.Delete("Energy.txt");
            }
            var energy = new EnergyInFile("pr�d", "kWh");
            energy.AddGrade(35);
            energy.AddGrade(50);
            energy.AddGrade(70);
            energy.AddGrade(100);

            var statistics = energy.GetStatisticsWithForeEach();

            Assert.AreEqual(Math.Round(21.667, 3), Math.Round(statistics.Average, 3));
        }
    }
}