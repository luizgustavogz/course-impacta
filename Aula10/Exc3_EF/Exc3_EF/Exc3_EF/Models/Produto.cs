using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exc3_EF.Models
{
    [Table("lcunha_tblProduto")]
    class Produto
    {
        [Key]
        [Column("Id_Produto")]
        public int Id { get; set; }

        [Column("Nome_Produto", TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }

        [Column("Valor_Produto", TypeName = "DECIMAL(10,2)")]
        public decimal Valor { get; set; }

        public virtual ICollection<Marca> Marcas { get; set; }
    }
}
