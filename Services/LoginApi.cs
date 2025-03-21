using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DesktopDemoProject.Services
{
    public  class LoginApi
    {
        string loginUrlAdmin = "https://kohinoortrade.com/users/login";

        /// <summary>
        /// //Call API something like below; sample code
        //LogInApi login = new LogInApi();
        //var result = await login.PostAPIAdmin("avinixsolutions@gmail.com", "123456789", LoginUserType.Admin);
        /// </summary>
        /// <returns></returns>
        public async Task<LoginResultAdmin> PostAPIAdmin()
        {           
            HttpClient client = new HttpClient();
            HttpRequestMessage request;
            HttpResponseMessage response;
            string responseBody;
            LoginResultAdmin result = new LoginResultAdmin();
            try
            {                
                request = new HttpRequestMessage(HttpMethod.Post, loginUrlAdmin);
                var stringData = JsonConvert.SerializeObject
                    (new PostDataAdmin
                    {
                        email = "avinixsolutions@gmail.com",
                        isMobile = false,
                        isWeb = false,
                        isWindows = true,
                        password = "123456789",
                        DeviceDetails = new DeviceDetails { Device = "Android", platform = "Samsung Galaxy S23 Ultra" }
                    });
                var stringContent = new StringContent(stringData, Encoding.UTF8, "application/json");
                request.Content = stringContent;

                List<NameValueHeaderValue> listHeaders = new List<NameValueHeaderValue>
                {
                    new NameValueHeaderValue("Encoding", "utf-8"),
                    new NameValueHeaderValue("Connection", "keep-alive")
                };

                foreach (var header in listHeaders)
                {
                    request.Headers.Add(header.Name, header.Value);
                }
                response = await client.SendAsync(request);
                responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<LoginResultAdmin>(responseBody);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
    
}


