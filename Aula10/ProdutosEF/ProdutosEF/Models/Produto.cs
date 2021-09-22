using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEF.Models
{
    [Table("tblProduto")]
    class Produto
    {
        [Key]
        [Column("Id_Produto")]
        public int Id { get; set; }

        [Column("Nm_Produto", TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }

        [Column("Vlr_Produto")]
        public decimal Valor { get; set; }
        
        [Column("Dt_Validade")]
        public DateTime Validade { get; set; }

        public virtual ICollection<VendaItem> ItensDoProdutoVendido { get; set; }
    }
}
