using Danishevskii.Nitka.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.DataContext
{
    public class NitkaContext: DbContext
    {
        public const string CONNECTION_STRING = @"Server = WINDOWS-GCGOLS6\SNEVELDSERVER; Database=Nitka; Trusted_Connection=True; MultipleActiveResultSets=true";
        public NitkaContext():base(CONNECTION_STRING)
        {

        }

        public NitkaContext(string connectionString) : base(connectionString)
        {

        } 
        public DbSet<User> Users { get; set; }
    }
}
