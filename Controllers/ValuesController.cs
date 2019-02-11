using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using AGS.ServerAPI.DAL_Models;
using AGS.ServerAPI.Utility;
using Newtonsoft.Json;

namespace AGS.ServerAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET AGsoft/values
        public HttpResponseMessage Get()
        {

            var resultsList = new List<ResultModel>();
            var jsonResult = string.Empty;

            if (resultsList.Any())
                jsonResult = JsonConvert.SerializeObject(resultsList, Formatting.Indented); // indented looks nicer during debugging

            return new HttpResponseMessage()
            {
                Content = new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json")
            };
        }

        // GET AGsoft/values/{id}
        public HttpResponseMessage Get(string id)
        {
            var jsonResult = string.Empty;

            if (QueryShort.ResultList(id).Any())
                jsonResult = JsonConvert.SerializeObject(QueryShort.ResultList(id), Formatting.Indented); // indented looks nicer during debugging

            return new HttpResponseMessage()
            {
                Content = new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json")
            };
        }

        // POST AGsoft/values
        public void Post([FromBody]string value)
        {

        }

        // PUT AGsoft/values/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE AGsoft/values/5
        public void Delete(int id)
        {
        }
    }
}
