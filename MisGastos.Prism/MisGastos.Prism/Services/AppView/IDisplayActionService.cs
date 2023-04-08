using System;
using System.Threading.Tasks;

namespace MisGastos.Prism.Services.AppView
{
	public interface IDisplayActionService
	{
       Task DisplayAlert(string title, string message, string cancel);

       bool InternetConnect();
    }
}

