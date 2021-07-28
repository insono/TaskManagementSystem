using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("TasksHistory")]
    public class TasksHistory
    {
        // [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [Key]
        public int TaskId { get; set; }

        public int UserId { get; set; }

        [MaxLength(50)]
        public string? Title { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? Completed { get; set; }

        [MaxLength(500)]
        public string? Remarks { get; set; }
    }
}
