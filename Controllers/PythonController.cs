using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Web.Http;
using AGS.ServerAPI.DAL_Models;
using AGS.ServerAPI.Utility;
using Newtonsoft.Json;

namespace AGS.ServerAPI.Controllers
{
    public class PythonController : ApiController
    {
        // GET: AGSoft/Python
        public HttpResponseMessage Get()
        {
            var r = new Random();
            var list = new List<string>();
            var ans = new AnswerModel();
            ans.Said = "8807215032087";
            ans.Age = "30";
            ans.ModuleId = "Met";
            ans.Systolic = "120";
            ans.Waist = "100";
            ans.CurDateTime = DateTime.Now;
            for (var i = 0; i < 8; i++)
            {
                var param = "1";
                list.Add(param);
            }

            ans.ParametersVad = list;

            var res = PythonShort.PostToPython(ans);

            var resultJson = new ResultModel
            {
                ModuleId = ans.ModuleId,
                CurDateTime = ans.CurDateTime.ToString(),
                Result = res,
                Screened = Color.Black
            };

            var jsonResult = JsonConvert.SerializeObject(resultJson, Formatting.Indented); // indented looks nicer during debugging


            return new HttpResponseMessage()
            {
                Content = new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json")
            };
        }

        // GET: api/Python/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Python
        public void Post([FromBody] AnswerModel value)
        {
            // send to PythonHelper

            if (QueryShort.AddResult(value))
            {
                Debug.WriteLine("Successfully added new data to table");
            }
            else
            {
                throw new Exception("Python Module not executed");
            }
        }

        // PUT: api/Python/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Python/5
        public void Delete(int id)
        {
        }
    }
}
