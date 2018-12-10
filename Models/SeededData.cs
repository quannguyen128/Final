using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Final.Models
{
    public class SeededData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
            
                // CLIENTS
                if (context.Clients.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var clients = new List<Client>
                {
                    new Client 
                    { 
                        FirstName = "Albert",
                        LastName = "Sons",
                        CompanyName = "Albertsons",
                        Email = "albertsons@gmail.com",
                        Phone = "(806) 655-2300"
                    },
                     new Client 
                    { 
                        FirstName = "Richard",
                        LastName = "Ware II",
                        CompanyName = "Amarillo National Bank",
                        Email = "A&B@gmail.com",
                        Phone = "(806) 765-8868"
                    },

                };
                context.AddRange(clients);
                context.SaveChanges();

                //Members
                if (context.Members.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }
              

                var members = new List<Member>
                {
                    new Member
                    {
                        FirstName = "Micheal",
                        LastName = "Scott",
                        Email = "michaealscott@gmail.com",
                        Major = "CIS",    
                        Phone = "(806) 578 9854"
                    },
                    new Member
                    {
                        FirstName = "Joey",
                        LastName = "Tribbiani",
                        Email = "jTribbiani@gmail.com",
                        Major = "CIDM",    
                        Phone = "(806) 897 7893" 
                    },
                    new Member
                    {
                        FirstName = "Rachel",
                        LastName = "Green",
                        Email = "RachelGreen@hotmail.com",
                        Major = "CIS",    
                        Phone = "(806) 578 9854" 
                    },
                    new Member
                    {
                        FirstName = "Pheobe",
                        LastName = "Buffay",
                        Email = "buffay@yahoo.com",
                        Major = "CIS",    
                        Phone = "(806) 979 3825"
                        
                    },
                    new Member
                    {
                        FirstName = "Monica",
                        LastName = "Geller",
                        Email = "MGeller@gmail.com",
                        Major = "Finance",    
                        Phone = "(806) 889 9322" 
                    },
                    new Member
                    {
                        FirstName = "Chandler",
                        LastName = "Bing",
                        Email = "CBIngn@hotmail.com",
                        Major = "CIDM",    
                        Phone = "(806) 893 3432" 
                    },
                     new Member
                    {
                        FirstName = "Ross",
                        LastName = "Geller",
                        Email = "RossGeller@yopmail.com",
                        Major = "CIS",    
                        Phone = "(806) 839 2389" 
                    },

                    new Member
                    {
                        FirstName = "Dwight",
                        LastName = "Schrute",
                        Email = "SchruteD@hotmail.com",
                        Major = "Business",    
                        Phone = "(806) 439 3433"    
                    },
                    
                    new Member
                    {
                        FirstName = "Jim",
                        LastName = "Halpert", 
                        Email = "JimBoi@hotmail.com",
                        Major = "CIDM",    
                        Phone = "(806) 843 3483"   
                    },
                    
                    new Member
                    {
                        FirstName = "Pam",
                        LastName = "Beesly",
                        Email = "Beeslypam@hotmail.com",
                        Major = "Finance",    
                        Phone = "(806) 839 4833"   
                    },
                };
                context.AddRange(members);
                context.SaveChanges();

                //PROJECTS
                if (context.Projects.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var projects = new List<Project>
                {
                    new Project 
                    {
                        ProjectName = "A&BSystems",
                        ProjectDescription = "Updating Amarillo National Bank's customer information systems ",
                    },
                    new Project 
                    {
                        ProjectName = "UnitedSupMrktSystems",
                        ProjectDescription = "Redesigning the POS System",
                    },
                };
                context.AddRange(projects);
                context.SaveChanges();

                //PROJECT ROSTER BRIDGE TABLE - THERE MUST BE PROJECTS AND PARTICIPANTS MADE FIRST
                if (context.ProjectRoster.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                

                //quickly grab the recent records added to the DB to get the IDs
                var projectsFromDb = context.Projects.ToList();
                var clientsFromDb = context.Clients.ToList();
                var membersFromDb = context.Members.ToList();

                var projectroster = new List<ProjectRoster>
                {
                    //take the first project from above, the first client from above, and the first three students from above.
                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = clientsFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = clientsFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(1).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(1) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(2).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(2) },                                        
                };
                context.AddRange(projectroster);
                context.SaveChanges();               

            }
        }

    }
}