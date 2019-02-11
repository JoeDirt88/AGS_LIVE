using System.Linq;
using System.Net.Http;
using System.Web.Http;
using AGS.ServerAPI.Utility;
using Newtonsoft.Json;

namespace AGS.ServerAPI.Controllers
{
    public class ModuleController : ApiController
    {
        #region GET: AGSoft/Module
        /// <summary>
        /// Description:    Returns all modules, along with their ID,
        ///                 name, description, and flavor code from the dB
        /// Status:         Implemented, not utilized
        /// </summary>
        /// <returns>List of all modules from database</returns>
        public HttpResponseMessage Get()
        {
            var jsonResult = string.Empty;

            if (QueryShort.ModuleAll().Any())
            {
                jsonResult = JsonConvert.SerializeObject(QueryShort.ModuleAll(), Formatting.Indented); // indented looks nicer during debugging
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json")
            };
        }
        #endregion

        // GET: api/Module/5
        // localhost:port/Module?=id
        /// <summary>
        /// Description:    Receives the module name from mobile app
        ///                 and directs the correct question information
        ///                 and patient data.
        /// Status:         Creating
        /// </summary>
        /// <param name="id">   The module id being passed from the 
        ///                     mobile app</param>
        /// <returns>Module information</returns>
        public HttpResponseMessage Get(string id)
        {

            var jsonResult = string.Empty;

            if (QueryShort.ModuleList(id).Any())
            {
                jsonResult = JsonConvert.SerializeObject(QueryShort.ModuleList(id), Formatting.Indented); // indented looks nicer during debugging
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json")
            };
        }

        // POST: AGSoft/Module
        public string Post([FromBody] string value)
        {
            return QueryShort.SearchModule(value);
        }

        // PUT: api/Module/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Module/5
        public void Delete(int id)
        {
        }
    }
}
