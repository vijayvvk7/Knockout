using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KnockOut.Controllers
{
    public class FibonacciController : ApiController
    {
        // GET: api/Fibonacci
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Fibonacci/5
        public long Get([FromUri]int n)
        {
            if (n > 92 || n <-92)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
                //return "";
            }
            return CalcFibonacci(n);
            //return "value";
            
        }
        protected long CalculateBinetFormula(int n)
        {
            var numerator = Math.Pow((1.0 + Math.Sqrt(5.0)), n) - Math.Pow((1.0 - Math.Sqrt(5.0)), n);
            var denominator = Math.Pow(2.0, n) * Math.Sqrt(5.0);
            var result = numerator / denominator;

            var roundedResult = Math.Round(result);

            return (long)roundedResult;
        }
        private long CalcFibonacci(int id)
        {
            return CalculateBinetFormula(id);
            //return 0;
        }

        // POST: api/Fibonacci
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Fibonacci/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Fibonacci/5
        public void Delete(int id)
        {
        }
    }
}
