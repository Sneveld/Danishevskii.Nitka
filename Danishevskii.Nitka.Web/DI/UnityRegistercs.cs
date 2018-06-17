using Danishevskii.Nitka.DataAccess;
using Danishevskii.Nitka.DataAccess.Interfaces;
using Danishevskii.Nitka.DataAccess.Services;
using Danishevskii.Nitka.Mapping;
using Danishevskii.Nitka.Mapping.Interfaces;
using Danishevskii.Nitka.Model.CsvParser;
using Danishevskii.Nitka.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace Danishevskii.Nitka.Web.DI
{
    public class UnityRegistercs
    {
        public static UnityContainer CreateUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IFileParserService, FileParserService>(new HierarchicalLifetimeManager());

            container.RegisterType<IReaderService, ReaderService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsersBulkInsertRepository, UsersBulkInsertRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserMapper, UserMapper>(new HierarchicalLifetimeManager());
            container.RegisterType<IUploadCsvFileService, UploadCsvFileService>(new HierarchicalLifetimeManager());

            container.RegisterType<IUsersBulkInsertRepository, UsersBulkInsertRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}