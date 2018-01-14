namespace LivrariaDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;    

    [Table("Editora")]
    public partial class EditoraDTO
    {
        [Key]
        public int IDEditora { get; set; }

        [Required(ErrorMessage = "Campo Nome Editora é obrigatório")]
        [StringLength(250)]
        [Display(Name = "Nome Editora")]
        public string NomeEditora { get; set; }
    }
}
