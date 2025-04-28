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
    internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Address).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Age).IsRequired();

            // Relationships
            builder.HasMany(t => t.Grades)
                   .WithOne(g => g.Teacher)
                   .HasForeignKey(g => g.TeacherId);
        }
    }
}
