using CursoNetCore5.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoNetCore5.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<IncomeExpenses> IncomeExpenses { get; set; }
    }
}
