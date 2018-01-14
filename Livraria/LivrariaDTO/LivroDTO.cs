namespace LivrariaDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Livro")]
    public partial class LivroDTO
    {
        [Key]
        public int IDLivro { get; set; }

        [Required]
        [Display(Name = "T�tulo")]
        [StringLength(250)]
        public string Titulo { get; set; }

        [Display(Name = "Editora")]
        public int IDEditora { get; set; }

        [Display(Name = "Edi��o")]
        [Required(ErrorMessage = "Campo Edi��o � obrigat�rio")]
        [StringLength(20)]
        public string Edicao { get; set; }

        [Required]
        [Display(Name = "Ano de Publica��o")]       
        public Nullable<int> AnoPublicacao { get; set; }

        [Required]        
        public virtual Nullable<int> Quantidade { get; set; }
       
        [Required(ErrorMessage = "Campo ISBN � obrigat�rio")]
        [StringLength(20)]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Campo Pre�o � obrigat�rio")]
        [Display(Name = "Pre�o")]
        public Nullable<decimal> Preco { get; set; }

        [Display(Name = "Autor")]
        public int IDAutor { get; set; }

        [Display(Name = "G�nero")]
        public int IDGenero { get; set; }
        public virtual AutorDTO Autor { get; set; }

        public virtual EditoraDTO Editora { get; set; }

        [Display(Name = "G�nero")]
        public virtual GeneroDTO Genero { get; set; }

        [NotMapped]
        public IList<EditoraDTO> Editoras { get; set; }

        [NotMapped]
        public IList<AutorDTO> Autores { get; set; }

        [NotMapped]
        public IList<GeneroDTO> Generos { get; set; }

    }
}
