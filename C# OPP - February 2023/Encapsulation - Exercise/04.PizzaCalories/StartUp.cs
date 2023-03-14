using System;


namespace PizzaCallories.Models
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                string[] pizzaData = Console.ReadLine().Split();
                string[] doughData = Console.ReadLine().Split();

                Dough dough = new(doughData[1], doughData[2], double.Parse(doughData[3]));

                string pizzaName = pizzaData[1];

                Pizza pizza = new(pizzaName, dough);
                string command;
                while ((command=Console.ReadLine())!="END")
                {
                    string[] toppingInfo = command.Split();

                    Topping topping = new(toppingInfo[1], double.Parse(toppingInfo[2]));

                    pizza.AddTopping(topping);

                }

                Console.WriteLine(pizza.ToString());
  
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }       
           
        }
    }
}
