using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {

        private DiverRepository divers;
        private FishRepository fish;
        private string[] diversType = new string[] { typeof(ScubaDiver).Name, typeof(FreeDiver).Name };
        private string[] fishesType = new string[] { typeof(ReefFish).Name, typeof(PredatoryFish).Name, typeof(DeepSeaFish).Name };

        public Controller()
        {
            divers = new DiverRepository();
            fish = new FishRepository();
        }


        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (!diversType.Contains(diverType))
            {
                return String.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }
            else if (divers.GetModel(diverName) != null) 
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, typeof(DiverRepository).Name);
            }

            IDiver diver;

            if (diverType == "ScubaDiver")
            {
                diver = new ScubaDiver(diverName);
            }
            else
            {
                diver = new FreeDiver(diverName);
            }

            divers.AddModel(diver);
            return string.Format(OutputMessages.DiverRegistered, diverName, typeof(DiverRepository).Name);

        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (!fishesType.Contains(fishType))
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }
            if (fish.GetModel(fishName) != null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, typeof(FishRepository).Name);
            }

            IFish curentFish;

            if (fishType == "ReefFish")
            {
                curentFish = new ReefFish(fishName, points);
            }
            else if (fishType == "DeepSeaFish")
            {
                curentFish = new DeepSeaFish(fishName, points);
            }
            else
            {
                curentFish = new PredatoryFish(fishName, points);
            }

            fish.AddModel(curentFish);
            return string.Format(OutputMessages.FishCreated, fishName);

        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) == null)
            {
                return string.Format(OutputMessages.DiverNotFound, typeof(DiverRepository).Name, diverName);
            }
            if (fish.GetModel(fishName) == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            IDiver diver = divers.GetModel(diverName);
            IFish newFish = fish.GetModel(fishName);

            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }
            if (diver.OxygenLevel < newFish.TimeToCatch)
            {
                diver.Miss(newFish.TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            if (diver.OxygenLevel == newFish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(newFish);
                    return string.Format(OutputMessages.DiverHitsFish, diverName, newFish.Points, fishName);
                }
                else
                {
                    diver.Miss(newFish.TimeToCatch);
                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }
            else
            {
                diver.Hit(newFish);
                return string.Format(OutputMessages.DiverHitsFish, diverName, newFish.Points, fishName);
            }
        }
        public string HealthRecovery()
        {
            List<IDiver> healtIsuueDiver = divers.Models.Where(d => d.HasHealthIssues).ToList();

            foreach (var diver in healtIsuueDiver)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();

            }
            return string.Format(OutputMessages.DiversRecovered, healtIsuueDiver.Count);
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach (var catchFish in diver.Catch)
            {
                sb.AppendLine(fish.GetModel(catchFish).ToString());
            }

            return sb.ToString().TrimEnd();
        }



        public string CompetitionStatistics()
        {
            List<IDiver> diversSort = divers.Models
                .Where(d => !d.HasHealthIssues)
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var diver in diversSort)
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().TrimEnd();

        }





    }
}
