using System;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace UnitConverter
{
    [Activity(Label = "Voice Unit Converter", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.Splash", ScreenOrientation = ScreenOrientation.Portrait, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Splash);




            Button theButton = FindViewById<Button>(Resource.Id.MyButton);
            
           
            
            


            theButton.Click += (sender, e) =>
            {
                StartActivity(typeof(VoiceRecognition));
            };


          

         
        }
    }
}