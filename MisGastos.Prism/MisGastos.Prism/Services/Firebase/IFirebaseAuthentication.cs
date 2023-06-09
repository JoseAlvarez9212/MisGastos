﻿using System;
using System.Threading.Tasks;
using MisGastos.Prism.Models;

namespace MisGastos.Prism.Services.Firebase
{
	public interface IFirebaseAuthentication
	{
        Task<FirebaseResponse> RegisterWithEmailAndPassword(string email, string password);
        Task<FirebaseResponse> LoginWithEmailAndPassword(string email, string password);
        //bool SignOut();
        //bool IsSignIn();
    }
}

