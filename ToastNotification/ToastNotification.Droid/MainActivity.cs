﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Plugin.Toasts;
using Acr.UserDialogs;

namespace ToastNotification.Droid
{
    [Activity(Label = "ToastNotification", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            
            global::Xamarin.Forms.Forms.Init(this, bundle);

            UserDialogs.Init(this);

            DependencyService.Register<ToastNotificatorImplementation>();
            ToastNotificatorImplementation.Init(this);

            LoadApplication(new App());
        }
    }
}

