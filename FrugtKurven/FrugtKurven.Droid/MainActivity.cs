using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Ioc;

namespace FrugtKurven.Droid
{
    [Activity(Label = "FrugtKurven", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetIoC();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        //<summary>
        //Set the Inversion of Control
        //</summary>
        private static void SetIoC()
        {
            // Create the container
            var container = new SimpleContainer();

            // Dependecy container
            container.Register<IDependencyContainer>(t => container);

            // Resolve the container
            Resolver.SetResolver(container.GetResolver());
        }
    }
}

