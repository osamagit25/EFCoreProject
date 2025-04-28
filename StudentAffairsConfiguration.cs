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
    internal class StudentAffairsConfiguration : IEntityTypeConfiguration<StudentAffairs>
    {
        public void Configure(EntityTypeBuilder<StudentAffairs> builder)
        {
            builder.HasKey(sa => sa.Id);

            // Properties
            builder.Property(sa => sa.Name).IsRequired().HasMaxLength(100);
            builder.Property(sa => sa.Address).IsRequired().HasMaxLength(200);
            builder.Property(sa => sa.Age).IsRequired();

            // Relationships
            builder.HasMany(sa => sa.Attendances)
                   .WithOne(a => a.StudentAffairs)
                   .HasForeignKey(a => a.StudentAffairsId);
        }
    }
}
