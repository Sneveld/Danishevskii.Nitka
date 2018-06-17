using Danishevskii.Nitka.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.Model.Interfaces
{
    public interface IFileParserService
    {
        IEnumerable<UserDto> ParseFileToUsers(Stream stream);
    }
}
