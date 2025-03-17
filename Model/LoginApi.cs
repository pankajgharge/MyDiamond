using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace DesktopDemoProject.Model
{
    public  class LoginApi
    {
        public async Task PostAPI()
        {
           
            HttpClient client = new HttpClient();
            HttpRequestMessage request;
            HttpResponseMessage response;
            string responseBody;
            try
            {
                request = new HttpRequestMessage(HttpMethod.Post, "https://kohinoor-whak.onrender.com/users/login");
                var stringData = JsonConvert.SerializeObject
                    (new PostData
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

                List<NameValueHeaderValue> listHeaders = new List<NameValueHeaderValue>();
                listHeaders.Add(new NameValueHeaderValue("Encoding", "utf-8"));
                //listHeaders.Add(new NameValueHeaderValue("user-agent", "DESKTOP-87VE32K"));
                listHeaders.Add(new NameValueHeaderValue("Connection", "keep-alive"));


                foreach (var header in listHeaders)
                {
                    request.Headers.Add(header.Name, header.Value);
                }

                response = await client.SendAsync(request);

                responseBody = await response.Content.ReadAsStringAsync();

                var deserializeLogin = JsonConvert.DeserializeObject<LoginResult>(responseBody);

                Console.WriteLine(responseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
    public class LoginResult
    {
        //{"message":"Login successful","token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY3NzI2ZjEyYzg2MDI4Yjc0YTdlMzY0MSIsInJvbGUiOiJhZG1pbiIsImlhdCI6MTc0MTE1NTM2Nn0.o7WFcIz_hfYaUFClVumdzrBbarBnlLOjjEBPr3XGOtY","user":{"email":"avinixsolutions@gmail.com","user_id":"67726f12c86028b74a7e3641","name":"Avinix","role":"Admin","profilePic":"http://kohinoor-whak.onrender.com/uploads/AdminProfilePic/1735552786335.jpg","phoneNumber":"9426637566","companyName":"Avinix Solutions"}}
        public string message { get; set; }
        public string Token { get; set; }
        public LoginUser User { get; set; }
    }

    public class LoginUser
    {
        public string Email { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string ProfilePic { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
    }


    public class PostData
    {
        public string email { get; set; }
        public bool isWeb { get; set; }
        public bool isMobile { get; set; }
        public bool isWindows { get; set; }
        public string password { get; set; }
        public DeviceDetails DeviceDetails { get; set; }
    }
    public class DeviceDetails
    {
        public string platform { get; set; }
        public string Device { get; set; }

        //Sample Checkin
        //Sample checkin 2
        //Sample Checkin Anita Test
    }
}


