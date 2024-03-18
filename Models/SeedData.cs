using Microsoft.EntityFrameworkCore;
using MVC_ICE_One.Data;

namespace MVC_ICE_One.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVC_ICE_OneContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MVC_ICE_OneContext>>()))
            {
                // Look for any movies.
                if (context.WorkItemModel.Any())
                {
                    return;   // DB has been seeded
                }
                context.WorkItemModel.AddRange(
                    new WorkItemModel
                    {
                        WorkTitle = "Decorative Kitchen Table",
                        CreatorName = "John Doe",
                        UploadDate = DateTime.Parse("1989-2-12"),
                        Price = 7.99M
                    },
                    new WorkItemModel
                    {
                        WorkTitle = "Decorative Vase",
                        CreatorName = "John Doe",
                        UploadDate = DateTime.Parse("1979-10-11"),
                        Price = 8.99M
                    },
                    new WorkItemModel
                    {
                        WorkTitle = "Decorative Picture Frame",
                        CreatorName = "John Doe",
                        UploadDate = DateTime.Parse("1999-10-10"),
                        Price = 9.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
