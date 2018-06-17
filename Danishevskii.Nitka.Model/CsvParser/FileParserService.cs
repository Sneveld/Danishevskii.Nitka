using CsvHelper;
using Danishevskii.Nitka.Dto;
using Danishevskii.Nitka.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.Model.CsvParser
{
    public class FileParserService: IFileParserService
    {
        public IEnumerable<UserDto> ParseFileToUsers(Stream stream)
        {
            var records = new List<UserDto>();

            try
            {
                using (TextReader reader = new StreamReader(stream))
                {
                    var csv = new CsvReader(reader);
                    csv.Configuration.HasHeaderRecord = true;
                    csv.Configuration.RegisterClassMap<UserCsvMapper>();
                    records = csv.GetRecords<UserDto>().ToList();
                }
            }
            catch
            {
                throw new Exception("Error while file parsing");
            }            

            return records;
        }

        
    }
}
