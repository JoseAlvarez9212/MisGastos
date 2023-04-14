using System;
using System.Reflection;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MisGastos.Prism.Helpers
{
    [ContentProperty(nameof(ImageSource))]
	public class SvgButtonMarkupExtension : IMarkupExtension
    {
        public string ImageSource { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ImageSource is null)
            {
                return null;
            }

            var width = 0;
            var heigth = 0;

            IProvideValueTarget provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var visualElement = provideValueTarget.TargetObject as VisualElement;
            if (visualElement != null)
            {
                width = (int)visualElement.WidthRequest;
                heigth = (int)visualElement.HeightRequest;
            }
            var assemblyType = typeof(SvgButtonMarkupExtension).GetTypeInfo().Assembly;
            var imageSource = SvgImageSource.FromResource($"{"MisGastos.Prism.Resources.icon.ic_arrow.svg"}", sourceAssembly: assemblyType , vectorWidth: width,vectorHeight: heigth);
            return imageSource;
        }
    }
}

