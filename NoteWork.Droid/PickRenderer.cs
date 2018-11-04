using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using NoteWork.Droid;
using Android.Graphics.Drawables;
using Android.Widget;
using Android.Support.V7.App;
using System;

[assembly: ExportRenderer(typeof(NoteWork.Renderer.CPicker), typeof(PickRenderer))]
namespace NoteWork.Droid
{
    class PickRenderer : PickerRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)

            {
                var native = (global::Android.Widget.TextView)Control;
                // native.SetBackgroundColor(Android.Graphics.Color.Transparent);
                var pc = native.Text;

                GradientDrawable customBG = new GradientDrawable();
                customBG.SetColor(Xamarin.Forms.Color.FromHex("#eeeeee").ToAndroid());
                customBG.SetCornerRadius(10);

                int borderWidth = 2;
                customBG.SetStroke(borderWidth, Xamarin.Forms.Color.FromHex("#c1c1c1").ToAndroid());

                native.SetBackground(customBG);

              




            }



        }

      

    }
}