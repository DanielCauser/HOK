﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using HOK_App.Droid.Services;
using HOK_App.Services;
using ImageCircle.Forms.Plugin.Droid;
using Plugin.LocalNotifications;
using Prism;
using Prism.Ioc;

namespace HOK_App.Droid
{
    [Activity(Label = "Maui Church", Icon = "@mipmap/ic_launcher", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            LocalNotificationsImplementation.NotificationIconId = Resource.Drawable.logo;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            InitDependencies();
            Plugin.Jobs.CrossJobs.Init(this, bundle); // activity


            LoadApplication(new App(new AndroidInitializer()));
        }

        private void InitDependencies()
        {
            ImageCircleRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            Plugin.Iconize.Iconize.Init(Resource.Id.toolbar, Resource.Id.sliding_tabs);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            container.Register<IFileService, FileService>();
        }
    }
}

