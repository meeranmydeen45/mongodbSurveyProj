using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Api.Cloud.Core.DataBase.Entities;

namespace Survey.Api.Cloud.Core.Database.EntityConfiguration
{
    public class ProjectEntityConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> entityBuilder)
        {
            entityBuilder.ToTable("Project", "Survey");

            entityBuilder.Property(p => p.Name).IsRequired().HasColumnType("varchar(255)");

            SeedData(entityBuilder);
        }

        private void SeedData(EntityTypeBuilder<Project> entityBuilder)
        {
            entityBuilder.HasData(
                new Project { Id = 1, Name = "Defualt" }
                );
        }
    }
}
