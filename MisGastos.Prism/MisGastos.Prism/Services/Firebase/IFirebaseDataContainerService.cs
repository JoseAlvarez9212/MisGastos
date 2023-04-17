using MisGastos.Prism.Models.FirebaseDB;

namespace MisGastos.Prism.Services.Firebase
{
    /// <summary>
    /// Contract for the Firebase data container service.
    /// </summary>
    public interface IFirebaseDataContainerService
    {
        /// <summary>
        /// Teams node data.
        /// </summary>
        IFirebaseOfflineData<TeamModel> TeamsData { get; }
    }
}

