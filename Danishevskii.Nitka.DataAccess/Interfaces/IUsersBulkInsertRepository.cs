using Danishevskii.Nitka.Dto;
using Danishevskii.Nitka.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.DataAccess.Interfaces
{
    public interface IUsersBulkInsertRepository
    {
        void InsertUsers(Stream stream);
        void InsertUsers(IEnumerable<User> users);
        Task InsertUsersAsync(IEnumerable<User> users);
    }
}
