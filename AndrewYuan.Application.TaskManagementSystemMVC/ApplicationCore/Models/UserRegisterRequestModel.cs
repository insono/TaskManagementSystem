using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Models
{
    public class UserRegisterRequestModel
    {
        public int Id { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? Fullname { get; set; }
        public string? Mobileno { get; set; }
    }
}
