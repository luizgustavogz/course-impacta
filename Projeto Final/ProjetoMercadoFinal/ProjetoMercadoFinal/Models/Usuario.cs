using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoMercadoFinal.Models
{
    [Table("TblUsuario")]
    public class Usuario
    {
        [Key]
        [Column("ID_Usuario")]
        public int Id { get; set; }

        [Column("NM_Usuario", TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }

        [Column("CD_Email", TypeName = "VARCHAR(60)")]
        public string Email { get; set; }

        [JsonIgnore]
        [Column("CD_Senha", TypeName = "VARCHAR(100)")]
        public string Senha { get; set; }

        [Column("CD_Perfil_", TypeName = "VARCHAR(100)")]
        public string Perfil { get; set; }

        [JsonIgnore]
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
