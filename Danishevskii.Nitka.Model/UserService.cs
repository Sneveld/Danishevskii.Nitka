using Danishevskii.Nitka.DataAccess.Interfaces;
using Danishevskii.Nitka.Dto;
using Danishevskii.Nitka.Mapping.Interfaces;
using Danishevskii.Nitka.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.Model.CsvParser
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public UserService(IUserRepository userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }
        public PageResponse GetUsers(PageRequest pageRequest)
        {
            var users = _userRepository.GetUsers(pageRequest.PageNumber, pageRequest.PageCount);
            var totalSalary = _userRepository.GetUsersSalarySum();
            var pageResponse = new PageResponse(users.Select(c => _userMapper.UserToDto(c, totalSalary)), pageRequest.PageNumber);
            return pageResponse;
        }
        public UserDto GetUser(Guid Id)
        {
            var user = _userRepository.GetUser(Id);
            return _userMapper.UserToDto(user);
        }
        public void AddUser(UserDto userDto)
        {
            var user = _userMapper.DtoToUser(userDto);
            _userRepository.AddUser(user);
        }

        public void UpdateUser(UserDto userDto)
        {
            var user = _userMapper.DtoToUser(userDto);
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(Guid Id)
        {
            _userRepository.DeleteUser(Id);
        }
    }
}
