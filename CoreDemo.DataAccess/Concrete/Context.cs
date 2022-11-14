﻿using CoreDemo.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.DataAccess.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; database=CoreBlogDb; integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message2>().HasOne(x => x.SenderUser).WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderID).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Message2>().HasOne(x => x.RecieverUser).WithMany(y => y.WriterReciever)
                .HasForeignKey(z => z.RecieverID).OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRating> BlogRatings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
