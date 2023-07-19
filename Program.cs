using System;
using Microsoft.EntityFrameworkCore;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World2!");

            using (var context = new BlogDataContext())
            {
                var add = new Items { name = "Metropolis", favorite = false };
                context.List.Add(add);
                context.SaveChanges();
            }

        }

        public class BlogDataContext : DbContext
        {
            static readonly string connectionString = "Server=localhost; Port=8889; Uid=root; Pwd=root; Database=show_list";

            public DbSet<Items> List { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        public class Items
        {
            public int id { get; set; }
            public string name { get; set; }
            public bool favorite { get; set; }
        }

    }
}