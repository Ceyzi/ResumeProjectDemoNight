using Microsoft.EntityFrameworkCore;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Context
{

    public class ResumeContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CEYDA;initial catalog=ProjectNightResumeDb; integrated security=true;trust server certificate=true");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Message> Messages  { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials{ get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

    }
}
