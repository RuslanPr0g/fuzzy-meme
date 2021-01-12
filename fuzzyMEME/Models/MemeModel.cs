using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fuzzyMEME.Models
{
    public class MemeModel
    {
        public int Id { get; set; }
        public string MemeBase { get; set; }
        public string MemeExtra { get; set; }


        public MemeModel()
        {

        }
    }
}
