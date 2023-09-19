using CRUDApplication_Bihari.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDApplication_Bihari.Context
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options) { }
        public DbSet<Employee>Employees { get; set; }
    }
}
