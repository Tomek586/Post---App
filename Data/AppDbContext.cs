﻿using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        private string DbPath { get; set; }
        public DbSet<PostEntity> Posts{ get; set; }
        public DbSet<TopicEntity> Topics { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "posts.db");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostEntity>()
                .HasOne(e => e.Topic)
                .WithMany(o => o.Posts)
                .HasForeignKey(e => e.TopicId);

            // Remove the duplicate call to base.OnModelCreating(modelBuilder)
            // base.OnModelCreating(modelBuilder);

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();

            var user = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "tomek",
                Email = "tomek@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "TOMEK@GMAIL.COM",
                NormalizedUserName = "TOMEK"
            };

            // Hash the password
            user.PasswordHash = ph.HashPassword(user, "Tomek123!");

            modelBuilder.Entity<IdentityUser>()
                .HasData(user);

            var user2 = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "jacek",
                Email = "jacek@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "JACEK@GMAIL.COM",
                NormalizedUserName = "JACEK"
            };

            // Hash the password for user2
            user2.PasswordHash = ph.HashPassword(user2, "Jacek123!");

            modelBuilder.Entity<IdentityUser>()
                .HasData(user2);

            // Adding the administrator role
            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            adminRole.ConcurrencyStamp = adminRole.Id;
            modelBuilder.Entity<IdentityRole>()
                .HasData(adminRole);

            // Adding the relationship between user2 and the admin role
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>()
                {
                    RoleId = adminRole.Id,
                    UserId = user2.Id
                });



            modelBuilder.Entity<TopicEntity>().HasData(
                 new TopicEntity()
                 {
                     Id = 1,
                     Name = "Sport",
                     Description = "piłka nożna",


                 },
                  new TopicEntity()
                  {
                      Id = 2,
                      Name = "Bizes",
                      Description = "giełda ...",


                  },
                 new TopicEntity()
                 {
                     Id = 3,
                     Name = "Wiadomości",
                     Description = "wiadomości z całego świata",


                 }
             ); ;
            modelBuilder.Entity<PostEntity>().HasData(
               new PostEntity()
               {
                   PostId = 1,
                   Content = "Sensacyjne zwycięstwo Liverpoolu 4-2 nad rywalem!",
                   Author = "Tom",
                   Tags = "piłka nożna, Premier League, zwycięstwo, emocje",
                   Comment = "komentarz",
                   TopicId = 1,

               },
               new PostEntity()
               {
                   PostId = 2,
                   Content = "Rewolucje w branży technologicznej kształtują przyszłość biznesu.",
                   Author = "janusz",
                   Tags = "technologia, innowacje, biznes",
                   Comment = "komentarz2",
                   TopicId = 2,
               }
           );
    
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

    }
}