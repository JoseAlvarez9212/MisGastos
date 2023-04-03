using System;
using System.Threading.Tasks;
using MisGastos.Prism.Models;
using MisGastos.Prism.Services.Firebase;

namespace MisGastos.Prism.iOS.Services.FirebaseServices
{
	public class FirebaseAuthentication : IFirebaseAuthentication
	{

        public Task<FirebaseResponse> LoginWithEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<FirebaseResponse> RegisterWithEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}

