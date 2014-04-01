using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi
{
    [Authorize]
    public class BooksController : ApiController
    {
        [Route("books")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Foundation", "LoTR" };
        }
    }
}