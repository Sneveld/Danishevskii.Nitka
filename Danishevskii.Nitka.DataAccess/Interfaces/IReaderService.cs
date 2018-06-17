using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.DataAccess.Interfaces
{
    public interface IReaderService
    {
        IDataReader GetReader(Stream stream);
    }
}
