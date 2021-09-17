using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteEF.Models
{
    [Table("tblUser")]
    class User
    {
        [Key]
        [Column("Id_User")]
        public int Id { get; set; }

        [Column("Nome_User", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
