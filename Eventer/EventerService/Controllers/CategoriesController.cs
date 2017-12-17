using EventerService.DataAccess;
using EventerService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace EventerService.Controllers
{
    public class CategoriesController : ApiController
    {
        // GET: api/Categories
        public List<Category> Get()
        {
            DataAccessLayer dal = new DataAccessLayer();
            DataSet ds = dal.ExecuteDataSet("sp_get_categories");

            List<Category> categories = new List<Category>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Category category = new Category();
                    category.Guid = (Guid)row[0];
                    category.Name = (string)row[1];

                    categories.Add(category);                }
            }

            //var jsonResult = new JavaScriptSerializer().Serialize(categories);
            var js = new JavaScriptSerializer();
            string jsonResult = js.Serialize(categories);
            //var jsonResult = JsonConvert.SerializeObject(categories);
            //return jsonResult;
            return categories;
        }

        // GET: api/Categories/{id}
        public string Get(int id)
        {
            return "value";
        }

        //// POST: api/Categories
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Categories/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Categories/5
        //public void Delete(int id)
        //{
        //}
    }
}
