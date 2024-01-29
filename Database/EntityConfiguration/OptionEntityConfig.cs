using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Api.Cloud.Core.DataBase.Entities;

namespace Survey.Api.Cloud.Core.Database.EntityConfiguration
{
    public class OptionEntityConfig : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> entityBuilder)
        {
            entityBuilder.ToTable("Option", "Survey");

            entityBuilder.Property(p => p.Value).IsRequired().HasColumnType("varchar(255)");

            entityBuilder.Property(p => p.Key).IsRequired();

            entityBuilder.HasOne(p => p.QuestionNavigation)
                         .WithMany(p => p.Options)
                         .HasForeignKey(p => p.QuestionId)
                         .OnDelete(DeleteBehavior.ClientSetNull)
                         .HasConstraintName("[Fk_Option_QuestionId]");

            SeedData(entityBuilder);

        }

        private void SeedData(EntityTypeBuilder<Option> entityBuilder)
        {
            entityBuilder.HasData(
                new Option { Id = 1, Value = "Residential", Key = 0, QuestionId = 1 },
                new Option { Id = 2, Value = "Commercial", Key = 1, QuestionId = 1 },
                new Option { Id = 3, Value = "Male", Key = 0, QuestionId = 2 },
                new Option { Id = 4, Value = "Female", Key = 1, QuestionId = 2 }
                );
        }
    }
}
