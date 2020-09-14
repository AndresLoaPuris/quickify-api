using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
	public class TeamDetail
	{
		public string nameProyect { get; set; }
		public Users[] users { get; set; }
	}
}
