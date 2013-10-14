using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog
                Console.WriteLine("Please enter blog name:");
                string blogName = Console.ReadLine();

                Blog blog = new Blog();
                blog.Name = blogName;
                blog.DateCreated = DateTime.Now;
                db.Blogs.Add(blog);
                db.SaveChanges();

                // List all available blogs in the DB
                Console.WriteLine("All blogs in the DB:");
                foreach (var item in db.Blogs.ToList())
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            }
        }
    }

    public class Blog
    {
        [Key]
        public int IDBlog { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        [Key]
        public int IDPost { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int IDBlog { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}