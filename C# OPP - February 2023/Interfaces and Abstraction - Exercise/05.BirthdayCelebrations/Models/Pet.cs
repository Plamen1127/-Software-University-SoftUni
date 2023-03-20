using BirthdayCelebrations.Models.Interfaces;


namespace BirthdayCelebrations.Models
{
    public class Pet : INamebale, IBirthable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }

        public string Birthdate { get;set; }
    }
}
