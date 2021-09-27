using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoMVC.Models
{
    [Table("tblUsuario")]
    public class Usuario
    {
        [Key]
        [Column("Id_Usuario")]
        public int Id { get; set; }

        [Column("Nm_Usuario", TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
