using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.Model.Interfaces
{
    public interface IUploadCsvFileService
    {
        Task UploadFile(Stream stream);
    }
}
