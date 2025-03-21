
namespace DesktopDemoProject.Services
{
    public class PostDataAdmin    {
        public string email { get; set; }
        public bool isWeb { get; set; }
        public bool isMobile { get; set; }
        public bool isWindows { get; set; }
        public string password { get; set; }
        public DeviceDetails DeviceDetails { get; set; }
    }
}
