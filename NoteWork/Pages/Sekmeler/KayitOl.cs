using NoteWork.Renderer;
using NoteWork.Store;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public partial class KayitOl : ContentPage
    {
		async void OnButtonClicked4(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
        
        public KayitOl()
        {
            
            const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            const string nameRegex = @"[a-zA-Z]+";

            var stack = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            var stack2 = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            var grida = new Grid() { BackgroundColor = Color.FromHex("#f6f6f6"), VerticalOptions = LayoutOptions.EndAndExpand };
            grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grida.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });

            var mail = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Keyboard = Keyboard.Email
            };

            var ad = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0)
            };

            var soyad = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0)
            };

            var sifre = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                IsPassword = true
            };

            var stekrar = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                IsPassword = true
            };

            stack.Children.Add(stack2);
            stack2.Children.Add(new Label
            {
                Text = "Ad",

                Margin = new Thickness(20, 20, 0, 0)
            });
            stack2.Children.Add(ad);
            stack2.Children.Add(new Label
            {
                Text = "Soyad",

                Margin = new Thickness(20, 20, 0, 0)
            });
            stack2.Children.Add(soyad);
            stack2.Children.Add(new Label
            {
                Text = "Mail Adresi",

                Margin = new Thickness(20, 20, 0, 0)
            });
            stack2.Children.Add(mail);
            stack2.Children.Add(new Label
            {
                Text = "Şifreniz",

                Margin = new Thickness(20, 20, 0, 0)
            });
            stack2.Children.Add(sifre);
            stack2.Children.Add(new Label
            {
                Text = "Şifreniz(Tekrar)",

                Margin = new Thickness(20, 20, 0, 0)
            });
            stack2.Children.Add(stekrar);


            var butonumuz = new Image()
            {
                Source = "kaydol111.png",
                Margin = new Thickness(0, 0, 15, 0),

            };
            var iptal = new Button()
            {
                Text = "İptal",
                BackgroundColor = Color.Transparent,
                TextColor = Color.Black
            };

            iptal.Clicked += OnButtonClicked4;
            
			var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) => {
                
                
                if (string.IsNullOrEmpty(ad.Text)|| string.IsNullOrEmpty(soyad.Text) || string.IsNullOrEmpty(mail.Text) || string.IsNullOrEmpty(sifre.Text) || string.IsNullOrEmpty(stekrar.Text) || ad.Text.Length < 2 || sifre.Text.Length < 6)
                {
                    await DisplayAlert("Dikkat", "Lütfen boşlukları doldurunuz!", "Tamam");
                    return;
                }

                if (sifre.Text != stekrar.Text)
                {
                    await DisplayAlert("Dikkat", "Lütfen şifrenizi tekrar giriniz!", "Tamam");
                    return;
                }
               
                var mailValid = (Regex.IsMatch(mail.Text, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                var nameValid = (Regex.IsMatch(ad.Text, nameRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                var surnameValid = (Regex.IsMatch(soyad.Text, nameRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                if (mailValid && nameValid && surnameValid)
                {
                    if (await GirisSayfasi.manager.MailControlAsync(mail.Text))
                        await Navigation.PushModalAsync(new TemelBilgi(ad.Text, soyad.Text, mail.Text, sifre.Text));
                    else
                        await DisplayAlert("Dikkat", "Bu Mail Kullanılmaktadır", "Tamam");
                }
               
                else
                {
                    await DisplayAlert("Dikkat", "Bilgilerinizde eksik veya yanlış girdi tespit edilmiştir. Lütfen tekrar bilgilerinizi giriniz!", "Tamam");
                }


               
            };
            butonumuz.GestureRecognizers.Add(tapGestureRecognizer);

            grida.Children.Add(butonumuz, 1, 0);
            grida.Children.Add(iptal, 0, 0);


            var a = new ScrollView { Content = stack, Padding = new Thickness(0, 0, 0, 20) };
            var b = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            b.Children.Add(a);
            b.Children.Add(grida);

            Content = b;

        }
    }
}

