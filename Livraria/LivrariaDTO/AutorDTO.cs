namespace LivrariaDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Autor")]
    public partial class AutorDTO
    {
        [Key]
        public int IDAutor { get; set; }

        [Required(ErrorMessage = "Campo Nome Autor é obrigatório")]
        [StringLength(250)]       
        [Display(Name = "Nome Autor")]
        public string NomeAutor { get; set; }
    }
}
