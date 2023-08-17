using BSATask.DAL.Entities;
using BSATask.DAL.Interfaces;

namespace BSATask.DAL.Services
{
    public class Mock : IMock
    {
        public IEnumerable<Team> GetTeams()
        {
            return new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name ="HeadWorks",
                    CreatedAt = new DateTime(2022,8,10)
                },
                new Team()
                {
                    Id = 2,
                    Name ="BinaryStudio",
                    CreatedAt =  new DateTime(2022,6,15)
                },
                new Team()
                {
                    Id = 3,
                    Name ="Epam",
                    CreatedAt = new DateTime(2021,8,22)
                },
                new Team()
                {
                    Id = 4,
                    Name ="AltexSoft",
                    CreatedAt = new DateTime(2019,8,22)
                },
            };

        }

        public IEnumerable<Project> GetProjects()
        {
            return new List<Project>()
            {
                new Project()
                {
                    Id = 1,
                    UserId = 1,
                    TeamId = 1,
                    Name = "ProjectStructure",
                    Description="Create an ASP.NET Core Web API application using one of the following architectures: REST API (controllers/services) or CQRS",
                    CreatedAt=new DateTime(2023,4,10),
                    Deadline = new DateTime(2023, 9, 23),
                },
                new Project()
                {
                    Id = 2,
                    UserId = 2,
                    TeamId = 2,
                    Name = "NET Ecosystem 2023",
                    Description="Appreciative deputy, director of Parking, bazhaє to automate the routine processes of his business, through which, turning to you for help. Also, you need to create a simple program for curation",
                    CreatedAt=new DateTime(2023,5,15),
                    Deadline = new DateTime(2023, 9, 20),
                },
                new Project()
                {
                    Id = 3,
                    UserId = 4,
                    TeamId = 3,
                    Name = "Thread",
                    Description="The main idea of the project is to get to know our details of how we can look like a real project, learn about how the architecture of the project is mastered, marvel at the possible configuration, try to dig into someone else's code.",
                    CreatedAt=new DateTime(2023,5,10),
                    Deadline = new DateTime(2023, 12, 5),
                },
                new Project()
                {
                    Id = 4,
                    UserId = 5,
                    TeamId = 4,
                    Name = "Twitter",
                    Description="Make it look like twitter",
                    CreatedAt = new DateTime(2023,7,23),
                    Deadline = new DateTime(2023, 8, 23),
                },
            };
        }

        public IEnumerable<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    TeamId = 1,
                    FirstName = "Kevin",
                    LastName = "Taylor",
                    Email = "che.al@ukr.net",
                    RegisteredAt =new DateTime(2022,1,10),
                    BirthDay = new DateTime(1994, 7, 18)
                },
                new User()
                {
                    Id = 2,
                    TeamId = 2,
                    FirstName = "Sophie",
                    LastName = "Harris",
                    Email = "shevneva787@gmail.com",
                    RegisteredAt =new DateTime(2021, 2, 12),
                    BirthDay = new DateTime(1987, 12, 2)
                },
                new User()
                {
                    Id = 3,
                    TeamId = 3,
                    FirstName = "Lily",
                    LastName = "Lewis",
                    Email = "aslanov@gmail.com",
                    RegisteredAt =new DateTime(2020, 5, 1),
                    BirthDay = new DateTime(1988, 11, 4)
                },
                new User()
                {
                    Id = 4,
                    TeamId = 4,
                    FirstName = "Grace",
                    LastName = "King",
                    Email = "nicols@gmail.com",
                    RegisteredAt =new DateTime(2021, 10, 22),
                    BirthDay = new DateTime(1992, 10, 5)
                },
                new User()
                {
                    Id = 5,
                    TeamId = 1,
                    FirstName = "Scarlett",
                    LastName = "Young",
                    Email = "jack@gmail.com",
                    RegisteredAt =new DateTime(2019, 12, 2),
                    BirthDay = new DateTime(1995, 11, 2)
                },
                new User()
                {
                    Id = 6,
                    TeamId = 2,
                    FirstName = "Ellie",
                    LastName = "Moore",
                    Email = "biden@ukr.net",
                    RegisteredAt =new DateTime(2022, 10, 5),
                    BirthDay = new DateTime(1996, 8, 4)
                },
                new User()
                {
                    Id = 7,
                    TeamId = 3,
                    FirstName = "Paige",
                    LastName = "Walker",
                    Email = "llll@ukr.net",
                    RegisteredAt =new DateTime(2021, 1, 7),
                    BirthDay = new DateTime(1990, 7, 26)
                },
                new User()
                {
                    Id = 8,
                    TeamId = 1,
                    FirstName = "Maddison",
                    LastName = "Smith",
                    Email = "lok@ukr.net",
                    RegisteredAt =new DateTime(2022, 4, 18),
                    BirthDay = new DateTime(1998, 8, 10)
                },
            };
        }

        public IEnumerable<Entities.Task> GetTasks()
        {
            return new List<Entities.Task>()
            {
                new Entities.Task()
                {
                    Id = 1,
                    ProjectId = 1,
                    UserId = 1,
                    Name= "Create three to five models",
                    Description="Blame it on 3 to 5 elements in skin daytime at the start of the zastosunku",
                    State = TaskState.InProgress,
                    CreatedAt = new DateTime(2023,4,12)
                },
                new Entities.Task()
                {
                    Id = 2,
                    ProjectId = 1,
                    UserId = 2,
                    Name= "Implement models from past homework",
                    Description="Models that rotate with CRUD endpoints have the same structure as Swagger's front home (you can't change field names or you can see them instead);",
                    State = TaskState.Done,
                    CreatedAt = new DateTime(2023,4,14)
                },
                new Entities.Task()
                {
                    Id = 3,
                    ProjectId = 2,
                    UserId = 3,
                    Name= "Implementation of Repository or UnitOfWork",
                    Description="For work with danim, it’s better to win one of the patterns, as they were looked at during the lecture (Repository, UnitOfWork)",
                    State = TaskState.InProgress,
                    CreatedAt = new DateTime(2023,5,25)
                },
                new Entities.Task()
                {
                    Id = 4,
                    ProjectId = 2,
                    UserId = 4,
                    Name= "Created repository",
                    Description="Be kind, create a new repository on Bitbucket, and do not continue to work with the existing one",
                    State = TaskState.InProgress,
                    CreatedAt = new DateTime(2023,5,28)
                },
                new Entities.Task()
                {
                    Id = 5,
                    ProjectId = 3,
                    UserId = 5,
                    Name= "Created project",
                    Description="The creations of the project are responsible for the name BSATask.WebAPI",
                    State = TaskState.InProgress,
                    CreatedAt = new DateTime(2023,5,13)
                },
                new Entities.Task()
                {
                    Id = 6,
                    ProjectId = 3,
                    UserId = 6,
                    Name= "Implementation of DTO and DI",
                    Description="Guess about such words, like DTO and DI",
                    State = TaskState.InProgress,
                    CreatedAt = new DateTime(2023,5,15)
                },
                new Entities.Task()
                {
                    Id = 7,
                    ProjectId = 4,
                    UserId = 7,
                    Name= "Modernization UI",
                    Description="The console client is responsible for the upgrades to work with the server via HTTP",
                    State = TaskState.InProgress,
                    CreatedAt = new DateTime(2023,7,25)
                },
                new Entities.Task()
                {
                    Id = 8,
                    ProjectId = 4,
                    UserId = 8,
                    Name= "Created WEBAPI project",
                    Description="In the right solution (it is possible in a real repository) create a WebAPI project based on .NET 6",
                    State = TaskState.ToDo,
                    CreatedAt = new DateTime(2023,7,26)
                },
            };
        }
    }
}
