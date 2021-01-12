using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fuzzyMEME.Models
{
    public class MemeModel
    {
        public int Id { get; set; }
        [Required]
        public string MemeBase { get; set; }
        [Required]
        public string MemeExtra { get; set; }


        public MemeModel()
        {

        }
    }
}
