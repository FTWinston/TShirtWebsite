﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TShirts.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Design> Designs { get; set; }
        public virtual DbSet<Font> Fonts { get; set; }
        public virtual DbSet<GarmentType> GarmentTypes { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Range> Ranges { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Text> Texts { get; set; }
        public virtual DbSet<VinylColor> VinylColors { get; set; }
    }
}
