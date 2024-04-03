using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IVessel> vessels;
        private readonly ICollection<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new HashSet<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain newCapitan = new Captain(fullName);

            if (this.captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            this.captains.Add(newCapitan);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel newVessel = this.vessels.FindByName(name);
            if (newVessel != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, newVessel.GetType().Name, name);
            }

            IVessel produceVessel;

            if (vesselType == "Submarine")
            {
                produceVessel = new Submarine(name, mainWeaponCaliber, speed);

            }
            else if (vesselType == "Battleship")
            {
                produceVessel = new Battleship(name, mainWeaponCaliber, speed);

            }
            else
            {
                return string.Format(OutputMessages.InvalidVesselType);
            }

            this.vessels.Add(produceVessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);


        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);

            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            IVessel vessel = this.vessels.FindByName(selectedVesselName);
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            vessel.Captain = captain;
            captain.AddVessel(vessel);

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain capitan = captains.First(c => c.FullName == captainFullName);

            return capitan.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            return vessel?.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
            if (vessel.GetType().Name == "Battleship")
            {
                Battleship battleship = (Battleship)vessel;
                battleship.ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                Submarine submarine = (Submarine)vessel;
                submarine.ToggleSubmergeMode();

                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);

        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = this.vessels.FindByName(attackingVesselName);

            if (attackingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound,attackingVesselName);
            }

            IVessel deffendingVessel = this.vessels.FindByName(defendingVesselName);
            if (deffendingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attackingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (deffendingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackingVessel.Attack(deffendingVessel);

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, deffendingVessel.ArmorThickness);
        }


    }
}
