using Danishevskii.Nitka.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        double GetUsersSalarySum();
        IEnumerable<User> GetUsers(int pageNumber, int pageCount);
        User GetUser(Guid Id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid Id);
    }
}
