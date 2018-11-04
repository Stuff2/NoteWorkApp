using Xamarin.Forms;
using NoteWork.iOS;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using System.ComponentModel;
using Foundation;

[assembly: ExportRenderer(typeof(NoteWork.Renderer.Wrenderer), typeof(Wrender))]
namespace NoteWork.iOS
{
    class Wrender:ViewRenderer<WebView,UIWebView>

    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var x = (NoteWork.Renderer.Wrenderer)sender;
            if (e.PropertyName == "Clears" && x.Clears == true)
            {

                NSHttpCookieStorage cks = NSHttpCookieStorage.SharedStorage;
                foreach(var z in cks.Cookies)
                {
                    cks.DeleteCookie(z);
                }

            }
        }
    }
}