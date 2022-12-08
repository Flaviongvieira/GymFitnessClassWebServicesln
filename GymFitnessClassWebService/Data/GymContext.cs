﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymModels;

namespace GymFitnessClassWebService.Data
{
    public class GymContext : DbContext
    {
        public GymContext (DbContextOptions<GymContext> options)
            : base(options)
        {
        }

        public DbSet<GymModels.FitnessInstructor> FitnessInstructor { get; set; } = default!;

        public DbSet<GymModels.FitnessStudio> FitnessStudio { get; set; }

        public DbSet<GymModels.FitnessClassSchedule> FitnessClassSchedule { get; set; }
    }
}
