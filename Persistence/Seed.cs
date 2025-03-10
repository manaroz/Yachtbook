using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context,
            UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any() && !context.Activities.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }

                var activities = new List<Activity>
            {
                new Activity
                {
                    Title = "Past Activity 1",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Activity 2 months ago",
                    Category = "books",
                    City = "Sopot",
                    Venue = "Books pub",
                    Attendees = new List<ActivityAttendee>
                    {
                        new ActivityAttendee
                        {
                            AppUser = users[0],
                            IsHost = true
                        }
                    }
                },
                new Activity
                {
                    Title = "Past Activity 2",
                    Date = DateTime.Now.AddMonths(-1),
                    Description = "Activity 1 month ago",
                    Category = "culture",
                    City = "Gdańsk",
                    Venue = "Zbrojownia",
                    Attendees = new List<ActivityAttendee>
                    {
                        new ActivityAttendee
                        {
                            AppUser = users[0],
                            IsHost = true
                        },
                        new ActivityAttendee
                        {
                            AppUser = users[1],
                            IsHost = false
                        },
                    }
                },
                new Activity
                {
                    Title = "Future Activity 1",
                    Date = DateTime.Now.AddMonths(1),
                    Description = "Activity 1 month in future",
                    Category = "science",
                    City = "Gdynia",
                    Venue = "Park Naukowo Technologiczny",
                    Attendees = new List<ActivityAttendee>
                    {
                        new ActivityAttendee
                        {
                            AppUser = users[2],
                            IsHost = true
                        },
                        new ActivityAttendee
                        {
                            AppUser = users[1],
                            IsHost = false
                        },
                    }
                },
                new Activity
                {
                    Title = "Future Activity 2",
                    Date = DateTime.Now.AddMonths(2),
                    Description = "Activity 2 months in future",
                    Category = "music",
                    City = "Sopot",
                    Venue = "Ergo Arena",
                    Attendees = new List<ActivityAttendee>
                    {
                        new ActivityAttendee
                        {
                            AppUser = users[0],
                            IsHost = true
                        },
                        new ActivityAttendee
                        {
                            AppUser = users[2],
                            IsHost = false
                        },
                    }
                },
                new Activity
                {
                    Title = "Future Activity 3",
                    Date = DateTime.Now.AddMonths(3),
                    Description = "Activity 3 months in future",
                    Category = "drinks",
                    City = "Gdańsk",
                    Venue = "B90 pub",
                    Attendees = new List<ActivityAttendee>
                    {
                        new ActivityAttendee
                        {
                            AppUser = users[1],
                            IsHost = true
                        },
                        new ActivityAttendee
                        {
                            AppUser = users[0],
                            IsHost = false
                        },
                    }
                },
                new Activity
                {
                    Title = "Future Activity 4",
                    Date = DateTime.Now.AddMonths(4),
                    Description = "Activity 4 months in future",
                    Category = "learning",
                    City = "Sopot",
                    Venue = "CDK UG",
                    Attendees = new List<ActivityAttendee>
                    {
                        new ActivityAttendee
                        {
                            AppUser = users[1],
                            IsHost = true
                        }
                    }
                },
                new Activity
                {
                    Title = "Future Activity 5",
                    Date = DateTime.Now.AddMonths(5),
                    Description = "Activity 5 months in future",
                    Category = "science",
                    City = "Gdańsk",
                    Venue = "GPN-T",
                    Attendees = new List<ActivityAttendee>
                    {
                        new ActivityAttendee
                        {
                            AppUser = users[0],
                            IsHost = true
                        },
                        new ActivityAttendee
                        {
                            AppUser = users[1],
                            IsHost = false
                        },
                    }
                },
                new Activity
                {
                    Title = "Future Activity 6",
                    Date = DateTime.Now.AddMonths(6),
                    Description = "Activity 6 months in future",
                    Category = "music",
                    City = "Warszawa",
                    Venue = "Proxima",
                    Attendees = new List<ActivityAttendee>
                    {
                        new ActivityAttendee
                        {
                            AppUser = users[2],
                            IsHost = true
                        },
                        new ActivityAttendee
                        {
                            AppUser = users[1],
                            IsHost = false
                        },
                    }
                },
                new Activity
                {
                    Title = "Future Activity 7",
                    Date = DateTime.Now.AddMonths(7),
                    Description = "Activity 2 months ago",
                    Category = "travel",
                    City = "London",
                    Venue = "Somewhere on the Thames",
                    Attendees = new List<ActivityAttendee>
                    {
                        new ActivityAttendee
                        {
                            AppUser = users[0],
                            IsHost = true
                        },
                        new ActivityAttendee
                        {
                            AppUser = users[2],
                            IsHost = false
                        },
                    }
                },
                new Activity
                {
                    Title = "Future Activity 8",
                    Date = DateTime.Now.AddMonths(8),
                    Description = "Activity 8 months in future",
                    Category = "film",
                    City = "Gdynia",
                    Venue = "GCF",
                    Attendees = new List<ActivityAttendee>
                    {
                        new ActivityAttendee
                        {
                            AppUser = users[2],
                            IsHost = true
                        },
                        new ActivityAttendee
                        {
                            AppUser = users[1],
                            IsHost = false
                        },
                    }
                }
            };

                await context.Activities.AddRangeAsync(activities);
                await context.SaveChangesAsync();
            }
        }
    }
}