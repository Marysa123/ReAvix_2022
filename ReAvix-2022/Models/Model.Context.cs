﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReAvix_2022.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_ReAvixEntities : DbContext
    {
        public db_ReAvixEntities()
            : base("name=db_ReAvixEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Достижения> Достижения { get; set; }
        public virtual DbSet<Заметки> Заметки { get; set; }
        public virtual DbSet<Категории_Навыка> Категории_Навыка { get; set; }
        public virtual DbSet<Кружки> Кружки { get; set; }
        public virtual DbSet<Навыки> Навыки { get; set; }
        public virtual DbSet<Оценки> Оценки { get; set; }
        public virtual DbSet<Оценки_2> Оценки_2 { get; set; }
        public virtual DbSet<Предметы> Предметы { get; set; }
        public virtual DbSet<Предметы_Преподавателя> Предметы_Преподавателя { get; set; }
        public virtual DbSet<Преподаватели> Преподаватели { get; set; }
        public virtual DbSet<Специальности> Специальности { get; set; }
        public virtual DbSet<Студенты> Студенты { get; set; }
        public virtual DbSet<Группа> Группа { get; set; }
        public virtual DbSet<Пропуски> Пропуски { get; set; }
    }
}
