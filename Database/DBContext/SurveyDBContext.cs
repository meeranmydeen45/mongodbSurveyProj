using Microsoft.EntityFrameworkCore;
using Survey.Api.Cloud.Core.Database.EntityConfiguration;
using Survey.Api.Cloud.Core.DataBase.Entities;

namespace Survey.Api.Cloud.Core.DataBase.DBContext
{
    public class SurveyDBContext : DbContext
    {
        public SurveyDBContext(DbContextOptions<SurveyDBContext> options) : base(options)
        {

        }

        public DbSet<Question> Questoins { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<InputType> InputTypes { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Group> Groups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectEntityConfig());
            modelBuilder.ApplyConfiguration(new GroupEntityConfig());
            modelBuilder.ApplyConfiguration(new QuestionEntityConfig());
            modelBuilder.ApplyConfiguration(new OptionEntityConfig());
            modelBuilder.ApplyConfiguration(new InputTypeEntityConfig());
        }
    }
}
