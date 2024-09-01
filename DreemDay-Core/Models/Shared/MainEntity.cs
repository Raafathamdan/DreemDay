using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Models.Shared
{
    public class MainEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }= DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
