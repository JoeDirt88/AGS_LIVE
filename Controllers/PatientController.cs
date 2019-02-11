using System.Diagnostics;
using System.Net.Http;
using System.Web.Http;
using AGS.ServerAPI.DAL_Models;
using AGS.ServerAPI.Utility;
using Newtonsoft.Json;

namespace AGS.ServerAPI.Controllers
{
    public class PatientController : ApiController
    {
        # region GET: AGSoft/Patient
        public HttpResponseMessage Get()
        {
            var jsonResult = JsonConvert.SerializeObject(QueryShort.SearchClient());

            return new HttpResponseMessage()
            {
                Content = new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json")
            };
        }
        #endregion
        #region GET: AGSoft/Patient/{id}
        /// <summary>
        /// Description:    This is for checking the existence of a specific patient in the DB
        /// Status:         Implemented
        /// </summary>
        /// <param name="id">ID number of client as a string</param>
        /// <returns>PatientInfo.Said == "0" if client doesn't exist</returns>
        public HttpResponseMessage Get(string id)
        {

            var jsonResult = JsonConvert.SerializeObject(QueryShort.SearchClient(id));

            return new HttpResponseMessage()
            {
                Content = new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json")
            };
        }
        #endregion
        #region POST: AGSoft/Patient
        /// <summary>
        /// Description:    POST request from APP works with a patient info model
        /// Status:         Implemented
        /// </summary>
        /// <param name="value">PatientInfo model from APP</param>
        public void Post([FromBody] PatientInfo value)
        {
            Debug.WriteLine(value);
            if (value != null)
            {
                Debug.WriteLine(QueryShort.AddClient(value) ? "client added" : "client not added");
            }
            else
            {
                Debug.WriteLine("value still null");
            }
            
        }
        #endregion
        

        // PUT: api/Patient/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Patient/5
        public void Delete(int id)
        {
        }
    }
}
