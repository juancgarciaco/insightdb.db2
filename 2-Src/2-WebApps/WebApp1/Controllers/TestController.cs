using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp1.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/Test2
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test2/5
        public void Delete(int id)
        {
        }
    }
}
