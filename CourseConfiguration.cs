﻿using EFCoreProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.ClassConfigration
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Duration).IsRequired();

            // Relationships
            builder.HasMany(c => c.Grades)
                   .WithOne(g => g.Course)
                   .HasForeignKey(g => g.CourseId);
        }
    }
}
