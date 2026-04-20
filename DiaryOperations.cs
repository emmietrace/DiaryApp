using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;
using DiaryApp;
using System;
using System.Collections.Generic;
using System.Text;
using DiaryApp.Data;

namespace DiaryApp
{
    public static class DiaryOperations
    {
        public static async Task AddNewDiaryEntries(DiaryDbContext context)
        {
            // First, we are checking if we already have data so we don't insert duplicates if you run this twice
            if (await context.DiaryEntries.AnyAsync())
            {
                Console.WriteLine("Database already has records. Skipping insertion.");
                return;
            }

            Console.WriteLine("Generating tags and 10 new diary entries...");

            // 1. Create Reusable Tags
            var tagML = new Tag { Name = "Machine Learning", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now };
            var tagWebDev = new Tag { Name = "Web Development", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now };
            var tagSchool = new Tag { Name = "Covenant University", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now };
            var tagWork = new Tag { Name = "Teaching", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now };
            var tagInternship = new Tag { Name = "SIWES Prep", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now };
            var tagData = new Tag { Name = "Data Analysis", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now };

            // 2. Create 10 Diary Entries
            var entries = new List<DiaryEntry>
    {
        new DiaryEntry
        {
            Title = "SIWES Application Drafts",
            Body = "Spent the morning drafting applications for the upcoming 6-month SIWES placement (March to August). I really want to land a role where I can transition my Data Analysis skills into full-blown Data Science.",
            CreatedDate = DateTime.Now.AddDays(-10), ModifiedDate = DateTime.Now.AddDays(-10),
            Tags = new List<Tag> { tagInternship, tagData }
        },
        new DiaryEntry
        {
            Title = "Teaching at Alpha Beta",
            Body = "Part-time teaching at Alpha Beta College went well today. Explaining basic concepts to students actually helps solidify my own foundational knowledge. Exhausting, but rewarding.",
            CreatedDate = DateTime.Now.AddDays(-9), ModifiedDate = DateTime.Now.AddDays(-9),
            Tags = new List<Tag> { tagWork }
        },
        new DiaryEntry
        {
            Title = "House Price & Titanic Models",
            Body = "Revisited my older projects today. I refactored the House Price Prediction system and the Titanic survival model to optimize the hyperparameters. Python and SQL are feeling very natural right now.",
            CreatedDate = DateTime.Now.AddDays(-8), ModifiedDate = DateTime.Now.AddDays(-8),
            Tags = new List<Tag> { tagML, tagData }
        },
        new DiaryEntry
        {
            Title = "Breast Cancer Neural Net",
            Body = "Ran an experiment predicting breast cancer using a neural network. The accuracy is improving, but I need to tweak the hidden layers. Machine learning is definitely the path I want to take.",
            CreatedDate = DateTime.Now.AddDays(-7), ModifiedDate = DateTime.Now.AddDays(-7),
            Tags = new List<Tag> { tagML }
        },
        new DiaryEntry
        {
            Title = "Wine Cultivar Prediction",
            Body = "Started a new classification project: building a model to predict the origin of wine cultivars. Dealing with a lot of feature scaling today.",
            CreatedDate = DateTime.Now.AddDays(-6), ModifiedDate = DateTime.Now.AddDays(-6),
            Tags = new List<Tag> { tagML }
        },
        new DiaryEntry
        {
            Title = "300-Level Hustle",
            Body = "Being a 300-Level Computer Science student is no joke. The workload is heavy this week, but staying organized is keeping me sane. Operations Research assignments are taking up a lot of time.",
            CreatedDate = DateTime.Now.AddDays(-5), ModifiedDate = DateTime.Now.AddDays(-5),
            Tags = new List<Tag> { tagSchool }
        },
        new DiaryEntry
        {
            Title = "Operations Research Breakthrough",
            Body = "Finally wrapped my head around the latest Operations Research problem. It took a few hours of mapping out the linear programming model, but I got the optimal solution.",
            CreatedDate = DateTime.Now.AddDays(-4), ModifiedDate = DateTime.Now.AddDays(-4),
            Tags = new List<Tag> { tagSchool }
        },
        new DiaryEntry
        {
            Title = "DSA: Stacks, Queues, Trees",
            Body = "Completed my assignments on Data Structures and Algorithms. Writing out the logic for Trees and Graphs in C++ and Java was challenging but satisfying once the code compiled.",
            CreatedDate = DateTime.Now.AddDays(-3), ModifiedDate = DateTime.Now.AddDays(-3),
            Tags = new List<Tag> { tagSchool }
        },
        new DiaryEntry
        {
            Title = "Full-Stack Portfolio",
            Body = "Working on updating my portfolio site. I'm using React.js and TypeScript for the frontend, and handling the backend routing with Flask. It's coming together nicely.",
            CreatedDate = DateTime.Now.AddDays(-2), ModifiedDate = DateTime.Now.AddDays(-2),
            Tags = new List<Tag> { tagWebDev }
        },
        new DiaryEntry
        {
            Title = "Power BI Dashboard",
            Body = "Built a Power BI dashboard to visualize the results from my ML models. It's one thing to have the raw predictions, but visualizing it makes the data actually tell a story.",
            CreatedDate = DateTime.Now.AddDays(-1), ModifiedDate = DateTime.Now.AddDays(-1),
            Tags = new List<Tag> { tagData, tagML }
        }
    };

            // 3. Add to the DbContext (AddRangeAsync handles multiple records at once)
            await context.DiaryEntries.AddRangeAsync(entries);

            // 4. Save changes to the database
            await context.SaveChangesAsync();

            Console.WriteLine("10 Diary entries successfully seeded into the database!");
        }

