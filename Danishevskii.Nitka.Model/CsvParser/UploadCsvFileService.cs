using Danishevskii.Nitka.DataAccess.Interfaces;
using Danishevskii.Nitka.Mapping.Interfaces;
using Danishevskii.Nitka.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.Model.CsvParser
{
    public class UploadCsvFileService: IUploadCsvFileService
    {
        private readonly IUsersBulkInsertRepository _usersBulkInsertRepository;
        private readonly IFileParserService _fileParserService;
        private readonly IUserMapper _userMapper;

        public UploadCsvFileService(
            IUsersBulkInsertRepository usersBulkInsertRepository,
            IFileParserService fileParserService,
            IUserMapper userMapper
            )
        {
            _usersBulkInsertRepository = usersBulkInsertRepository;
            _fileParserService = fileParserService;
            _userMapper = userMapper;
        }

        public async Task UploadFile(Stream stream)
        {
            var usersDto = _fileParserService.ParseFileToUsers(stream);
            var users = usersDto.Select(c=> _userMapper.DtoToUser(c, Guid.NewGuid()));
            await  _usersBulkInsertRepository.InsertUsersAsync(users);
        }
    }
}
