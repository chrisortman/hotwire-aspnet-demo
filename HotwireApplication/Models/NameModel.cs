using System.ComponentModel.DataAnnotations;

namespace HotwireApplication.Models
{
    public class NameModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Dude, type your name")]
        public string Firstname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name too!")]
        public string Lastname { get; set; }
        
    }
}