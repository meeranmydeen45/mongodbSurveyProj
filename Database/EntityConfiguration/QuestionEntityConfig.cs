using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Api.Cloud.Core.DataBase.Entities;

namespace Survey.Api.Cloud.Core.Database.EntityConfiguration
{
    public class QuestionEntityConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> entityBuilder)
        {
            entityBuilder.ToTable("Question", "Survey");

            entityBuilder.Property(p => p.Title).IsRequired().HasColumnType("varchar(255)");

            entityBuilder.Property(p => p.InputTypeId).IsRequired();

            entityBuilder.Property(p => p.IsMandatory).IsRequired();

            entityBuilder.Property(p => p.Formula).IsRequired(false).HasColumnType("varchar(255)");

            entityBuilder.Property(p => p.QuestionGroupId).IsRequired(false);

            entityBuilder.Property(p => p.ProjectId).IsRequired();

            entityBuilder.HasOne(p => p.InputTypeNavigation)
                         .WithMany(p => p.Questions)
                         .HasForeignKey(p => p.InputTypeId)
                         .OnDelete(DeleteBehavior.ClientSetNull)
                         .HasConstraintName("[Fk_Question_InputTypeId]");

            entityBuilder.HasOne(p => p.GroupNavigation)
                         .WithMany(p => p.Questions)
                         .HasForeignKey(p => p.QuestionGroupId)
                         .IsRequired(false)
                         .OnDelete(DeleteBehavior.ClientSetNull)
                         .HasConstraintName("[Fk_Question_QuestionGroupId]");

            entityBuilder.HasOne(p => p.ProjectNavigation)
                         .WithMany(p => p.Questions)
                         .HasForeignKey(p => p.ProjectId)
                         .OnDelete(DeleteBehavior.ClientSetNull)
                         .HasConstraintName("[Fk_Question_ProjectId]");

            SeedData(entityBuilder);

        }

        private void SeedData(EntityTypeBuilder<Question> entityBuilder)
        {
            entityBuilder.HasData(
                new Question { Id = 1, Title = "Types of Establishment", InputTypeId = 5, IsMandatory = false, ProjectId = 1},
                new Question { Id = 2, Title = "Gender", InputTypeId = 5, IsMandatory = true, ProjectId = 1 }
                );
        }
    }
}
