﻿using Microsoft.EntityFrameworkCore;
using WEB_API.Model;

namespace WEB_API.Infraestrutura
{
    
    public class ConnectionContext : DbContext
    {
        
        public DbSet<Employee> Employees { get; set; }


        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=PrimeiraAPI;" +
                "User Id=postgres;" +
                "Password=vaval0645;");
    }
}
