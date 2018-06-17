using Danishevskii.Nitka.DataAccess.Interfaces;
using Danishevskii.Nitka.DataContext;
using Danishevskii.Nitka.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.DataAccess
{
    public class UserRepository: IUserRepository
    {
        public IEnumerable<User> GetUsers(int pageNumber, int pageCount)
        {
            using (var db = new NitkaContext())
            {
                return db.Users
                    .OrderBy(c=>c.FirstName)
                    .Skip((pageNumber - 1) * pageCount)
                    .Take(pageCount)
                    .ToList();
            }
        }

        public double GetUsersSalarySum()
        {
            using (var db = new NitkaContext())
            {
                if(db.Users.Any())
                    return db.Users.Sum(c => c.Salary);
                return 0;
            }
        }
        public User GetUser(Guid Id)
        {
            using (var db = new NitkaContext())
            {
                return db.Users.FirstOrDefault(c=>c.Id == Id);
            }
        }
        public void AddUser(User user)
        {
            using (var db = new NitkaContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            using (var db = new NitkaContext())
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteUser(Guid Id)
        {
            using (var db = new NitkaContext())
            {
                var user = db.Users.FirstOrDefault(c=>c.Id == Id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }
    }
}
