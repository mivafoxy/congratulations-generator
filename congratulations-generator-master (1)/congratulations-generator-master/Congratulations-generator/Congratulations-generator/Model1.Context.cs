﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Congratulations_generator
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class humanBaseEntities : DbContext
    {
        public humanBaseEntities()
            : base("name=humanBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Human> Human { get; set; }
        public virtual DbSet<Interests> Interests { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
    }
}
