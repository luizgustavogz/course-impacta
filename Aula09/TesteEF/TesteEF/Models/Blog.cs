using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteEF.Models
{
    [Table("tblBlog")]
    class Blog
    {
        [Key]
        [Column("Id_Blog")]
        public int Id { get; set; }

        [Column("Id_User_Blog")]
        public int IdUser { get; set; }

        [Column("Desc_Blog", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Column("DT_Created")]
        public DateTime CreatedTimestamp { get; set; }

        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}
