using System.ComponentModel;
using Xamarin.Forms;

namespace NoteWork.Renderer
{
   public  class Wrenderer : WebView
    {
        public static readonly BindableProperty ClearAll =
       BindableProperty.Create<Wrenderer, bool>(p => p.Clears,false);
        

        //Gets or sets the color of the progress bar
        public bool Clears
        {
            get { return (bool)GetValue(ClearAll); }
            set { SetValue(ClearAll, value); }
        }

    }
}
