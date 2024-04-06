using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> users;

        public UserRepository()
        {
            users= new List<IUser>();
        }
        public void AddModel(IUser model)
        {
            users.Add(model);
        }
        public bool RemoveById(string identifier)
        {
            IUser userForRemuve = users.FirstOrDefault(u=> u.DrivingLicenseNumber== identifier);
            if (userForRemuve == null)
            {
                return false;
            }
            else
            {
                users.Remove(userForRemuve);
                return true;
            }
        }

        public IUser FindById(string identifier)
        {
           IUser user = users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
            return user;
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return users.AsReadOnly();
        }

        
    }
}
