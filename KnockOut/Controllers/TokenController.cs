﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KnockOut.Controllers
{
    public class TokenController : ApiController
    {
        // GET: api/Token
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Token/5
        public string Get()
        {
            Guid guid = new Guid();
            return Guid.NewGuid().ToString();
        }

        // POST: api/Token
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Token/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Token/5
        public void Delete(int id)
        {
        }
    }
}
