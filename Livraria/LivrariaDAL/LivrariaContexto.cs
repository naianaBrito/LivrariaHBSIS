namespace LivrariaDAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using LivrariaDTO;

    public partial class LivrariaContexto : DbContext
    {
        public LivrariaContexto()
            : base("name=LivrariaModel")
        {
        }

        public virtual DbSet<AutorDTO> Autor { get; set; }
        public virtual DbSet<EditoraDTO> Editora { get; set; }      
        public virtual DbSet<GeneroDTO> Genero { get; set; }
        public virtual DbSet<LivroDTO> Livro { get; set; }
        public virtual DbSet<VendaDTO> Venda { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutorDTO>()
                .Property(e => e.NomeAutor)
                .IsUnicode(false);

            modelBuilder.Entity<EditoraDTO>()
                .Property(e => e.NomeEditora)
                .IsUnicode(false);

            modelBuilder.Entity<GeneroDTO>()
                .Property(e => e.DescricaoGenero)
                .IsUnicode(false);

            modelBuilder.Entity<LivroDTO>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<LivroDTO>()
                .Property(e => e.Edicao)
                .IsUnicode(false);
        }
    }
}
