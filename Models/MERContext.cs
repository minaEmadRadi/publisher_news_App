namespace News.Models
{
    using System.Data.Entity;

    public partial class MERContext : DbContext
    {
        public MERContext()
            : base("name=MERContext")
        {
        }

        public virtual DbSet<catogery> catogeries { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<user> users { get; set; }
        //fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<catogery>()
                .HasMany(e => e.news)
                .WithOptional(e => e.catogery)
                .HasForeignKey(e => e.catogery_id);

            modelBuilder.Entity<user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.news)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);
        }
    }
}
