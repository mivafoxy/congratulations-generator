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
        public virtual DbSet<Birthday_Cliche> Birthday_Cliche { get; set; }
        public virtual DbSet<Birthday_Picture> Birthday_Picture { get; set; }
        public virtual DbSet<Birthday_Poem> Birthday_Poem { get; set; }
        public virtual DbSet<New_Year_Cliche> New_Year_Cliche { get; set; }
        public virtual DbSet<New_Year_Picture> New_Year_Picture { get; set; }
        public virtual DbSet<New_Year_Poem> New_Year_Poem { get; set; }
    }
}
