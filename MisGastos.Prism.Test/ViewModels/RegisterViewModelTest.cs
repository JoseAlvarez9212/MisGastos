using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MisGastos.Prism.Models;
using MisGastos.Prism.Services.AppView;
using MisGastos.Prism.Services.Firebase;
using MisGastos.Prism.Services.Resources.Strings;
using MisGastos.Prism.Test.Extensions;
using MisGastos.Prism.ViewModels;
using Moq;
using Prism.Navigation;

namespace MisGastos.Prism.Test.ViewModels
{
    /// <summary>
    /// RegisterViewModel Test
    /// </summary>
    [TestClass]
    public class RegisterViewModelTest
	{
        /// <summary>
        /// OnRegisterAsync
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <param name="name">Name.</param>
        /// <param name="lastname">Last name</param>
        /// <param name="firebaseAuthIsSucces">Is Succes Firebase auth.</param>
        /// <returns></returns>
        [DataTestMethod]
        [DataRow(null, null, null, null, false)]
        [DataRow(" ", " ", " ", " ", false)]
        [DataRow("jose.alvarez9212@gmail.com","Abcd1234","Jose","Alvarez", false)]
        [DataRow("jose.alvarez9212@gmail.com", "Abcd1234", "Jose", "Alvarez", true)]
        public async Task OnRegisterAsync(string email, string password, string name, string lastname , bool firebaseAuthIsSucces)
		{
            var navigationServiceMock = new Mock<INavigationService>();
            var appViewService = new Mock<IAppViewService>();
            var stringsServiceMock = new Mock<IStringsService>();
            var firebaseAuthenticationMock = new Mock<IFirebaseAuthentication>();
            firebaseAuthenticationMock.Setup(x =>
                x.RegisterWithEmailAndPassword(
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new FirebaseResponse { IsSucces = firebaseAuthIsSucces });

            var viewModel = new RegisterViewModel(
                navigationServiceMock.Object,
                appViewService.Object,
                stringsServiceMock.Object,
                firebaseAuthenticationMock.Object);

            viewModel.EmailEntry = email;
			viewModel.PasswordEntry = password;
			viewModel.NameEntry = name;
			viewModel.LastNameEntry = lastname;

			var result = await viewModel.RegisterAsync().RunWithoutExceptionsAsync();
            Assert.IsTrue(result);
        }		
    }
}

