using Danishevskii.Nitka.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Danishevskii.Nitka.Web.Controllers
{
    public class UploadFileApiController : ApiController
    {
        private readonly IUploadCsvFileService _uploadCsvFileService;

        public UploadFileApiController(IUploadCsvFileService uploadCsvFileService)
        {
            _uploadCsvFileService = uploadCsvFileService;
        }
        [Route("api/uploadFile")]
        [HttpPost]
        public async Task<HttpResponseMessage> UploadFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    await _uploadCsvFileService.UploadFile(postedFile.InputStream);
                }
            }
            return response;
        }
    }
}

