﻿using System;
using System.Net.Http;
using System.Text;
using AGS.ServerAPI.DAL_Models;
using Newtonsoft.Json;

namespace AGS.ServerAPI.Utility
{
    public class PythonShort
    {
        private static HttpClient client = new HttpClient();

        /// <summary>
        /// Details:    This method sets up the route for the Python calls
        ///             ip = target machine IP ("localhost" if on same machine)
        ///             port = target machine port ("49805" if on same machine)
        /// status:     Implemented
        /// </summary>
        /// <param name="controller">Specifies controller on python server side</param>
        /// Current controllers:
        ///     "met"
        ///     "vad"
        /// <returns></returns>
        public static string Route(string controller)
        {
            const string ip = @"196.252.75.177";
            const string port = "49806";
            var route = $@"/{controller}";
            return @"http://" + ip + ":" + port + route;
        }

        public static bool PostToModule(AnswerModel answers)
        {
            return answers.Said != string.Empty;
        }

        public static string PostToPython(AnswerModel answers)
        {
            const string medType = "application/json";
            var module = answers.ModuleId.ToLower();
            string retString;
            
            switch (module)
            {
                case "met":
                {
                    var pModel = new MetModel {Age = answers.Age, Waist = answers.Waist, Systolic = answers.Systolic};
                    var postData = new StringContent(JsonConvert.SerializeObject(pModel), Encoding.UTF8, medType);
                    var response = client.PostAsync(Route(module), postData).Result;
                    if (response.IsSuccessStatusCode != true)
                        throw new Exception($"Response from server API Failed for POST {Route(module)}, check IP config");
                    retString = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                }
                    break;
                case "vad":
                {
                    var pModel = new VadModel {ParametersVad = answers.ParametersVad};
                    var postData = new StringContent(JsonConvert.SerializeObject(pModel), Encoding.UTF8, medType);
                    var response = client.PostAsync(Route(module), postData).Result;
                    if (response.IsSuccessStatusCode != true)
                        throw new Exception(
                            $"Response from server API Failed for POST {Route(module)}, check IP config");
                    retString = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);

                }
                    break;
                default:
                    throw new Exception("Module ID not accepted by POST to Python");
            }
            
            return retString;
        }
    }
}