using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.Entities
{
    internal class Teacher
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public ICollection<Grade> Grades { get; set; }

    }
}
