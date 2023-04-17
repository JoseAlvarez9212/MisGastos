using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MisGastos.Prism.Services.Firebase
{
    /// <summary>
    /// Contract for the Firebase offline data.
    /// </summary>
    /// <typeparam name="T">Item.</typeparam>
    public interface IFirebaseOfflineData<T>
    {
        /// <summary>
        /// Add item async.
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Is succes.</returns>
        Task<bool> AddItemAsync(T item);

        /// <summary>
        /// Update item.
        /// </summary>
        /// <param name="id">Id item.</param>
        /// <param name="item">Item.</param>
        /// <returns>Is succes.</returns>
        Task<bool> UpdateItemAsync(string id, T item);

        /// <summary>
        /// Delete item.
        /// </summary>
        /// <param name="id">Id item</param>
        /// <returns>Is succes.</returns>
        Task<bool> DeleteItemAsync(string id);

        /// <summary>
        /// Get item async.
        /// </summary>
        /// <param name="id">Id item.</param>
        /// <returns>Item.</returns>
        Task<T> GetItemAsync(string id);

        /// <summary>
        /// Get items async.
        /// </summary>
        /// <param name="forceRefresh">Force refresh.</param>
        /// <returns>Items list.</returns>
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}

