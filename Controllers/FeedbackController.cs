using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using AGS.ServerAPI.DAL_Models;
using AGS.ServerAPI.Utility;
using AGS.ServerAPI.View_Models;
using Newtonsoft.Json;

namespace AGS.ServerAPI.Controllers
{
    public class FeedbackController : ApiController
    {
        // GET AGsoft/feedback
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage();
        }

        // GET AGsoft/feedback/{id}
        public HttpResponseMessage Get(string id)
        {
            var jsonResult = string.Empty;

            if (QueryShort.UxSurveyList(id).Any())
            {
                jsonResult = JsonConvert.SerializeObject(QueryShort.UxSurveyList(id), Formatting.Indented); // indented looks nicer during debugging
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json")
            };
        }

        // POST AGsoft/feedback
        public void Post([FromBody]UxResult value)
        {
            Debug.WriteLine(value);
            if (value != null)
            {
                Debug.WriteLine(QueryShort.AddUxResult(value) ? "client added" : "client not added");
            }
            else
            {
                Debug.WriteLine("value still null");
            }
        }

        // PUT AGsoft/feedback/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE AGsoft/feedback/5
        public void Delete(int id)
        {
        }
    }
}
