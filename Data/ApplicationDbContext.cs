using Filmly.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filmly.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser_Favourites>().HasKey(gm => new { gm.ApplicationUserID, gm.TitleId });
            modelBuilder.Entity<ApplicationUser_Favourites>().HasOne(user => user.ApplicationUser).WithMany(userFavourite=>userFavourite.ApplicationUser_Favourites).HasForeignKey(userId=>userId.ApplicationUserID);
            modelBuilder.Entity<ApplicationUser_Favourites>().HasOne(user => user.Title).WithMany(userFavourite => userFavourite.ApplicationUser_Favourites).HasForeignKey(userId => userId.TitleId);

            modelBuilder.Entity<ApplicationUser_ToWatch>().HasKey(gm => new { gm.ApplicationUserID, gm.TitleId });
            modelBuilder.Entity<ApplicationUser_ToWatch>().HasOne(user => user.ApplicationUser).WithMany(userFavourite => userFavourite.ApplicationUser_WatchList).HasForeignKey(userId => userId.ApplicationUserID);
            modelBuilder.Entity<ApplicationUser_ToWatch>().HasOne(user => user.Title).WithMany(userFavourite => userFavourite.ApplicationUser_WatchList).HasForeignKey(userId => userId.TitleId);

            modelBuilder.Entity<Similars>().HasKey(gm => new { gm.TitleId, gm.SimilarId });
            modelBuilder.Entity<Similars>().HasOne(user => user.Title).WithMany(userFavourite => userFavourite.Similar).HasForeignKey(userId => userId.TitleId);
            modelBuilder.Entity<Similars>().HasOne(user => user.Similar).WithMany(userFavourite => userFavourite.Similar).HasForeignKey(userId => userId.SimilarId);


            modelBuilder.Entity<Titles_Actors>().HasKey(gm => new { gm.TitleId, gm.ActorId });
            modelBuilder.Entity<Titles_Actors>().HasOne(user => user.Title).WithMany(userFavourite => userFavourite.Cast).HasForeignKey(userId => userId.TitleId);
            modelBuilder.Entity<Titles_Actors>().HasOne(user => user.Actor).WithMany(userFavourite => userFavourite.CastMovies).HasForeignKey(userId => userId.ActorId);

            //modelBuilder.Entity<Discussion>().HasMany(c => c.Comments).WithOne(e => e.Discussion);

            //modelBuilder.Entity<DiscussionComment>().HasMany(c => c.ChildrenComents).WithOne(e => e.ParentComment).OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ApplicationUser>().HasMany(c => c.UserComments).WithOne(e => e.Creator).OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<ApplicationUser>().HasMany(c => c.ArticlesWritten).WithOne(e => e.Writer).OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Titles> Titles { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<TitleSimplified> TitlesSimplified { get; set; }
        public DbSet<ApplicationUser_Favourites> User_Favourites { get; set; }
        public DbSet<ApplicationUser_ToWatch> User_WatchList { get; set; }
        public DbSet<Titles_Actors> Titles_Actors { get; set; }
        public DbSet<Similars> Similars { get; set; }
        public DbSet<Images> Images { get; set; }
        //public DbSet<Feedback> Feedbacks { get; set; }
        //public DbSet<Discussion> Discussions { get; set; }
        //public DbSet<DiscussionComment> DiscussionComments { get; set; }
        //public DbSet<Article> Articles { get; set; }
    }
}
