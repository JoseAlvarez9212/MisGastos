using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using MisGastos.Prism.Enums;
using MisGastos.Prism.Helpers;
using MisGastos.Prism.Services.Resources.ConfigApp;

namespace MisGastos.Prism.Services.Firebase
{
	public class FirebaseDataBaseService : IFirebaseDataBaseService
    {
        private IEnvironmentService _environmentService;
        private readonly FirebaseClient _firebaseClient;

		public FirebaseDataBaseService(IEnvironmentService environmentService)
		{
            _environmentService = environmentService;
            _firebaseClient = new FirebaseClient(_environmentService.FirebaseProjectID);
        }

		public async Task<bool> AddItemAsync<T>(T item, FirebaseNodeType nodeType) where T: class
		{
			try
			{
				var node = $"{nodeType}".ToLowerSafely();
                var query = _firebaseClient.Child(node);
				await query.PostAsync(item);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public async Task<IEnumerable<T>> GetItemsAsync<T>(FirebaseNodeType nodeType)
		{
			try
			{
                var node = $"{nodeType}".ToLowerSafely();
                var query = _firebaseClient.Child(node);
				var firebaseObjects = await query.OnceAsync<T>();
				var result = firebaseObjects.Select(x=>x.Object);
				return result; 
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

