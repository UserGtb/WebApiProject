using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.App;

namespace Data.Access.EFConfiguration
{
    /// <summary>
    /// Implementing class with the interface IEntityTypeConfiguration for use in method OnModelCreating of the DbContext class
    /// </summary>
    public class ProjectConfiguration : IEntityTypeConfiguration<ProjectAppStored>
    {
        public void Configure(EntityTypeBuilder<ProjectAppStored> builder)
        {
            builder.HasKey(projectapp => projectapp.ID);
            builder.HasIndex(projectapp => projectapp.ID).IsUnique();
        }
    }
}
