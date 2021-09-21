using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEF.Models
{

    [Table("TB_VENDA_ITEM")]
    class VendaItem
    {
        [Key]
        [Column("ID_VENDA_ITEM")]
        public int Id { get; set; }

        [Column("ID_VENDA")]
        public int IdVenda { get; set; }

        [Column("ID_PRODUTO")]
        public int IdProduto { get; set; }

        [Column("QTD_ITEM")]
        public int Quantidade { get; set; }

        [ForeignKey("IdVenda")]
        public virtual Venda Venda { get; set; }

        [ForeignKey("IdProduto")]
        public virtual Produto Produto { get; set; }
    }
}
