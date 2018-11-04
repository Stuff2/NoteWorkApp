using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NoteWork.CTableView), typeof(NoteWork.CRenderer))]
namespace NoteWork
{
    public class CRenderer : TableViewRenderer
    {
        protected override TableViewModelRenderer GetModelRenderer(Android.Widget.ListView listView, TableView view)
        {
            return new C2Renderer(Context, listView, view);
        }
    }
}