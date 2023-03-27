using System;
namespace MisGastos.Prism.Models
{
    public class FirebaseResponse
    {
        public bool IsSucces { get; set; }

        public User User { get; set; }

        public string Token { get; set; }

        public Exception Error { get; set; }

        public string ProviderType { get; set; }
    }

    public class User
    {
        public string UserName { get; set; }
        public string UrlPhoto { get; set; }
        public string Email { get; set; }
        public string Uid { get; set; }
    }
}

