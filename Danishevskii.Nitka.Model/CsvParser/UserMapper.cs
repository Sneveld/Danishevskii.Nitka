using Danishevskii.Nitka.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.Model.CsvParser
{
    public class UserCsvMapper : CsvHelper.Configuration.ClassMap<UserDto>
    {
        public UserCsvMapper()
        {
            AutoMap();
            Map(m => m.SalaryRatio).Ignore();
        }
    }
}
