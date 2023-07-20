using System;
using Microsoft.EntityFrameworkCore;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogDataContext())
            {
                Console.WriteLine("Escribe el id que quieres agregar o eliminar de favoritos");
                var list = context.List;
                foreach (var item in list)
                {
                    var itemtoshow = item.id + " " + item.name;
                    if (item.favorite)
                    {
                        itemtoshow = itemtoshow + " *";
                    }
                    Console.WriteLine(itemtoshow);
                }

                int idwrited = Convert.ToInt32(Console.ReadLine());

                var itemselected = context.List.Find(idwrited);
                if (itemselected != null)
                {
                    if (itemselected.favorite)
                    {
                        itemselected.favorite = false;
                    }
                    else
                    {
                        itemselected.favorite = true;
                    }
                    context.SaveChanges();
                }
            }
        }

        public class BlogDataContext : DbContext
        {
            //162.241.203.237
            //adeevco2_databese_sl
            //adeevco2_user_sl
            //$cWmt_yf+olm
            //This.ispw1
            //static readonly string connectionString = "Server=162.241.203.241; Port=3306; Uid=adeevco2_user_sl; Pwd=This.ispw1; Database=adeevco2_databese_sl";
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