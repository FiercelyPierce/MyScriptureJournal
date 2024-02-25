using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;

namespace MyScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                if (context == null || context.Scripture == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any scripture.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "D&C",
                        Chapter = 1,
                        Verse = 38,
                        Note = "This is great",
                        Date = DateTime.Now
                    },

                    new Scripture
                    {
                        Book = "1 Nephi",
                        Chapter = 3,
                        Verse = 7,
                        Note = "My personal favorite",
                        Date = DateTime.Now
                    },

                    new Scripture
                    {
                        Book = "2 Nephi",
                        Chapter = 2,
                        Verse = 25,
                        Note = "This is a powerful message",
                        Date = DateTime.Now
                    },

                    new Scripture
                    {
                        Book = "James",
                        Chapter = 1,
                        Verse = 5,
                        Note = "Joseph Smith's special",
                        Date = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
