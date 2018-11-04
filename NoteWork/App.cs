using NoteWork.Localization;
using NoteWork.Pages;
using NoteWork.Pages.Sekmeler;
using NoteWork.Resx;
using NoteWork.Store;
using Xamarin.Forms;

namespace NoteWork
{
    public class App : Application
    {
        
        public App()
        { 
            if (Device.OS == TargetPlatform.Android ||
                Device.OS == TargetPlatform.iOS)
            {
                DependencyService.Get<ILocalize>().SetLocale();
                AppResource.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            }

            var mainPage = new GirisSayfasi();

            MainPage = mainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
