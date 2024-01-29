using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Api.Cloud.Core.DataBase.Entities;

namespace Survey.Api.Cloud.Core.Database.EntityConfiguration
{
    public class GroupEntityConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> entityBuilder)
        {
            entityBuilder.ToTable("Group", "Survey");

            entityBuilder.Property(p => p.Name).IsRequired().HasColumnType("varchar(255)");

        }
    }
}
