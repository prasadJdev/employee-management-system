using System.ComponentModel.DataAnnotations;

namespace employeeProject.Models
{
    public class People
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string Password { get; set; }
        
        public string Forgot_Password { get; set; }

        public bool Role { get; set; }//Admin - 0; User - 1
        // public DateOnly Doj { get; set; }
        public string Doj { get; set; }
        
        public string LastActive { get; set; }
    }
}
