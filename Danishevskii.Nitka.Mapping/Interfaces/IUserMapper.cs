using Danishevskii.Nitka.Dto;
using Danishevskii.Nitka.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.Mapping.Interfaces
{
    public interface IUserMapper
    {
        UserDto UserToDto(User user, double totalSalary);
        UserDto UserToDto(User user);
        User DtoToUser(UserDto userDto);
        User DtoToUser(UserDto userDto, Guid id);
    }
}
