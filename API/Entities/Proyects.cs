using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
	public class Proyects
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public bool isDelete { get; set; }
    }
}
