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
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            // Properties
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Address).IsRequired().HasMaxLength(200);
            builder.Property(s => s.Age).IsRequired();

            // Relationships
            builder.HasMany(s => s.Attendances)
                   .WithOne(a => a.Student)
                   .HasForeignKey(a => a.StudentId);

            builder.HasMany(s => s.Grades)
                   .WithOne(g => g.Student)
                   .HasForeignKey(g => g.StudentId);

        }
    }
}
