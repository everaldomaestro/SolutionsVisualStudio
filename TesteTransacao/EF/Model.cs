namespace EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=testetransacao")
        {
        }

        public virtual DbSet<Teste> Teste { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teste>()
                .Property(e => e.Nome)
                .IsUnicode(false);
        }
    }
}
