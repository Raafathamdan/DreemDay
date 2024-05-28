using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.UserDTOs
{
    public class UserByIdDto
    {
        public int Id { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int Email { get; set; }
        public int Phone { get; set; }
        public string BirthDate { get; set; }
        public string CreationDate { get; set; }
        public string? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
