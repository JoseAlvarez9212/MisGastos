using System;
using System.Threading.Tasks;
using MisGastos.Prism.Services.Firebase;
using Firebase.Auth;
using MisGastos.Prism.Models;

namespace MisGastos.Prism.Droid.Services.FirebaseSerices
{
	public class FirebaseAuthentication : IFirebaseAuthentication
    {
        public bool IsSignIn()
        {
            var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
            return user != null;
        }

        public async Task<FirebaseResponse> LoginWithEmailAndPassword(string email, string password)
        {
            try
            {
                var auth = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var firebaseResponse = new FirebaseResponse
                {
                    IsSucces = auth.User != null,
                    User = new User
                    {
                        Email = auth.User.Email,
                        UrlPhoto = auth.User.PhotoUrl?.ToString(),
                        UserName = auth.AdditionalUserInfo?.Username,
                        Uid = auth.User.Uid
                    },
                    Token = auth.User.GetIdToken(false).Result.ToString(),
                    ProviderType = auth.AdditionalUserInfo?.ProviderId
                };
                return firebaseResponse;
            }
            catch (FirebaseAuthException ex)
            {
                return new FirebaseResponse { Error = ex };
            }
            catch (Exception ex)
            {
                return new FirebaseResponse { Error = ex };
            }
        }

        public bool SignOut()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

