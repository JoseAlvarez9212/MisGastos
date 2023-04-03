using System;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Auth;
using Java.Interop;
using MisGastos.Prism.Models;
using MisGastos.Prism.Services.Firebase;

namespace MisGastos.Prism.Droid.Services.FirebaseSerices
{
    public class FirebaseAuthentication : IFirebaseAuthentication
    {
        private readonly FirebaseAuth _FirebaseAuth;

        public FirebaseAuthentication()
        {
            _FirebaseAuth = FirebaseAuth.Instance;
        }

        public async Task<FirebaseResponse> RegisterWithEmailAndPassword(string email, string password)
        {
            try
            {
                var auth = await _FirebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password);
                return FirebaseResult(auth);
            }
            catch (FirebaseAuthException ex)
            {
                return new FirebaseResponse(ex);
            }
            catch (Exception ex)
            {
                return new FirebaseResponse(ex);
            }
        }

        public bool UpdateProfile()
        {
            try
            {
                UserProfileChangeRequest userProfile = new UserProfileChangeRequest.Builder()
                    .SetDisplayName("")
                    .Build();
                var result = Firebase.Auth.FirebaseAuth.Instance.CurrentUser.UpdateProfile(userProfile);
                return result.IsSuccessful;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsSignIn()
        {
            var user = _FirebaseAuth.CurrentUser;
            return user != null;
        }

        public async Task<FirebaseResponse> LoginWithEmailAndPassword(string email, string password)
        {
            try
            {
                var auth = await _FirebaseAuth.SignInWithEmailAndPasswordAsync(email, password);
                return FirebaseResult(auth);
            }
            catch (FirebaseAuthException ex)
            {
                return new FirebaseResponse(ex);
            }
            catch (Exception ex)
            {
                return new FirebaseResponse(ex);
            }
        }

        public bool SignOut()
        {
            try
            {
                _FirebaseAuth.SignOut();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private FirebaseResponse FirebaseResult(IAuthResult authResult)
        {
            var firebaseResponse = new FirebaseResponse
            {
                IsSucces = authResult.User != null,
                User = new User
                {
                    Email = authResult.User.Email,
                    UrlPhoto = authResult.User.PhotoUrl?.ToString(),
                    UserName = authResult.AdditionalUserInfo?.Username,
                    Uid = authResult.User.Uid
                },
                Token = authResult.User.GetIdToken(false).Result.ToString(),
                ProviderType = authResult.AdditionalUserInfo?.ProviderId
            };
            return firebaseResponse;
        }
    }
}

