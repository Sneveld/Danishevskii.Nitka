using Danishevskii.Nitka.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDb
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new NitkaContext();
            db.Database.CreateIfNotExists();
        }
    }
}
