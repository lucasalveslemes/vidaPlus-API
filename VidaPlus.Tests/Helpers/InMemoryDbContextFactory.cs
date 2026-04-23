using Microsoft.EntityFrameworkCore;
using VidaPlus.Data;

namespace VidaPlus.Tests.Helpers
{
    public static class InMemoryDbContextFactory
    {
        public static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
