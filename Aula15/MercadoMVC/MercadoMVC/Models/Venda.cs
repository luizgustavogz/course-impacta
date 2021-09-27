using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoMVC.Models
{
    [Table("tblVenda")]
    public class Venda
    {
        [Key]
        [Column("Id_Venda")]
        public int Id { get; set; }

        [Column("Id_Usuario")]
        public int IdUsuario { get; set; }

        [Column("Vlr_Total", TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<VendaItem> Itens { get; set; }
    }
}
