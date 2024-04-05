using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> catchFish;
        private double competitionpoints;
        private bool hasHealthIssues;

        protected Diver(string name, int oxygenLevel)
        {
            this.Name = name;
            this.OxygenLevel = oxygenLevel;
            catchFish = new List<string>();
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }

                name = value;
            }
        }

        public int OxygenLevel
        {
            get { return oxygenLevel; }
            protected set
            {
                if (value <= 0)
                {
                    hasHealthIssues = true;

                    oxygenLevel = 0;
                }
                else
                {
                    oxygenLevel = value;
                }

            }

        }

        public IReadOnlyCollection<string> Catch
        {
            get { return catchFish.AsReadOnly(); }
        }

        public double CompetitionPoints
        {
            get { return competitionpoints; }
            private set { competitionpoints = value; }
        }

        public bool HasHealthIssues
        {
            get { return hasHealthIssues; }

        }

        public void Hit(IFish fish)
        {
            this.OxygenLevel -= fish.TimeToCatch;
            this.catchFish.Add(fish.Name);
            competitionpoints = Math.Round(competitionpoints + fish.Points, 1);
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            hasHealthIssues = !HasHealthIssues;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {catchFish.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
