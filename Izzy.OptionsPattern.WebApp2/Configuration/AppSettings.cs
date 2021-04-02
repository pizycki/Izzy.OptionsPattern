using System.ComponentModel.DataAnnotations;

namespace Izzy.OptionsPattern.WebApp1.Configuration
{
    public class AppSettings
    {
        [Required]
        public string ServiceName { get; set; }
    }
}