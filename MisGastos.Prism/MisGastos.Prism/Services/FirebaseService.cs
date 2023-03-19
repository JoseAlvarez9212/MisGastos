using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using MisGastos.Prism.Models.Dtos;
using Xamarin.Essentials;
using System.Linq;

namespace MisGastos.Prism.Services
{
	public class FirebaseService
	{
		FirebaseClient firebaseClient;

		public FirebaseService()
		{
			firebaseClient = new FirebaseClient("https://misgastos-d5408-default-rtdb.firebaseio.com/");
		}
    }
}

