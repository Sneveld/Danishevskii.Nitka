using Danishevskii.Nitka.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.Model.Interfaces
{
    public interface IUserService
    {
        PageResponse GetUsers(PageRequest pageRequest);
        UserDto GetUser(Guid Id);
        void AddUser(UserDto userDto);
        void UpdateUser(UserDto userDto);
        void DeleteUser(Guid Id);
    }
}
