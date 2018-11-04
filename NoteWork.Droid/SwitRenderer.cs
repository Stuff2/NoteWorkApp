using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NoteWork.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(NoteWork.Renderer.CSwitch), typeof(SwitRenderer))]
namespace NoteWork.Droid
{

    class SwitRenderer : SwitchRenderer

    {

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var mysw =Control;
                
                
               
                mysw.TextOn = "";
                mysw.TextOff = "";
                Scroller a = new Scroller(Forms.Context);
               
                Android.Graphics.Color colorOn = Android.Graphics.Color.Green;
                Android.Graphics.Color colorOff = Android.Graphics.Color.Brown;
                Android.Graphics.Color colorDisabled = Android.Graphics.Color.Gray;

                StateListDrawable drawable = new StateListDrawable();
                drawable.AddState(new int[] { Android.Resource.Attribute.StateChecked }, new ColorDrawable(colorOn));
                drawable.AddState(new int[] { -Android.Resource.Attribute.StateEnabled }, new ColorDrawable(colorDisabled));
                drawable.AddState(new int[] { }, new ColorDrawable(colorOff));

                mysw.ThumbDrawable = drawable;
               



            }


        }

    }
}