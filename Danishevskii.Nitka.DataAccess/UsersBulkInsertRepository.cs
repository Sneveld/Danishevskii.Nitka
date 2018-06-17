using Danishevskii.Nitka.DataAccess.Interfaces;
using Danishevskii.Nitka.DataAccess.Services;
using Danishevskii.Nitka.DataContext;
using Danishevskii.Nitka.Dto;
using Danishevskii.Nitka.Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.DataAccess
{
    public class UsersBulkInsertRepository: IUsersBulkInsertRepository
    {
        private readonly IReaderService _readerService;

        public UsersBulkInsertRepository(IReaderService readerService)
        {
            _readerService = readerService;
        }
        public void InsertUsers(Stream stream)
        {
            var reader = _readerService.GetReader(stream);
            var connectionString = NitkaContext.CONNECTION_STRING;

            using (var loader = new System.Data.SqlClient.SqlBulkCopy(connectionString))
            {
                loader.DestinationTableName = "Users";
                loader.WriteToServer(reader);
            }
        }

        public Task InsertUsersAsync(IEnumerable<User> users)
        {
            return Task.Run(() =>  InsertUsers(users));
        }

        public void InsertUsers(IEnumerable<User> users)
        {
            var connectionString = NitkaContext.CONNECTION_STRING;

            using (IDataReader reader = new GenericListDataReader<User>(users))
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlBulkCopy bcp = new SqlBulkCopy(connection))
            {
                connection.Open();

                bcp.DestinationTableName = "[Users]";

                bcp.ColumnMappings.Add("Id", "Id");
                bcp.ColumnMappings.Add("FirstName", "FirstName");
                bcp.ColumnMappings.Add("LastName", "LastName");
                bcp.ColumnMappings.Add("Number", "Number");
                bcp.ColumnMappings.Add("Salary", "Salary");

                bcp.WriteToServer(reader);
            }
        }
    }
}
