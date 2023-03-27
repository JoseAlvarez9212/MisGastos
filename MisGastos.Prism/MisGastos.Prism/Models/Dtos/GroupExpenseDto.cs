using System;
using System.Collections.Generic;

namespace MisGastos.Prism.Models.Dtos
{
	public class GroupExpenseDto
	{
        public string id { get; set; }
        public string name { get; set; }
        public List<string> users { get; set; }
    }
}

