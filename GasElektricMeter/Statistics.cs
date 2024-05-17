namespace GasElektricMeter
{
    public class Statistics
    {
        public float Cost { get; private set; }
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public float Count { get; private set; }

        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }


        public Statistics()
        {
            this.Cost = 0;
            this.Count = 0;
            this.Sum = 0;
            
            this.Min = float.MaxValue;
            this.Max = float.MinValue;
        }
        public void AddGrade(float grade)
        {
            this.Cost += grade;
            this.Count++;
            this.Sum += grade;
            this.Min = Math.Min(grade, this.Min);
            this.Max = Math.Max(grade, this.Max);

        }
        public void AddPrice(float grade)
        {
            
        }
    }
}
