using Microsoft.EntityFrameworkCore;
using UniversityBackend.Models.DataModels;

namespace UniversityBackend.DataAccess
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options)
        {

        }

        // toddo: add dbsets (tablas de base de datos)

        public DbSet<User>? Users { get; set; }


    }
}
