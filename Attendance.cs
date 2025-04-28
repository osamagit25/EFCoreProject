using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.Entities
{
    internal class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int StudentId { get; set; }
        public int StudentAffairsId { get; set; }

        // Navigation properties
        public Student Student { get; set; }
        public StudentAffairs StudentAffairs { get; set; }

    }
}
