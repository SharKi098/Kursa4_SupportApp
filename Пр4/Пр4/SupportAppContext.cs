using System;
using System.Data.Entity;
using Пр4.Models;

namespace Пр4
{
    public class SupportAppDbContext : DbContext
    {
        public SupportAppDbContext() : base("name=DBConnection")
        {
            Database.SetInitializer<SupportAppDbContext>(null);
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<UsersModel> Users { get; set; }
        public DbSet<CategoriesModel> Categories { get; set; }
        public DbSet<TicketsModel> Tickets { get; set; }
        public DbSet<AssetsModel> Assets { get; set; }
        public DbSet<KnowledgeBaseModel> KnowledgeBases { get; set; }
        public DbSet<NotificationsModel> Notifications { get; set; }
        public DbSet<CommentsModel> Comments { get; set; }
        public DbSet<RoleModel> Roles { get; set; } // Исправлено имя для соответствия соглашению

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // User -> Role (1:M)
            modelBuilder.Entity<UsersModel>()
                .HasRequired(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .WillCascadeOnDelete(false);

            // User -> Comments (1:M)
            modelBuilder.Entity<UsersModel>()
                .HasMany(u => u.Comments)
                .WithRequired(c => c.User)
                .HasForeignKey(c => c.UserId)
                .WillCascadeOnDelete(false);

            // User -> Notifications (1:M)
            modelBuilder.Entity<UsersModel>()
                .HasMany(u => u.Notifications)
                .WithRequired(n => n.User)
                .HasForeignKey(n => n.UserId)
                .WillCascadeOnDelete(false);

            // User -> Assets (1:M)
            modelBuilder.Entity<UsersModel>()
                .HasMany(u => u.Assets)
                .WithOptional(a => a.AssignedUser)
                .HasForeignKey(a => a.AssetsTo)
                .WillCascadeOnDelete(false);

            // Category -> Tickets (1:M)
            modelBuilder.Entity<CategoriesModel>()
                .HasMany(c => c.Tickets)
                .WithRequired(t => t.Category)
                .HasForeignKey(t => t.CategoryId)
                .WillCascadeOnDelete(false);

            // Category -> KnowledgeBase (1:M)
            modelBuilder.Entity<CategoriesModel>()
                .HasMany(c => c.KnowledgeBases)
                .WithRequired(k => k.Category)
                .HasForeignKey(k => k.CategoryId)
                .WillCascadeOnDelete(false);

            // Ticket -> Comments (1:M)
            modelBuilder.Entity<TicketsModel>()
                .HasMany(t => t.Comments)
                .WithRequired(c => c.Ticket)
                .HasForeignKey(c => c.TicketId)
                .WillCascadeOnDelete(true);

            // User -> Tickets (CreatedBy) 
            modelBuilder.Entity<TicketsModel>()
                .HasRequired(t => t.CreatedByUser)
                .WithMany(u => u.CreatedTickets)
                .HasForeignKey(t => t.CreatedBy)
                .WillCascadeOnDelete(false);

            // User -> Tickets (AssignedTo)
            modelBuilder.Entity<TicketsModel>()
                .HasOptional(t => t.AssignedToUser)
                .WithMany(u => u.AssignedTickets)
                .HasForeignKey(t => t.AssignedTo)
                .WillCascadeOnDelete(false);

            // KnowledgeBase -> User
            modelBuilder.Entity<KnowledgeBaseModel>()
                .HasRequired(k => k.CreatedByUser)
                .WithMany(u => u.KnowledgeBases)
                .HasForeignKey(k => k.CreatedBy)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}