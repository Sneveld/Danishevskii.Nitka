using Danishevskii.Nitka.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Danishevskii.Nitka.Dto
{
    public class PageResponse
    {
        public PageResponse(IEnumerable<UserDto> data, int pageNumber)
        {
            Data = data;
            PageCount = data.Count();
            PageNumber = pageNumber;
        }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public IEnumerable<UserDto> Data { get; set; }
    }
}