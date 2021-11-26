using Microsoft.EntityFrameworkCore;

namespace TodoRazorPages.Models
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoDbContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<TodoDbContext>>()))
            {
                if (context == null || context.Activities == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }


                // Look for any movies.
                if (context.Activities.Any())
                {
                    return;   // DB has been seeded
                }

                context.Activities.AddRange(
                    new TodoActivity
                    {
                        Title = "Scrivere il capitolo sui database",
                        Date = new DateTime(2021, 11, 25),
                        Completed = false
                    },
                    new TodoActivity
                    {
                        Title = "Fare la spesa",
                        Date = new DateTime(2021, 10, 13),
                        Completed = true
                    },
                    new TodoActivity
                    {
                        Title = "Fare pace con Francy",
                        Date = new DateTime(2050, 09, 05),
                        Completed = false
                    });


                context.SaveChanges();
            }
        }
    }
}
