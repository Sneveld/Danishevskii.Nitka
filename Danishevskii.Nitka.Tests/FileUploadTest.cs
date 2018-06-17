using Danishevskii.Nitka.Model.CsvParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danishevskii.Nitka.Tests
{
    [TestClass]
    public class FileUploadTest
    {
        [TestMethod]
        public void FileParserService_FileParserService_ContentOk_Ok()
        {
            var fileParserService = new FileParserService();

            using (var stream = new FileStream("Content/MOCK_DATA - 2.csv", FileMode.Open))
            {
                var users = fileParserService.ParseFileToUsers(stream);
                Assert.IsTrue(users.Any());
            }
        }

        [TestMethod]
        public void FileParserService_FileParserService_ContentBad_Ok()
        {
            var fileParserService = new FileParserService();

            using (var stream = new FileStream("Content/MOCK_DATA-1.csv", FileMode.Open))
            {
                try
                {
                    var users = fileParserService.ParseFileToUsers(stream);
                    Assert.IsTrue(false);
                }
                catch
                {
                    Assert.IsTrue(true);                    
                }
                                
            }
        }
    }
}
