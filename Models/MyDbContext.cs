using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Npgsql;

namespace SubIn.Models
{

        public class MyDbContext : DbContext
        {
            public MyDbContext() : base(GetConnection(), true)
            {
            }

            private static NpgsqlConnection GetConnection()
            {
                var connString = "Host=localhost;Username=postgres;Password=bd;Database=subin";
                return new NpgsqlConnection(connString);
            }
            public DbSet<Usuario> Usuario { get; set; }
        }

        
    


    
  
}