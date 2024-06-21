using Bloggie.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Metadata;
using System.Reflection;

namespace Bloggie.Data
{
    public class BloggieDbContext : DbContext
    {
        public BloggieDbContext(DbContextOptions options) : base(options)
        {
        }
        //what is DbContextOptions: This(DbContextOptions) is a configuration object provided by Entity Framework Core that holds 
        //settings and configuration options for a DbContext.It specifies how the DbContext should behave 
        // and how it should connect to the database.

        // what is base(options)
        // base(options)
        //Base Constructor Call: In the constructor of the BloggieDbContext class, base(options) is a call to the base class constructor,
        // which in this case is the constructor of the DbContext class.
        //Passing Configuration: By passing the options parameter to the base class constructor, you are ensuring that the DbContext class
        //receives the configuration options it needs to establish the connection to the database and configure its behavior.
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        //public DbSet<Domain model/Entityclass> The name of the table in sql server { get; set; }

        //what is DbSet 
        //DbSet<T>: This is a generic class provided by Entity Framework Core where T is the type of the entity.
        //In this case, T is BlogPost.

        //Each DbSet property in your DbContext class corresponds to a table in the database.

        //DbSet performs Database Table Mapping: DbSet<BlogPost> BlogPosts indicates that there is a table named BlogPosts in
        //the database that will be mapped to the BlogPost entity.

        //CRUD Operations: DbSet provides the functionality to perform Create, Read, Update, and Delete (CRUD) operations on
        //the entities within the set.
    }
}
