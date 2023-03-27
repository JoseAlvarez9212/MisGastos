using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MisGastos.Prism.Models.Dtos
{
	public class UserDto
	{
        public string email { get; set; }

        public string name { get; set; }

        public string last_name { get; set; }

        public List<ExpenseDto> expenses { get; set; }
    }
}

