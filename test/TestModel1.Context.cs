﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TestEntities : DbContext
    {

        private static TestEntities _context;
        public TestEntities()
            : base("name=TestEntities")
        {
        }

        public static TestEntities GetContext()
        {
            if (_context == null)
                _context = new TestEntities();
            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<ВидыПродуктов> ВидыПродуктов { get; set; }
        public virtual DbSet<Должности> Должности { get; set; }
        public virtual DbSet<ДоставкаТовараВМагазин> ДоставкаТовараВМагазин { get; set; }
        public virtual DbSet<КомпанииДоставщики> КомпанииДоставщики { get; set; }
        public virtual DbSet<КомпанииПоставщики> КомпанииПоставщики { get; set; }
        public virtual DbSet<Пользователи> Пользователи { get; set; }
        public virtual DbSet<ПоставкиНаСклад> ПоставкиНаСклад { get; set; }
        public virtual DbSet<ТоварыНаСкладе> ТоварыНаСкладе { get; set; }
    }
}