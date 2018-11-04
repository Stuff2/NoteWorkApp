using Android.Content;
using Android.Views;
using Android.Widget;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ListView = Android.Widget.ListView;
using View = Android.Views.View;

namespace NoteWork
{
    class C2Renderer : TableViewModelRenderer
    {
        TableView x;
        private static readonly MethodInfo CellForPosition = typeof(Xamarin.Forms.Platform.Android.TableViewModelRenderer)
                .GetMethod(nameof(GetCellForPosition), BindingFlags.NonPublic | BindingFlags.Instance, null, CallingConventions.Any,
                    new[] { typeof(int), typeof(bool).MakeByRefType(), typeof(bool).MakeByRefType() }, null);

        public C2Renderer(Context context, Android.Widget.ListView listView, TableView view) : base(context, listView, view)
        {
            x = view;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = base.GetView(position, convertView, parent);

            /*if (GetCellForPosition(position).GetType() != typeof(TextCell)) return view;
            var layout = (LinearLayout)view;
           var text = (TextView)((LinearLayout)((LinearLayout)layout.GetChildAt(0)).GetChildAt(1)).GetChildAt(0);
            //var text = (TextView)((LinearLayout)((LinearLayout)layout.GetChildAt(0)).GetChildAt(0)).GetChildAt(0);
            text.SetTextColor(Color.FromHex("#112233").ToAndroid());
            var divider = layout.GetChildAt(1);
            divider.SetBackgroundColor(Color.FromHex("#112233").ToAndroid());*/
            if (x.Intent == TableIntent.Menu)
            {
                var @params = new object[] { position, false, false };
                var cell = CellForPosition.Invoke(this, @params) as Cell;   //Reflection to base method to determine cell type

                bool Base = (bool)@params[1];
                var x = (cell as TextCell);
                var layout = (LinearLayout)view;
                var text = (TextView)((LinearLayout)((LinearLayout)layout.GetChildAt(0)).GetChildAt(1)).GetChildAt(0);
                var divider = layout.GetChildAt(1);
                divider.SetBackgroundColor(Color.FromHex("#c8c7cc").ToAndroid());
                //With view recycling, we need to ensure Visibility is set to the proper value


                if (Base)
                {
                    view.SetBackgroundColor(Color.FromHex("#efeff4").ToAndroid());
                    text.SetTextColor(Color.FromHex("#6d6d72").ToAndroid());
                }
                else
                {
                    view.SetBackgroundColor(Color.White.ToAndroid());
                    text.SetTextColor(Color.FromHex("#010101").ToAndroid());
                }

                return view;
            }
            return view;
        }
    }
}