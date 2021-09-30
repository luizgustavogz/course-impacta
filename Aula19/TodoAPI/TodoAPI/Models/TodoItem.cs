using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    [Table("TblTodoItem")]
    public class TodoItem
    {
        [Key]
        [Column("Id_TodoItem")]
        public int Id { get; set; }

        [Column("Nm_TodoItem", TypeName ="VARCHAR(100)")]
        public string Name { get; set; }

        [Column("Is_Complete")]
        public bool IsComplete { get; set; }
    }
}
