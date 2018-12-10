using System;
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Final.Models
{
    
    public class AppDbContext : DbContext
    {
        // private const string ConnectionString = @"Data Source=MyFirstEfCoreDb.db";
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            
            // optionsBuilder.UseSqlite(ConnectionString); 
        }        

        public DbSet<Final.Models.Member> Members { get; set; }     
        public DbSet<Final.Models.Project> Projects {get; set;}   
        public DbSet<Final.Models.Client> Clients {get; set;}
        public DbSet<Final.Models.ProjectRoster> ProjectRoster { get; set; }


          protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Member>().ToTable("Client");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Project>().ToTable("Project");


            //Many to Many relationships
            //https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration

            //establish the join through the keys
            modelBuilder.Entity<ProjectRoster>()
                .HasKey(pr => new {pr.ProjectID, pr.ProjectParticipantID});

            //set up the one to many map from Project to ProjectRoster
            modelBuilder.Entity<ProjectRoster>()
                .HasOne(pr => pr.Project)
                .WithMany(p => p.Participants)
                .HasForeignKey(pr => pr.ProjectID);

            //set up the one to many map from ProjectParticipant to ProjectRoster
            modelBuilder.Entity<ProjectRoster>()
                .HasOne(pr => pr.ProjectParticipant)
                .WithMany(pp => pp.Projects)
                .HasForeignKey(pr => pr.ProjectParticipantID);

        }

        

    }    
}