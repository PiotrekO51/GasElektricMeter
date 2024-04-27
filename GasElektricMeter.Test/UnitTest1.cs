namespace GasElektricMeter.Test
{
    public class Tests
    {
        [Test]
        public void StatisticTest()
        {
            var gasmeter = new GasMeter("Licznik", "Pr¹d");

            gasmeter.AddGrade(35);
            gasmeter.AddGrade(45);
            gasmeter.AddGrade(60);
            gasmeter.AddGrade(80);

            var statistics = gasmeter.CountStatistics();

            Assert.AreEqual(20, statistics.Max);

        }

        [Test]
        public void StatisticTest2()
        {
            var gasmeter = new GasMeter("Licznik", "Pr¹d");

            gasmeter.AddGrade(35);
            gasmeter.AddGrade(45);
            gasmeter.AddGrade(60);
            gasmeter.AddGrade(80);

            var statistics = gasmeter.CountStatistics();

            Assert.AreEqual(10, statistics.Min);

        }

        [Test]
        public void StatisticTest3()
        {
            var gasmeter = new GasMeter("Licznik", "Pr¹d");

            gasmeter.AddGrade(35);
            gasmeter.AddGrade(45);
            gasmeter.AddGrade(60);
            gasmeter.AddGrade(80);

            var statistics = gasmeter.CountStatistics();

            Assert.AreEqual(15, statistics.Average);
        }
    }