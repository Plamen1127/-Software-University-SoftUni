namespace Zoo
{
    public class Animal
    {
        public Animal(string species, string diet, double weigth, double length)
        {
            Species = species;
            Diet = diet;
            Weigth = weigth;
            Length = length;
        }

        public string Species { get; set; }
        public string Diet { get; set; }
        public double Weigth { get; set; }
        public double Length { get; set; }

        public override string ToString()
        {

            return $"The {Species} is a {Diet} and weighs {Weigth} kg.";
        }
    }
}
