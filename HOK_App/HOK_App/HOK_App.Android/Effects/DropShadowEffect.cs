using System;
using System.Linq;
using HOK_App.Droid.Effects;
using HOK_App.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("CubiSoft")]
[assembly: ExportEffect(typeof(DropShadowEffect), "DropShadowEffect")]
namespace HOK_App.Droid.Effects
{
    public class DropShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var control = Control ?? Container as Android.Views.View;

                var effect = (ViewShadowEffect)Element.Effects.FirstOrDefault(e => e is ViewShadowEffect);

                if (effect != null)
                {
                    float radius = effect.Radius;

                    control.Elevation = radius;
                    control.TranslationZ = (effect.DistanceX + effect.DistanceY) / 2;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: {0}", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}

