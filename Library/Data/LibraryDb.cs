using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;
using Library.Controllers;

namespace Library.Data
{
    public class LibraryDb : DbContext
    {
        public DbSet<Book> Books { get; set; }


        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=LibraryDb;Integrated Security=True;";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}

