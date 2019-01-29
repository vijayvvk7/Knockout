using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Web.Http;

namespace KnockOut.Controllers
{
    public class ReverseWordsController : ApiController
    {
        // GET: api/ReverseWords
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/ReverseWords/5
        [HttpGet]
        
        public string Get([FromUri]string sentence)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            var key = sentence.GetHashCode().ToString();
            var cachedWord = MemoryCache.Default.GetCacheItem(key);
            if (cachedWord != null)
            {
                //response.Content = new StringContent( cachedWord.Value.ToString(),  Encoding.UTF8, "application/json");
                //return response;
                return cachedWord.Value.ToString();
            }
                

            string[] words = sentence.Split(' ');
            System.Text.StringBuilder sbReverse = new System.Text.StringBuilder();
            foreach(var word in words)
            {
                var reverse = word.Reverse().ToArray();
                sbReverse.Append(reverse);
            }
            var result = sbReverse.ToString();

            MemoryCache.Default.Add(new CacheItem(key, result), new CacheItemPolicy() { SlidingExpiration = TimeSpan.FromHours(6) });

            //response.Content = new StringContent(result.ToString(), Encoding.UTF8, "application/json");
            //return response;
            return result;

        }

        // POST: api/ReverseWords
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ReverseWords/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ReverseWords/5
        public void Delete(int id)
        {
        }
    }
}
