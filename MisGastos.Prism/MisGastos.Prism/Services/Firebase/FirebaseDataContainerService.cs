using MisGastos.Prism.Enums;
using MisGastos.Prism.Models.FirebaseDB;
using MisGastos.Prism.Services.Resources.ConfigApp;

namespace MisGastos.Prism.Services.Firebase
{
    /// <summary>
    /// Firebase data container service.
    /// </summary>
    public class FirebaseDataContainerService: IFirebaseDataContainerService
    {
        private IEnvironmentService _environmentService;
        private IFirebaseOfflineData<TeamModel> _teamsStore;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="environmentService">The IEnvironmentService.</param>
        public FirebaseDataContainerService(IEnvironmentService environmentService)
		{
            _environmentService = environmentService;
        }

        /// <summary>
        /// Teams node data.
        /// </summary>
        public IFirebaseOfflineData<TeamModel> TeamsData
        {
            get
            {
                if (_teamsStore == null)
                {
                    _teamsStore = new FirebaseOfflineData<TeamModel>(
                        _environmentService.FirebaseProjectID,
                        new FirebaseAuthService(),
                        FirebaseNodeType.Teams);
                }
                return _teamsStore;
            }
        }
    }
}

