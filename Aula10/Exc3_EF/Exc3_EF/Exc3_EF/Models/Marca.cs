using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exc3_EF.Models
{
    [Table("lcunha_tblMarca")]
    class Marca
    {
        [Key]
        [Column("Id_Marca")]
        public int Id { get; set; }

        [Column("Id_Produto_Marca")]
        public int IdProduto { get; set; }

        [Column("Nome_Marca", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [ForeignKey("IdProduto")]
        public virtual Produto Produto { get; set; }
    }
}
