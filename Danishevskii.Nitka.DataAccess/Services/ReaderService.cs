using Danishevskii.Nitka.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.DataAccess.Services
{
    public class ReaderService: IReaderService
    {
        public IDataReader GetReader(Stream stream)
        {
            using (StreamReader streamReader = new StreamReader(stream))
            {
                var convertTable = GetConvertTable();
                var constraintsTable = GetConstraintsTable();

                var reader = new CSVReader(streamReader, constraintsTable, convertTable);
                return reader;
            }

        }

        private Func<string, bool>[] GetConstraintsTable()
        {
            var constraintsTable = new Func<string, bool>[5];

            constraintsTable[0] = x => !string.IsNullOrEmpty(x);
            constraintsTable[1] = x => true;
            constraintsTable[2] = x => true;
            constraintsTable[3] = x => true;
            constraintsTable[3] = x => true;

            return constraintsTable;
        }

        private Func<string, object>[] GetConvertTable()
        {
            var convertTable = new Func<object, object>[5];

            convertTable[0] = x => new Guid(Convert.ToString(x));
            convertTable[1] = x => x;
            convertTable[2] = x => x;
            convertTable[3] = x => x;
            convertTable[4] = x => Convert.ToDouble(x);

            return convertTable;
        }
    }
}
