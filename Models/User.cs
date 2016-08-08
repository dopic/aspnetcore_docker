using System;

namespace AspNetCoreDocker.Models
{
    public class User
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}