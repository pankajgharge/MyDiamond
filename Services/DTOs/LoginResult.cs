namespace DesktopDemoProject.Services
{
    public class LoginResult
    {
        //{"message":"Login successful","token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY3NzI2ZjEyYzg2MDI4Yjc0YTdlMzY0MSIsInJvbGUiOiJhZG1pbiIsImlhdCI6MTc0MTE1NTM2Nn0.o7WFcIz_hfYaUFClVumdzrBbarBnlLOjjEBPr3XGOtY","user":{"email":"avinixsolutions@gmail.com","user_id":"67726f12c86028b74a7e3641","name":"Avinix","role":"Admin","profilePic":"http://kohinoor-whak.onrender.com/uploads/AdminProfilePic/1735552786335.jpg","phoneNumber":"9426637566","companyName":"Avinix Solutions"}}
        public string message { get; set; }
        public string Token { get; set; }
        public LoginUser User { get; set; }
    }

}
