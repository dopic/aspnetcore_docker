using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDocker.InputModels
{
    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }        
    }    
}