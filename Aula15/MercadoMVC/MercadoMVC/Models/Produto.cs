using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoMVC.Models
{
    [Table("tblProduto")]
    public class Produto
    {
        [Key]
        [Column("Id_Produto")]
        public int Id { get; set; }

        [Column("Nm_Produto", TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }

        [Column("Vlr_Produto", TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        [Column("Dt_Validade")]
        [DataType(DataType.Date)]
        public DateTime Validade { get; set; }

        [NotMapped]
        public string ValorAExibir { get; set; }

        public virtual ICollection<VendaItem> VendasDoProduto { get; set; }
    }
}
