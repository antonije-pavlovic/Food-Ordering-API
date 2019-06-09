using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class UpdateUserDTO
    {        
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IsDeleted { get; set; }
        public int RoleId { get; set; }
    }
}
