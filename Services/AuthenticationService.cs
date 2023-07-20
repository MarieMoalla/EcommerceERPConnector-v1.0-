using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;

namespace EcommerceERPConnector_V1._0_.Services
{
        public interface IAuthenticationService
        {
             string AuthenticateUser(bool isErp, string endpoint, string username, string password, string usernameJsonBody, string passwordJsonBody);
             bool IsAuthenticated();
        }
        class AuthenticationService : IAuthenticationService
        {
            public AuthenticationService() { }
            public string AuthenticateUser(bool isErp, string endpoint, string username, string password, string usernameJsonBody, string passwordJsonBody)
            {
                string method = "POST";
                string json = "{\"" + usernameJsonBody + "\": \"" + username + "\",\"" + passwordJsonBody + "\":\"" + password + "\"}";

                WebClient wc = new WebClient();
                wc.Headers["Content-Type"] = "application/json";
                try
                {
                    string response = wc.UploadString(endpoint, method, json);
                    dynamic jsonObj = JsonConvert.DeserializeObject(response);

                    var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var settings = configFile.AppSettings.Settings;

                    //in case you want to add new key 
                    //settings.Add("ecommerceToken", jsonObj.access_token);

                    if (isErp) settings["erpToken"].Value = jsonObj.token; else settings["ecommerceToken"].Value = jsonObj.access_token;

                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

                    return "Connected!";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

            public bool IsAuthenticated()
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (String.IsNullOrEmpty(settings["erpToken"].Value) || String.IsNullOrEmpty(settings["ecommerceToken"].Value)) return false;
                else return true;
            }
        }
}
