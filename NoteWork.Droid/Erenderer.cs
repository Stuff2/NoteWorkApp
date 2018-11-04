using Xamarin.Forms.Platform.Android;
using Notework.Droid;
using Xamarin.Forms;
using Android.Graphics.Drawables;



[assembly: ExportRenderer(typeof(NoteWork.Renderer.CEntry), typeof(Erenderer))]
namespace Notework.Droid
{
    class Erenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);

                GradientDrawable customBG = new GradientDrawable();
                customBG.SetColor(Xamarin.Forms.Color.FromHex("#eeeeee").ToAndroid());
                customBG.SetCornerRadius(10);
                int borderWidth = 2;
                customBG.SetStroke(borderWidth, Xamarin.Forms.Color.FromHex("#c1c1c1").ToAndroid());
                this.Control.SetBackground(customBG);

            }
        }
    }
}