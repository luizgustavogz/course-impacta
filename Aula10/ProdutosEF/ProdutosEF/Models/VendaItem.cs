using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEF.Models
{

    [Table("TblVenda_Item")]
    class VendaItem
    {
        [Key]
        [Column("Id_Venda_Item")]
        public int Id { get; set; }

        [Column("Id_Venda")]
        public int IdVenda { get; set; }

        [Column("Id_Produto")]
        public int IdProduto { get; set; }

        [Column("Qtd_Item")]
        public int Quantidade { get; set; }

        [ForeignKey("IdVenda")]
        public virtual Venda Venda { get; set; }

        [ForeignKey("IdProduto")]
        public virtual Produto Produto { get; set; }
    }
}