        public static async Task WriteEntryFromConsole(DiaryDbContext context)
        {
            Console.WriteLine("\nWrite a New Diary Entry: ");

            //Capture the title
            Console.Write("Title: ");
            string titleInput = Console.ReadLine();

            //Capture the body
            Console.Write("Dear Diary...");
            string bodyInput = Console.ReadLine();

            //Capture the category
            Console.Write("What Category does today's even fall under? ");
            string categoryInput = Console.ReadLine();

            //creating single Tag object

            var singleTag = new Tag
            {
                Name = categoryInput,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now

            };

            var newEntry = new DiaryEntry
            {
                Title = titleInput,
                Body = bodyInput,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,

                Tags = new List<Tag> { singleTag }
            };

            Console.WriteLine("\nSaving to the database...");

            await context.DiaryEntries.AddAsync(newEntry);
            await context.SaveChangesAsync();

            Console.WriteLine("Entry has been saved!");
        }

        public static async Task GetEntryByID(DiaryDbContext context)
        {
            Console.Write("\nEnter the ID you intend to search for: ");
            int idObtained = int.Parse(Console.ReadLine());

            var entryobtained = await context.DiaryEntries.FindAsync(idObtained);

            if (entryobtained == null)
            {
                Console.WriteLine("Invalid Input ID");
            }
            else
            {
                Console.WriteLine($"ID: {entryobtained.Id} - \nTitle: {entryobtained.Title} - \nBody: {entryobtained.Body}");
            }
            
        }
        public static async Task GetAllEntries(DiaryDbContext context)
        {
            Console.WriteLine("\nYour Diary Entries: ");

            var entries = await context.DiaryEntries
                .Include(e => e.Tags)
                .AsNoTracking()
                .OrderByDescending(e => e.CreatedDate)
                .ToListAsync();

            if(entries.Count == 0)
            {
                Console.WriteLine("Your Diary is empty!!!");
                return;
            }

            foreach (var entry in entries) 
            {
                Console.WriteLine($"\n{entry.Id} - {entry.Title} - {entry.CreatedDate}");
                Console.WriteLine($"Body: {entry.Body}");

                if (entry.Tags.Any())
                {
                    var tagnames = entry.Tags.Select(e => e.Name);  
                    Console.WriteLine($"Tags: {string.Join(", ", tagnames)}");
                }

                Console.WriteLine("---------------------------");

            }
        }

        public static async Task SearchEntries(DiaryDbContext context) 
        {
            Console.Write("Enter a keyword to search for: ");

            string keyword = Console.ReadLine();

            string termedKeyword = $"%{keyword}%";

            var results = await context.DiaryEntries
                .Include(e => e.Tags)
                .AsNoTracking()
                .Where(e => EF.Functions.Like(e.Title, termedKeyword) || EF.Functions.Like(e.Body, termedKeyword))
                .ToListAsync();

            Console.WriteLine($"\nFound {results.Count} entries matcing '{keyword}':");

            foreach (var entry in results)
            {
                Console.WriteLine($"- [{entry.Id}] {entry.Title}");
            }
        
        }

        public static async Task UpdateEntry(DiaryDbContext context)
        {
            Console.Write("\nEnter the ID of the entry to update: ");
            int idInserted = int.Parse(Console.ReadLine());

            var entryToUpdate = await context.DiaryEntries.FindAsync(idInserted);

            if (entryToUpdate == null)
            {
                Console.WriteLine("Entry not found!");
                return;
            }

            Console.WriteLine($"Current Title: {entryToUpdate.Title}");
            Console.Write("Enter the new Title: (leave blank to keep its current one): ");

            string newTitle = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newTitle))
            {
                entryToUpdate.Title = newTitle;
            }

            //update the modified date
            entryToUpdate.ModifiedDate = DateTime.Now;

            //Save changes to the DB
            Console.WriteLine("Updating entry...");
            await context.SaveChangesAsync();
            Console.WriteLine("Update was successful");

        }

        public static async Task DeleteEntry(DiaryDbContext context)
        {
            Console.Write("Enter the ID of the entry you want to delete: ");
            int idInput = int.Parse(Console.ReadLine());

            var entryToDelete = await context.DiaryEntries.FindAsync(idInput);

            if (entryToDelete == null)
            {
                Console.WriteLine("Entry wasn't found!");
                return;
            }

            Console.WriteLine($"Deleting '{entryToDelete.Title}'...");

            //stage the entry for deletion
            context.DiaryEntries.Remove(entryToDelete);

            //Commit the deletion to the DB
            await context.SaveChangesAsync();

            Console.WriteLine("Entry deleted sucessfully.");
        }
    }
}
