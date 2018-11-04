using NoteWork.Modals;
using NoteWork.Renderer;
using NoteWork.Resx;
using NoteWork.Store;
using System;
using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public partial class TemelBilgi : ContentPage
    {
		async void OnButtonClicked4(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
        public TemelBilgi(string name, string surname, string mails, string passwords)
        {

            var stack = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            var stack2 = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            var grida = new Grid() { BackgroundColor = Color.FromHex("#f6f6f6"), VerticalOptions = LayoutOptions.EndAndExpand };
            grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grida.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });
            var gridb = new Grid() { BackgroundColor = Color.FromHex("#f6f6f6"), VerticalOptions = LayoutOptions.EndAndExpand };
            gridb.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridb.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridb.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) });
            var gridc = new Grid() { BackgroundColor = Color.FromHex("#f6f6f6"), VerticalOptions = LayoutOptions.EndAndExpand };
            gridc.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridc.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
           

            var aswitch = new Switch()
            {
                IsToggled = true,
                Margin = new Thickness(0,0,15,0),
                HorizontalOptions = LayoutOptions.EndAndExpand,
                
            };
            var durum = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Placeholder = "NoteWork AŞ., Ruken Computer Ltd., vs. ",
                FontSize = 15
            };
            
            var unvan = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Placeholder = "Android Geliştirici, Doktor, Pazarlama Müdürü, vs. ",
                FontSize = 15
            };
            var univer = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Placeholder = "Boğaziçi Üniversitesi, İstanbul Üniversitesi vs. ",
                FontSize = 15
            };

            stack.Children.Add(new Label
            {
                Text = "     Temel bilgilerinizi hızlıca tamamlayın...",
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(0, 20, 0, 0),
                HeightRequest = 40,
            });
            stack.Children.Add(stack2);
            stack2.Children.Add(new Label
            {
                Text = "Çalıştığınız kurum",

                Margin = new Thickness(20, 20, 0, 0)
            });
            gridc.Children.Add(durum, 0, 0);
            Grid.SetColumnSpan(durum,2);
            gridc.Children.Add(aswitch, 1, 0);
            stack2.Children.Add(gridc);
      
            stack2.Children.Add(new Label
            {
                Text = "İş Unvanı",
                Margin = new Thickness(20, 20, 0, 0)
            });
            stack2.Children.Add(unvan);
            stack2.Children.Add(new Label
            {
                Text = "Üniversiteniz",
                Margin = new Thickness(20, 20, 0, 0)
            });
            stack2.Children.Add(univer);
            
            
            aswitch.Toggled += (e, s) =>
            {
                if (aswitch.IsToggled == false)
                {
                    durum.Placeholder = "(Çalışmıyorum)";
                    unvan.Placeholder = "(Çalışmıyorum)";
                    unvan.IsEnabled = false;
                    durum.IsEnabled = false;
                }
                if (aswitch.IsToggled == true)
                {
                    durum.Placeholder = "NoteWork AŞ., Ruken Computer Ltd., vs.";
                    unvan.Placeholder = "Android Geliştirici, Doktor, Pazarlama Müdürü, vs.";
                    unvan.IsEnabled = true;
                    durum.IsEnabled = true;
                }

            };

            var butonumuz = new Image()
            {
                Source = "tamamla111.png",
                Margin = new Thickness(0, 0, 15, 0),

            };

            var iptal = new Button()
            {
                Text = AppResource.iptalbuton,
                BackgroundColor = Color.Transparent,
                TextColor = Color.Black
            };


            grida.Children.Add(butonumuz, 1, 0);
            grida.Children.Add(iptal, 0, 0);

            iptal.Clicked += OnButtonClicked4;


            var a = new ScrollView { Content = stack, Padding = new Thickness(0, 0, 0, 20) };
            var b = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            b.Children.Add(a);
            b.Children.Add(grida);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) => {

                KayitManager manager = KayitManager.DefaultManager;
                var lg = new Login { Mail = mails, Password = passwords };
                var pl = new Profile {EMail = mails ,FirstName=name,LastName=surname, Universities = univer.Text, JobTitle = unvan.Text, Company = durum.Text  };
                 manager.SaveLoginAsync(pl, lg);
                await Navigation.PushModalAsync(new GirisSayfasi());

            };
            butonumuz.GestureRecognizers.Add(tapGestureRecognizer);

            Content = b;

        }


    }
}