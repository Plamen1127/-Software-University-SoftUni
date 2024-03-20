using Raiding.Core.Interfaces;
using Raiding.Exceptions;
using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHerosFactory herosFactory;

        private ICollection<IBaseHero> heros;

        public Engine(IReader reader, IWriter writer, IHerosFactory herosFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.herosFactory = herosFactory;

            heros = new HashSet<IBaseHero>();
        }

        public void Run()
        {
           int n = int.Parse(reader.ReadLine());

            while (heros.Count < n)
            {
                try
                {
                    HerosCreateUsingHerosFactori();
                }
                catch (InvalidTypeHeroException ihte)
                {

                    this.writer.WriteLine(ihte.Message);
                }
                catch(ArgumentException e)
                {
                    this.writer.WriteLine(e.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            double bosPower = double.Parse(this.reader.ReadLine());

            double allPowerFroHeros = heros.Sum(h=>h.Power);

            PrintAllHeros();

            if (allPowerFroHeros>= bosPower)
            {
                this.writer.WriteLine("Victory!");
            }
            else
            {
                this.writer.WriteLine("Defeat...");
            }
        }

        public void HerosCreateUsingHerosFactori()
        {
            string herosType = reader.ReadLine();
            string herosName = reader.ReadLine();

            heros.Add(herosFactory.CriateHero(herosType, herosName));
        }

        public void PrintAllHeros()
        {
            foreach (IBaseHero hero in heros)
            {
                this.writer.WriteLine(hero.CastAbility());
            }
        }
    }
}
