using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MisGastos.Prism.Enums;

namespace MisGastos.Prism.Services.Firebase
{
	public interface IFirebaseDataBaseService
	{
		Task<bool> AddItemAsync<T>(T item, FirebaseNodeType nodeType) where T: class;

		Task<IEnumerable<T>> GetItemsAsync<T>(FirebaseNodeType nodeType);

    }
}

