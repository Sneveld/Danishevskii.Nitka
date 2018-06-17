using Danishevskii.Nitka.Dto;
using Danishevskii.Nitka.Entity;
using Danishevskii.Nitka.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.Mapping
{
    public class UserMapper: IUserMapper
    {
        public UserDto UserToDto(User user)
        {
            var userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.FirstName = user.FirstName;
            userDto.LastName = user.LastName;
            userDto.Number = user.Number;
            userDto.Salary = user.Salary;

            return userDto;
        }

        public UserDto UserToDto(User user, double totalSalary)
        {
            var userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.FirstName = user.FirstName;
            userDto.LastName = user.LastName;
            userDto.Number = user.Number;
            userDto.Salary = user.Salary;
            if(totalSalary>0)
                userDto.SalaryRatio = user.Salary / totalSalary;
            return userDto;
        }

        public User DtoToUser(UserDto userDto)
        {
            var user = new User();

            user.Id = userDto.Id;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Number = userDto.Number;
            user.Salary = userDto.Salary;

            return user;
        }

        public User DtoToUser(UserDto userDto, Guid id)
        {
            var user = new User();

            user.Id = id;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Number = userDto.Number;
            user.Salary = userDto.Salary;

            return user;
        }

    }
}
