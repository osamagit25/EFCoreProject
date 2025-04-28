using EFCoreProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.ClassConfigration
{
    internal class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.Id);

            // Relationships
            builder.HasOne(g => g.Student)
                   .WithMany(s => s.Grades)
                   .HasForeignKey(g => g.StudentId);

            builder.HasOne(g => g.Course)
                   .WithMany(c => c.Grades)
                   .HasForeignKey(g => g.CourseId);

            builder.HasOne(g => g.Teacher)
                   .WithMany(t => t.Grades)
                   .HasForeignKey(g => g.TeacherId);
        }
    }
}
