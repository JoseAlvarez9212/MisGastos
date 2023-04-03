using System;
using DryIoc;

namespace MisGastos.Prism.Models
{
    public class FirebaseResponse
    {
        public bool IsSucces { get; set; }

        public User User { get; set; }

        public string Token { get; set; }

        public Exception Exception { get; set; }

        public string ProviderType { get; set; }

        public FirebaseResponse()
        {

        }

        public FirebaseResponse(Exception exception)
        {
            Exception = exception;
        }
    }

    public class User
    {
        public string UserName { get; set; }
        public string UrlPhoto { get; set; }
        public string Email { get; set; }
        public string Uid { get; set; }
    }
}

