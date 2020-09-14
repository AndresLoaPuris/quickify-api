using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Team
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public string role { get; set; }
        public int proyect_id { get; set; }
    }
}
