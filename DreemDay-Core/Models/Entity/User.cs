using DreemDay_Core.Models.Shared;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DreemDay_Core.Helper.Enums.SystemEnum;

namespace DreemDay_Core.Models.Entity
{
    public class User : MainEntity
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int Email { get; set; }
        public int Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Role Role { get; set; }  
    }
}
