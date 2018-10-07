using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using TOC_DL;

namespace TOC_API.Controllers
{
    /// <summary>
    /// 產品類
    /// </summary>
    public class ProductController : ApiController
    {
        /// <summary>
        /// 取得當前上架所有產品
        /// </summary>
        /// <returns>詳見欄位內容</returns>
        [HttpGet, HttpPost]
        public IEnumerable Get_Product_All()
        { 
            using (TOCEntities db = new TOCEntities())
            {
                var result = from pr in db.PRODUCTs
                             join prl in db.PRODUCT_LANGUAGEs on pr.PRODUCT_ID equals prl.PRODUCT_ID
                             join prt in db.PRODUCT_TYPEs on pr.PRODUCT_TYPE_ID equals prt.PRODUCT_TYPE_ID
                             where 1 == 1
                                && prl.LANGUAGE_TYPE == "en-us"
                                && pr.IS_ON_MARKET == 1
                             select new
                             {
                                 pr.PRODUCT_ID,prl.PRODUCT_NAME,pr.PRODUCT_MODEL,prt.PRODUCT_TYPE_NAME,
                                 pr.PRODUCT_DESC,pr.IMAGE_SRC_GROUP_ID,pr.CURRENCY,pr.PRICE,pr.VAT,pr.SUPPLY_ID,
                                 pr.FROM_STOCK_ID,pr.TOTAL_QTY,pr.SOLD_QTY,pr.CURRENT_OWNER,pr.CURRENT_ITEM_ID,
                                 pr.CURRENT_ITEM_BY,pr.START_DATE,pr.END_DATE,pr.PRODUCT_STATUS
                             };

                if (result.Count()==0)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return result.ToList();
            }
        }

        /// <summary>
        /// 取得單一產品資訊
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public IEnumerable Get_Product_Single(int id)
        {
            using (TOCEntities db = new TOCEntities())
            {

                var result = from pr in db.PRODUCTs
                             join prl in db.PRODUCT_LANGUAGEs on pr.PRODUCT_ID equals prl.PRODUCT_ID
                             join prt in db.PRODUCT_TYPEs on pr.PRODUCT_TYPE_ID equals prt.PRODUCT_TYPE_ID
                             where 1 == 1
                                && prl.LANGUAGE_TYPE == "en-us"
                                && pr.PRODUCT_ID == id
                             select new
                             {
                                 pr.PRODUCT_ID,
                                 prl.PRODUCT_NAME,
                                 pr.PRODUCT_MODEL,
                                 prt.PRODUCT_TYPE_NAME,
                                 pr.PRODUCT_DESC,
                                 pr.IMAGE_SRC_GROUP_ID,
                                 pr.CURRENCY,
                                 pr.PRICE,
                                 pr.VAT,
                                 pr.SUPPLY_ID,
                                 pr.FROM_STOCK_ID,
                                 pr.TOTAL_QTY,
                                 pr.SOLD_QTY,
                                 pr.CURRENT_OWNER,
                                 pr.CURRENT_ITEM_ID,
                                 pr.CURRENT_ITEM_BY,
                                 pr.START_DATE,
                                 pr.END_DATE,
                                 pr.PRODUCT_STATUS
                             };

                if (result.Count() == 0)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return result.ToList();
            }
        }
    }
}
