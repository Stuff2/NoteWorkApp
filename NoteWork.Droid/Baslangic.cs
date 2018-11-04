
using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.Permissions;

namespace NoteWork.Droid
{
    
    [Activity(Label = "NoteWork", Icon = "@drawable/logo123", NoHistory = true, Theme = "@style/Theme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class Baslangic : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
           

            base.OnCreate(bundle);

            StartActivity(typeof(MainActivity));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

