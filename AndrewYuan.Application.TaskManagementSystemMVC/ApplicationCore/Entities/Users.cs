using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Users")]
    public class Users
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(10)]
        [Required]
        public string Password { get; set; }

        [MaxLength(50)]
        public string? Fullname { get; set; }

        [MaxLength(50)]
        public string? Mobileno { get; set; }

        // Navigation Properties
        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<TasksHistory> TasksHistories { get; set; }
    }
}
