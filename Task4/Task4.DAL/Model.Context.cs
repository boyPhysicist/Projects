﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Task4.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Task4.DM;
    
    public partial class SalesDBEntities : DbContext
    {
        public SalesDBEntities()
            : base("name=SalesDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClientSet> ClientSets { get; set; }
        public virtual DbSet<ManagerSet> ManagerSets { get; set; }
        public virtual DbSet<ProductSet> ProductSets { get; set; }
        public virtual DbSet<SaleSet> SaleSets { get; set; }
    }
}
