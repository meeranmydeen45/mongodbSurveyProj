using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Api.Cloud.Core.DataBase.Entities;

namespace Survey.Api.Cloud.Core.Database.EntityConfiguration
{
    public class InputTypeEntityConfig : IEntityTypeConfiguration<InputType>
    {
        public void Configure(EntityTypeBuilder<InputType> entityBuilder)
        {
            entityBuilder.ToTable("InputType", "Survey");

            entityBuilder.Property(p => p.Name).IsRequired(false).HasColumnType("varchar(50)");

            entityBuilder.HasData(new InputType {Id = 1, Name = "TextField"},
                                  new InputType {Id = 2, Name = "Numeric"},
                                  new InputType {Id = 3, Name = "Dropdown"},
                                  new InputType {Id = 4, Name = "Radio"},
                                  new InputType {Id = 5, Name = "Checkbox"},
                                  new InputType {Id = 6, Name = "Toggle/Digital"},
                                  new InputType {Id = 7, Name = "TextArea"},
                                  new InputType {Id = 8, Name = "Date"},
                                  new InputType {Id = 9, Name = "Autocomplete"},
                                  new InputType {Id = 10,Name = "Attachment"},
                                  new InputType {Id = 11,Name = "MultiSelect Dropdown"},
                                  new InputType {Id = 12,Name = "MultiSelect Checkbox"},
                                  new InputType {Id = 13,Name = "Complex"}
                                  );
        }
    }
}
