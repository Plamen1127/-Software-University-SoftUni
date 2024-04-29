using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> routes;

        public RouteRepository()
        {
            routes= new List<IRoute>();
        }
        public void AddModel(IRoute model)
        {
            routes.Add(model);
        }
        public bool RemoveById(string identifier)
        {
            IRoute routeRemuve = routes.FirstOrDefault(r=> (r.RouteId)==int.Parse(identifier));

            if (routeRemuve == null) 
            {
                return false;
            }
            else
            {
                routes.Remove(routeRemuve);
                return true;
            }
        }

        public IRoute FindById(string identifier)
        {
            IRoute route= routes.FirstOrDefault(r=>r.RouteId==int.Parse(identifier));
            return route;
        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
            return routes.AsReadOnly();
        }

    }
}
