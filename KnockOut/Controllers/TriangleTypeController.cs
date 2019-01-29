using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KnockOut.Controllers
{
    public class TriangleTypeController : ApiController
    {
        // GET: api/TriangleType
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        

        // GET: api/TriangleType/5
        public string Get(int a, int b, int c)
        {
            if (!this.IsExistentTriangle(a, b, c))
            {
                return "Error";
            }
            else if (this.IsEquilateralType(a, b, c))
            {
                return "Equilateral";
            }
            else if (this.IsScaleneType(a, b, c))
            {
                return "Scalene";
            }
            else if (this.IsIsoscelesType(a, b, c))
            {
                return "Isosceles";
            }
            return "Error";
        }

        // POST: api/TriangleType
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TriangleType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TriangleType/5
        public void Delete(int id)
        {
        }
        #region MyRegion

       
        protected bool IsExistentTriangle(int a, int b, int c)
        {
            bool triangleExist = true;

            // All sides must have positive length.
            if (a <= 0 || b <= 0 || c <= 0)
            {
                triangleExist = false;
            }
            // The sum of the lengths of any two sides of a triangle must be greater than the length of the third side for non-degenerate triangle.
            else if (((long)a + b) <= c)
            {
                triangleExist = false;
            }
            else if (((long)a + c) <= b)
            {
                triangleExist = false;
            }
            else if (((long)b + c) <= a)
            {
                triangleExist = false;
            }

            return triangleExist;
        }

        // An equilateral triangle has all sides the same length. 
        // An equilateral triangle is also a regular polygon with all angles measuring 60°.
        protected bool IsEquilateralType(int a, int b, int c)
        {
            return (a == b && a == c);
        }

        // An isosceles triangle has two sides of equal length.
        // An isosceles triangle also has two angles of the same measure.
        protected bool IsIsoscelesType(int a, int b, int c)
        {
            return (a == b || a == c || b == c);
        }

        // A scalene triangle has all sides different lengths, or equivalently all angles are unequal.
        protected bool IsScaleneType(int a, int b, int c)
        {
            return (a != b && a != c && b != c);
        }
#endregion

    }
}
