namespace GasElektricMeter
{
    public abstract class Person
    {
        public Person(string name, string surname, string numer)
        {
            this.Name = name;
            this.Surname = surname;
            this.Numer = numer;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public string Numer { get; private set; }
    }
}
