namespace GasElektricMeter.Test
{
    public class Tests
    {
        [Test]
        public void StatisticTest()
        {
            var gasmeter = new GasMeter("Licznik", "Pr¹d");
            gasmeter.AddGrade(35);
            gasmeter.AddGrade(50);
            gasmeter.AddGrade(70);
            gasmeter.AddGrade(100);

            var statistics = gasmeter.GetStatisticsWithForeEach2();

            Assert.AreEqual(30, statistics.Max);

        }

        [Test]
        public void StatisticTest2()
        {
            var gasmeter = new GasMeter("Licznik", "Pr¹d");
            gasmeter.AddGrade(35);
            gasmeter.AddGrade(50);
            gasmeter.AddGrade(70);
            gasmeter.AddGrade(100);

            var statistics = gasmeter.GetStatisticsWithForeEach2();

            Assert.AreEqual(15, statistics.Min);

        }

        [Test]
        public void StatisticTest3()
        {
            var gasmeter = new GasMeter("Licznik", "Pr¹d");
            gasmeter.AddGrade(35);
            gasmeter.AddGrade(50);
            gasmeter.AddGrade(70);
            gasmeter.AddGrade(100);

            var statistics = gasmeter.GetStatisticsWithForeEach2();

            Assert.AreEqual(Math.Round(21.667, 3), Math.Round(statistics.Average, 3));
        }
    }
}