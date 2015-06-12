using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace McubeAPI.Models
{
    public class Update
    {
        [Required]
        [MaxLength(140)]
        public string data { get; set; }

        public DateTime Date { get; set; }
    }
}