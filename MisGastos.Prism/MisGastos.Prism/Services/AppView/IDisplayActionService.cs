using System;
using System.Threading.Tasks;

namespace MisGastos.Prism.Services.AppView
{
	public interface IAppViewService
	{
       Task DisplayAlert(string title, string message, string cancel);

       bool InternetConnect();
    }
}

