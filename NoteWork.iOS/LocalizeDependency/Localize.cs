using System;

using Foundation;
using NoteWork.Localization;
using System.Globalization;
using NoteWork.iOS.LocalizeDependency;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace NoteWork.iOS.LocalizeDependency
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            var prefLang = "en";

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                prefLang = "tr";// pref.Substring(0,2);
                netLanguage = pref.Replace("_", "-");
            }

            CultureInfo ci = null;
            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch 
            {
                ci = new CultureInfo(prefLang);
            }

            return ci;
        }

   
        public void SetLocale()
        {
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            var netLocale = "tr-US"; //iosLocaleAuto.Replace("_", "-");
            CultureInfo ci;
            try
            {
                ci = new CultureInfo(netLocale);
            }
            catch
            {
                ci = GetCurrentCultureInfo();
            }

        }
    }
}