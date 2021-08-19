namespace CSharpFeatures
{
    public class Coffe
    {
        public string CoffeType { get; set; }
        public Coffe()
        {
        }

        public Coffe(string type)
        {
            this.CoffeType = type;
        }

        public override string ToString()
        {
            return CoffeType;
        }
    }
}