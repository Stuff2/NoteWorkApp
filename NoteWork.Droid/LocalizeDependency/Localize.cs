using NoteWork.Localization;
using System.Globalization;
using System.Threading;
using NoteWork.LocalizeDependency;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace NoteWork.LocalizeDependency
{
    public  class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLocale = "tr-TR"; //androidLocale.ToString().Replace("_", "-");
            return new CultureInfo(netLocale);
        }
        public void SetLocale()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLocale = "tr-TR"; //androidLocale.ToString().Replace("_", "-");
            var ci = new CultureInfo(netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

        }
    }
}
