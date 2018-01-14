namespace LivrariaDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Venda")]
    public partial class VendaDTO
    {
        [Key]
        public int IDVenda { get; set; }

        [Display(Name = "Título do Livro")]
        public int IDLivro { get; set; }

        [Required(ErrorMessage = "Campo Valor é obrigatório")]
        [Display(Name = "Valor")]
        public Nullable<decimal> Valor { get; set; }

        [Required(ErrorMessage = "Campo Data da Venda é obrigatório")]    
        [Display(Name = "Data da Venda")]
        public DateTime DataVenda { get; set; }

        public virtual LivroDTO Livro { get; set; }

        [NotMapped]
        public IList<LivroDTO> Livros { get; set; }
    }
}
