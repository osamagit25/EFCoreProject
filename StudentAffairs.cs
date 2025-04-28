using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.Entities
{
    internal class StudentAffairs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address  { get; set; }
        public string Password { get; set; }
        public ICollection<Attendance> Attendances { get; set; }

    }
}
