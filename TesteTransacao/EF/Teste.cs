namespace EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Teste")]
    public partial class Teste
    {
        [Key]
        public int Id_Teste { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public int? Idade { get; set; }
    }
}
