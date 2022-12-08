using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymModels;

namespace GymRepository
{
    public class GymContext : DbContext
    {
        /*public GymContext (DbContextOptions<GymContext> options)
            : base(options)
        {
        }*/

        // Configuration (copied over from prev projs)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //define connection string
            string connectionstr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=GymFitnessClassWebService.Data;Integrated Security=SSPI;AttachDBFilename=d:\db\GymFitnessClassWebService.Data.mdf";

            //We want to use sql server (with out defined connection string)
            optionsBuilder.UseSqlServer(connectionstr);
            //optionsBuilder.UseInMemoryDatabase("someDB");
        }

        public DbSet<GymModels.FitnessInstructor> FitnessInstructor { get; set; } = default!;

        public DbSet<GymModels.FitnessStudio> FitnessStudio { get; set; } = default!;

        public DbSet<GymModels.FitnessClassSchedule> FitnessClassSchedule { get; set; } = default!;
    }
}
