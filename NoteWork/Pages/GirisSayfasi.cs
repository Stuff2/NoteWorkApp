using NoteWork.Modals;
using NoteWork.Pages.Sekmeler;
using NoteWork.Store;
using Plugin.Contacts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteWork.Pages

{
    public partial class GirisSayfasi : ContentPage
    {
        public static KayitManager manager;
        public GirisSayfasi()
        {
            manager = KayitManager.DefaultManager;

            //GirisYap girisYap = null;
            //KayitOl kayitOl = null;

            //if (girisYap == null) { girisYap = new GirisYap(); }
            //if (kayitOl == null) { kayitOl = new KayitOl(); }

            //manager.MailControlAsync("");
            CrossContacts.Current.RequestPermission();
            
            var grid = new Grid();
            for (var i = 0; i < 113; i++)
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            for (var i = 0; i < 56; i++)
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


            var girisyap = new Image
            {
                Source = "girisyap111.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) => {

                await Navigation.PushModalAsync(new GirisYap());
            };
            girisyap.GestureRecognizers.Add(tapGestureRecognizer);
            var kayitol = new Image
            {
                Source = "kaydol111.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += async (s, e) => {
                
                await Navigation.PushModalAsync(new KayitOl());
            };
            kayitol.GestureRecognizers.Add(tapGestureRecognizer2);
            var logo = new Image
            {
                Source = "girisLogo.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            grid.Children.Add(girisyap, 14, 79);
            Grid.SetRowSpan(girisyap, 8);
            Grid.SetColumnSpan(girisyap, 28);
            grid.Children.Add(logo, 14, 27);
            Grid.SetRowSpan(logo, 23);
            Grid.SetColumnSpan(logo, 29);
            grid.Children.Add(kayitol, 14, 68);
            Grid.SetRowSpan(kayitol, 8);
            Grid.SetColumnSpan(kayitol, 28);
            Content = grid;
        }
        
    }
}

