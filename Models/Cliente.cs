using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razorpages.Models
{
    public class Cliente
    {
              
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}

