using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MisGastos.Prism.Models.FirebaseDB
{
	public class TeamModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }

        [JsonProperty("users")]
        public  List<UserTeam> Users { get; set; }
	}

	public class UserTeam
	{
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }
	}
}

