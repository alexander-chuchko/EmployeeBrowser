using BSATask.DAL.Entities;
using BSATask.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BSATask.DAL.Context
{
    public class BSATaskContext : DbContext
    {
        private readonly IMock _mock;
        public BSATaskContext(DbContextOptions<BSATaskContext> options, IMock mock) : base(options)
        {
            _mock = mock;
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Team>().HasData(_mock.GetTeams());
            modelBuilder.Entity<Entities.User>().HasData(_mock.GetUsers());
            modelBuilder.Entity<Entities.Project>().HasData(_mock.GetProjects());
            modelBuilder.Entity<Entities.Task>().HasData(_mock.GetTasks());
        }
    }
}
