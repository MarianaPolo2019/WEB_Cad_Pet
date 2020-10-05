using Cad_Pet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Cad_Pet.Context
{
    public class Contexto : DbContext
    {
        public DbSet<PetModel> Pets { get; set; }
        public DbSet<DonoModel> Donos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}