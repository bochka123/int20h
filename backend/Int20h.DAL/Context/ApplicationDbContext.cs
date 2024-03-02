using Int20h.DAL.Context.ModelConfigurations;
using Int20h.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Int20h.DAL.Context;

public class ApplicationDbContext: IdentityDbContext<User, Role, Guid>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {}

    public DbSet<StudentInformation> StudentInformations { get; set; }
    public DbSet<TeacherInformation> TeacherInformations { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<SessionAnswer> SessionAnswers { get; set; }
    public DbSet<StudentLesson> StudentLessons { get; set; }
    public DbSet<StudentSubject> StudentSubjects { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<TestSession> TestSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
