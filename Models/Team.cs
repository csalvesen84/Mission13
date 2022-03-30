using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
        public int CaptainId { get; set; }
    }
}
