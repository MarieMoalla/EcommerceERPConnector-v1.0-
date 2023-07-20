using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceERPConnector_V1._0_.Services
{
    interface IJsonOperations
    {
         JObject stringToJObject(string s);
         JArray stringToJArray(string s);
         string getJsonString(string url, bool isEcom);
    }
    public class JsonOperations : IJsonOperations
    {
        #region String to json object Parser
        public JObject stringToJObject(string response)
        {
            return JObject.Parse(response);
        }
        #endregion

        #region String to json arra Parser
        public JArray stringToJArray(string response)
        {
            return JArray.Parse(response);
        }
        #endregion
        #region  get request json as string
        public string getJsonString(string url, bool isEcom)
        {
            WebClient wc = new WebClient();

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            wc.Headers.Add("Authorization", "Bearer " + (isEcom ? settings["ecommerceToken"].Value : settings["erpToken"].Value) + "");

            string response = wc.DownloadString(url);
            //JsonToClass(response, null);

            return response;
        }
        #endregion

    }
}
