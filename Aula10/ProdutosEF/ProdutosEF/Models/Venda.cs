using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosEF.Models
{

    [Table("tblVenda")]
    class Venda
    {
        [Key]
        [Column("Id_Venda")]
        public int Id { get; set; }

        [Column("Id_Usuario")]
        public int IdUsuario { get; set; }

        [Column("Vlr_Total")]
        public decimal Total { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<VendaItem> Itens { get; set; }
    }
}
