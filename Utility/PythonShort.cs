using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AGS.ServerAPI.DAL_Models;
using AGS.ServerAPI.Models;
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
            var item = new PortManager();
            using (var r = new StreamReader(@"c:/ftproot/Domains/AGS_joey/Connection_Config/ConnectionConfig.json"))
            {
                var json = r.ReadToEnd();
                item = JsonConvert.DeserializeObject<PortManager>(json);
            }
            var ip = item.ip;
            var port = item.port;
            var route = $@"/{controller}";
            return @"https://" + ip + port + route;
        }

        public static bool PostToModule(AnswerModel answers)
        {
            return answers.Said != string.Empty;
        }

        static void NEVER_EAT_POISON_Disable_CertificateValidation()
        {
            // Disabling certificate validation can expose you to a man-in-the-middle attack
            // which may allow your encrypted message to be read by an attacker
            // https://stackoverflow.com/a/14907718/740639
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (
                    object s,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors
                ) {
                    return true;
                };
        }


        public static string PostToPython(AnswerModel answers)
        {
            NEVER_EAT_POISON_Disable_CertificateValidation();
            const string medType = "application/json";
            var module = answers.ModuleId.ToLower();
            string retString;

            switch (module)
            {
                case "met":
                    {
                        var pModel = new MetModel { Age = answers.Age, Waist = answers.Waist, Systolic = answers.Systolic };
                        var postData = new StringContent(JsonConvert.SerializeObject(pModel), Encoding.UTF8, medType);
                        var response = client.PostAsync(Route(module), postData).Result;
                        if (response.IsSuccessStatusCode != true)
                            throw new Exception($"Response from server API Failed for POST {Route(module)}, check IP config");
                        retString = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                    }
                    break;
                case "vad":
                    {
                        var pModel = new VadModel { ParametersVad = answers.ParametersVad };
                        var postData = new StringContent(JsonConvert.SerializeObject(pModel), Encoding.UTF8, medType);
                        var response = client.PostAsync(Route(module), postData).Result;
                        if (response.IsSuccessStatusCode != true)
                            throw new Exception($"Response from server API Failed for POST {Route(module)}, check IP config");
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