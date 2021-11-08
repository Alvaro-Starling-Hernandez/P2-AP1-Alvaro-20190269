using Microsoft.EntityFrameworkCore;
using P2_AP1_Alvaro_20190269.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Alvaro_20190269.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<TiposDeTareas> TiposDeTareas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA/DataBaseProyectos.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposDeTareas>().HasData(new TiposDeTareas { 
                TipoDeTareaId = 1,
                Nombre = "Analisis",
                TiempoAcomulado = 0
            });

            modelBuilder.Entity<TiposDeTareas>().HasData(new TiposDeTareas
            {
                TipoDeTareaId = 2,
                Nombre = "Diseno",
                TiempoAcomulado = 0
            });

            modelBuilder.Entity<TiposDeTareas>().HasData(new TiposDeTareas
            {
                TipoDeTareaId = 3,
                Nombre = "Programacion",
                TiempoAcomulado = 0
            });

            modelBuilder.Entity<TiposDeTareas>().HasData(new TiposDeTareas
            {
                TipoDeTareaId = 4,
                Nombre = "Prueba",
                TiempoAcomulado = 0
            });
        }

    }
}
