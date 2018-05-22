namespace GetFreshBooks.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Mybooks : DbContext
    {
        public Mybooks()
            : base("name=Mybooks")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Author)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.MessageBody)
                .IsUnicode(false);
        }
    }
}
