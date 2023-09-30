namespace App.Application.Common.Dtos
{
    /// <summary>
    /// </summary>
    public class DeviceInfo
    {
        public bool IsMobileDevice { get; set; }

        public bool IsWindows { get; set; }

        public string OsFamily { get; set; }

        public string Browser { get; set; }

        public int BrowserMajorVersion { get; set; }

        public string BrowserFullVersion { get; set; }


        public string DeviceFamily { get; set; }

        public string DeviceBrand { get; set; }

        public string DeviceModel { get; set; }
    }
}
