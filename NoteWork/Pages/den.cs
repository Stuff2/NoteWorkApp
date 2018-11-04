using Xamarin.Forms;
using NoteWork.Pages.Sekmeler;
using NoteWork.Store;
using NoteWork.Modals;

namespace NoteWork.Pages
{
    public class Den : TabbedPage
    {
        public Den()
        {
            /*Anasayfa anasayfa = null;
            Agim agim = null;
            Profilim profilim = null;
            Ayarlar ayarlar = null;

            if (anasayfa == null) { anasayfa = new Anasayfa(); }
            if (agim == null) { agim = new Agim(); }
            if (profilim == null) { profilim = new Profilim(); }
            if (ayarlar == null) { ayarlar = new Ayarlar(); }*/

            BarBackgroundColor = Color.FromHex("#eee");
            BackgroundColor = Color.FromHex("#f6f6f6");
            BarTextColor = Color.FromHex("#30bbbe");

            Children.Add(new Anasayfa());
            Children.Add(new Agim());
            Children.Add(new Profilim());
            Children.Add(new Ayarlar());
          //DisplayAlert("", Navigation.ModalStack.Count.ToString(), "ok");
        }
       async override protected void  OnAppearing()
       {
            
           // GirisSayfasi.manager.SyncAsync();
           //  DisplayAlert("", "", "ok");

       }

    }
}
