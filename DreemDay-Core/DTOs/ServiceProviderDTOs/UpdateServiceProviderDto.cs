using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.ServiceProviderDTOs
{
    public class UpdateServiceProviderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string ProfileImage { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
