using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.Entities
{
    internal class Grade
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }

        // Navigation properties
        public Student Student { get; set; }
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }



    }
}
