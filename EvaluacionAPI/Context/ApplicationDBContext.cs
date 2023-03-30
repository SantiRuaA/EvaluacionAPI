using Microsoft.EntityFrameworkCore;
using EvaluacionAPI.Entities;

namespace EvaluacionAPI.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {

        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>
            options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
    }
}
