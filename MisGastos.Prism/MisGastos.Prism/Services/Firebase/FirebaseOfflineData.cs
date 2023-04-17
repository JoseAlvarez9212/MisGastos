using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Offline;
using MisGastos.Prism.Enums;
using MisGastos.Prism.Helpers;

namespace MisGastos.Prism.Services.Firebase
{
    /// <summary>
    /// Firebase offline data.
    /// </summary>
    /// <typeparam name="T">Item.</typeparam>
    public class FirebaseOfflineData<T> : IFirebaseOfflineData<T> where T : class
    {
        private readonly RealtimeDatabase<T> _realtimeDb;

        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="baseURL">Firebase url base.</param>
        /// <param name="authService">Auth service.</param>
        /// <param name="nodeType">Node.</param>
        /// <param name="key">Key.</param>
        public FirebaseOfflineData(string baseURL,
            FirebaseAuthService authService,
            FirebaseNodeType nodeType,
            string key = "")
        {
            FirebaseOptions options = new FirebaseOptions()
            {
                OfflineDatabaseFactory = (t, s) => new OfflineDatabase(t, s),
                //AuthTokenAsyncFactory = async () => await authService.GetFirebaseAuthToken()
            };

            // The offline database filename is named after type T.
            // So, if you have more than one list of type T objects, you need to differentiate it
            // by adding a filename modifier; which is what we're using the "key" parameter for.
            var path = $"{nodeType}".ToLowerSafely();
            var client = new FirebaseClient(baseURL, options);
            _realtimeDb = client
                .Child(path)
                .AsRealtimeDatabase<T>(key, "", StreamingOptions.LatestOnly, InitialPullStrategy.MissingOnly, true);
        }

        #region CRUD Firebase Methods.
        /// <summary>
        /// Add item async.
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Is succes.</returns>
        public async Task<bool> AddItemAsync(T item)
        {
            try
            {
                string key = _realtimeDb.Post(item);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Update item.
        /// </summary>
        /// <param name="id">Id item.</param>
        /// <param name="item">Item.</param>
        /// <returns>Is succes.</returns>
        public async Task<bool> UpdateItemAsync(string id, T item)
        {
            try
            {
                _realtimeDb.Put(id, item);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Delete item.
        /// </summary>
        /// <param name="id">Id item</param>
        /// <returns>Is succes.</returns>
        public async Task<bool> DeleteItemAsync(string id)
        {
            try
            {
                _realtimeDb.Delete(id);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Get item async.
        /// </summary>
        /// <param name="id">Id item.</param>
        /// <returns>Item.</returns>
        public async Task<T> GetItemAsync(string id)
        {
            if (_realtimeDb.Database?.Count == 0)
            {
                try
                {
                    await _realtimeDb.PullAsync();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            bool success = _realtimeDb.Database.TryGetValue(id, out OfflineEntry offlineEntry);
            var result = offlineEntry?.Deserialize<T>();

            return await Task.FromResult(result);
        }

        /// <summary>
        /// Get items async.
        /// </summary>
        /// <param name="forceRefresh">Force refresh.</param>
        /// <returns>Items list.</returns>
        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            if (_realtimeDb.Database?.Count == 0)
            {
                try
                {
                    await _realtimeDb.PullAsync();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            var result = _realtimeDb
                .Once()
                .Select(x => x.Object);

            return await Task.FromResult(result);
        }
        #endregion
    }
}

