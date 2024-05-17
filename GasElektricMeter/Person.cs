namespace GasElektricMeter
{
    public abstract class Person
    {
        public Person(string nameMeter, string surnameMeter)
        {
            this.Name = nameMeter;
            this.Surname = surnameMeter;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
    }
}
