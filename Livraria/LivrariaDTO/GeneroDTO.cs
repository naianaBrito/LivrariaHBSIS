namespace LivrariaDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using System.Data.Entity.Spatial;

    [Table("Genero")]
    public partial class GeneroDTO
    {
        [Key]
        public int IDGenero { get; set; }

        [Required(ErrorMessage ="Campo Descri��o � obrigat�rio")]
        [Display(Name ="Descri��o")]
        [StringLength(200)]
        public string DescricaoGenero { get; set; }
    }
}
