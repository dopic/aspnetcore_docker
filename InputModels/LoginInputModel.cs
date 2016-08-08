using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDocker.ViewModels
{
    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }        
    }    
}