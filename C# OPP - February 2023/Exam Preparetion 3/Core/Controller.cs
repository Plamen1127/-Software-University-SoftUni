using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;
         private string[] vehiclsType = new string[] { typeof(CargoVan).Name, typeof(PassengerCar).Name };

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }
        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            IUser user = users.FindById(drivingLicenseNumber);
           
            if (user != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }
            else
            {
                IUser userForAdd = new User(firstName, lastName, drivingLicenseNumber);
                users.AddModel(userForAdd);
                return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
            }    
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (!vehiclsType.Contains(vehicleType))
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            IVehicle vehicle1 = vehicles.FindById(licensePlateNumber);
            if (vehicle1!=null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            IVehicle vehicle;
            if (vehicleType == "CargoVan")
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            else
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
             
            vehicles.AddModel(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            IRoute route = routes.GetAll()
                 .FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length);

            if (route != null)
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }

            route = routes.GetAll()
                 .FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length < length);
            if (route != null)
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }

            route = routes.GetAll()
                 .FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length);

            if (route != null)
            {
                route.LockRoute();
            }

            var routeCount = routes.GetAll().Count();

            Route newRoute = new Route(startPoint, endPoint, routeCount, routeCount+1);

            routes.AddModel(newRoute);

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);   
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.FindById(drivingLicenseNumber);
            if (user.IsBlocked) 
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }

            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            if (vehicle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }
            IRoute route= routes.FindById(routeId);
            if (route.IsLocked)
            {
                string.Format(OutputMessages.RouteLocked, routeId);
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }

        public string RepairVehicles(int count)
        {
            List<IVehicle> vehicleForRepair = vehicles.GetAll()
                .Where(v=> v.IsDamaged)
                .OrderBy(v=> v.Brand)
                .ThenBy(v=> v.Model)
                .ToList();
                
            foreach (IVehicle vehicle in vehicleForRepair) 
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }
            return string.Format(OutputMessages.RepairedVehicles, vehicleForRepair.Count);

        }
        public string UsersReport()
        {
            List<IUser> reportUser = users.GetAll()
                 .OrderByDescending(u => u.Rating)
                 .ThenBy(u=> u.LastName)
                 .ThenBy(u=>u.FirstName)
                 .ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** E-Drive-Rent ***");
            foreach (var user in reportUser)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}









