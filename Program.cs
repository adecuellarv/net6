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
                bool salir = false;

                Console.WriteLine("id_movie - will update the favorites status");
                Console.WriteLine("all - Get all list");
                Console.WriteLine("fav - Get only the favorites");
                Console.WriteLine("exit - Close the app");
                Program p = new Program();
                p.showAllList();
                while (!salir)
                {
                    var writed = Console.ReadLine();
                    switch (writed)
                    {
                        case "all":
                            p.showAllList();
                            break;
                        case "fav":
                            p.getFavorites();
                            break;
                        case "exit":
                            salir = true;
                            break;
                        default:
                            int id = Convert.ToInt32(writed);
                            p.addToFavorites(id);
                            break;
                    }
                }
            }
        }

        public void showAllList()
        {
            using (var context = new BlogDataContext())
            {
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
            }
        }

        public void addToFavorites(int id)
        {
            using (var context = new BlogDataContext())
            {
                var itemselected = context.List.Find(id);
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

        public void getFavorites()
        {
            using (var context = new BlogDataContext())
            {
                var favorites = context.List.Where(d => d.favorite == true);

                foreach (var item in favorites)
                {
                    var itemtoshow = item.id + " " + item.name;
                    if (item.favorite)
                    {
                        itemtoshow = itemtoshow + " *";
                    }
                    Console.WriteLine(itemtoshow);
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