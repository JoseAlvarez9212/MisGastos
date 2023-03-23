using System;
using MisGastos.Prism.Services.Resources.Strings;
using Prism.Events;
using Prism.Ioc;
using Xamarin.Forms.Xaml;

namespace MisGastos.Prism.Helpers
{
	public class StringsMarkupExtension : IMarkupExtension
    {
        private static readonly Lazy<IStringsService> _stringsService =
        new Lazy<IStringsService>(() => ContainerLocator.Container.Resolve<IStringsService>());

        public string Name { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
           return _stringsService.Value.GetValue(Name);
        }
    }
}

