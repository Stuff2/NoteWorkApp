using Xamarin.Forms.Platform.Android;
using Notework.Droid;
using Xamarin.Forms;
using Android.Runtime;
using Android.Views;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(NoteWork.Renderer.Wrenderer), typeof(Wrender))]
namespace Notework.Droid
{
    class Wrender : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);
           
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var x = (NoteWork.Renderer.Wrenderer)sender;
            if (e.PropertyName == "Clears"&& x.Clears==true) {
                Control.ClearCache(true);
                Control.ClearFormData();
                Control.ClearHistory();
                Control.DrawingCacheEnabled = false;
                Control.Settings.CacheMode = Android.Webkit.CacheModes.NoCache;
                Control.Settings.SaveFormData = false;
                Control.Settings.SavePassword = false;
                Control.Settings.SetAppCacheEnabled(false);
                Android.Webkit.CookieManager.Instance.RemoveAllCookie();

            }

            
        }
       

       

    }
}