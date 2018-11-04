using NoteWork.Renderer;
using NoteWork.Resx;
using NoteWork.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public partial class ProfilDuzenle : ContentPage
    {
		async void OnButtonClicked4(object sender, EventArgs e)
		{		
			await Navigation.PopModalAsync();
		}
        public ProfilDuzenle(NoteWork.Modals.Profile biProfil)
        {
            const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            const string nameRegex = @"[a-zA-Z]+";


            var stack = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            var stack2 = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            var grida = new Grid() { BackgroundColor = Color.FromHex("#f6f6f6"), Margin = new Thickness(0, -6, 0, 0) };
            grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grida.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });



            stack.Children.Add(new Label
            {
                Text = "Temel Bilgilerinizi Buradan Düzenleyebilirsiniz",
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
                Text = AppResource.kisieklelabel2,

                Margin = new Thickness(20, 20, 0, 0)
            });
            var ad = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil.FirstName
            };
            stack2.Children.Add(ad);
            stack2.Children.Add(new Label
            {
                Text = AppResource.kisieklelabelsoyad,
                Margin = new Thickness(20, 20, 0, 0)
            });
            var soyad = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil.LastName
            };
            stack2.Children.Add(soyad);
            stack2.Children.Add(new Label
            {
                Text = "Doğum Günü",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var birthDate = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil.BirthDate.ToString()
            };
            stack2.Children.Add(birthDate);
            stack2.Children.Add(new Label
            {
                Text = "Üniversite",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var univer = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil.Universities
            };
            stack2.Children.Add(univer);
            stack2.Children.Add(new Label
            {
                Text = AppResource.kisieklelabel3,
                Margin = new Thickness(20, 20, 0, 0)
            });
            var sirket = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil.Company
            };
            stack2.Children.Add(sirket);
            stack2.Children.Add(new Label
            {
                Text = AppResource.kisieklelabel4,

                Margin = new Thickness(20, 20, 0, 0)
            });
            var unvan = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil.JobTitle
            };
            stack2.Children.Add(unvan);
            stack2.Children.Add(new Label
            {
                Text = "Asistan İsmi",

                Margin = new Thickness(20, 20, 0, 0)
            });
            var AsstName = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil.AssistantName
            };
            stack2.Children.Add(AsstName);
            stack2.Children.Add(new Label
            {
                Text = AppResource.kisieklelabel5,
                Margin = new Thickness(20, 20, 0, 0)
            });
            var sehir = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil.City
            };
            stack2.Children.Add(sehir);
            stack2.Children.Add(new Label
            {
                Text = "Memleket",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var hometown = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil.Hometown
            };
            stack2.Children.Add(hometown);
            stack2.Children.Add(new Label
            {
                Text = "Ofis Adresi",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var officeAdd = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil.OfficeAddress
            };
            stack2.Children.Add(officeAdd);
            stack2.Children.Add(new Label
            {
                Text = AppResource.kisieklelabel6,
                Margin = new Thickness(20, 20, 0, 0)
            });
            var numara = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Keyboard = Keyboard.Numeric,
                Text = biProfil.TelNo
            };
            stack2.Children.Add(numara);
            stack2.Children.Add(new Label
            {
                Text = AppResource.kisieklelabel7,
                Margin = new Thickness(20, 20, 0, 0)
            });
            var mail = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Keyboard = Keyboard.Email,
                Text = biProfil.EMail
            };
            stack2.Children.Add(mail);


            var butonumuz = new Image()
            {
                Source = "devamet111.png",
                Margin = new Thickness(0, 0, 15, 0),

            };
            var iptal = new Button()
            {
                Text = AppResource.kisieklebuton,
                BackgroundColor = Color.Transparent,
                TextColor = Color.Black
            };

            iptal.Clicked += OnButtonClicked4;

            var tapGestureRecognizer4 = new TapGestureRecognizer();
            tapGestureRecognizer4.Tapped += async (s, e) => {
                if (!string.IsNullOrEmpty(ad.Text))
                {
                    var nameValid = (Regex.IsMatch(ad.Text, nameRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                    if (nameValid)
                    {

                        await Navigation.PushModalAsync(new ProfilDuzenle2(biProfil, ad.Text, soyad.Text, sehir.Text, unvan.Text, sirket.Text, mail.Text, numara.Text, hometown.Text, birthDate.Text, officeAdd.Text, AsstName.Text, univer.Text));

                    }
                    else
                    {
                        await DisplayAlert("Dikkat", "Bilgilerinizde eksik veya yanlış girdi tespit edilmiştir. Lütfen tekrar bilgilerinizi giriniz!", "Tamam");
                    }
                }
                else
                    await DisplayAlert("Dikkat", "İsim boş olamaz!", "Tamam");



            };
            butonumuz.GestureRecognizers.Add(tapGestureRecognizer4);

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
