using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TOC_DL;

namespace TOC_API.Controllers
{
    public class ProductController : ApiController
    {
        private TOCEntities db = new TOCEntities();

        // GET: api/Product
        public IEnumerable<PRODUCT> Get_Product_All()
        {
            return db.PRODUCTs;
        }

        // GET: api/Product/5
        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult Get_Product_Single(int id)
        {
            PRODUCT pdt = db.PRODUCTs.Find(id);
            if (pdt == null)
            {
                return NotFound();
            }

            return Ok(pdt);
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
