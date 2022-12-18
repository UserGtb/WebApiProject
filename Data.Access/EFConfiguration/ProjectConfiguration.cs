using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.App;

namespace Data.Access.EFConfiguration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<ProjectAppStored>
    {
        public void Configure(EntityTypeBuilder<ProjectAppStored> builder)
        {
            builder.HasKey(projectapp => projectapp.ID);
            builder.HasIndex(projectapp => projectapp.ID).IsUnique();
        }
    }
}
